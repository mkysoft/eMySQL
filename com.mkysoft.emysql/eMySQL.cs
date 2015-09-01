using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace com.mkysoft.emysql
{
    public class eMySQL : IDisposable
    {
        /*
        [DllImport("libmysqld_x86.dll")]
        static extern int mysql_server_init(int argc, string[] argv, string[] groups);

        [DllImport("libmysqld_x86.dll")]
        static extern IntPtr mysql_init(IntPtr mysql);

        [DllImport("libmysqld_x86.dll")]
        static extern int mysql_options(IntPtr mysql, MySQLH.mysql_option option, string[] arg);

        [DllImport("libmysqld_x86.dll")]
        static extern IntPtr mysql_real_connect(IntPtr mysql, string host, string user, string passwd, string db, uint port, string unix_socket, uint client_flag);

        [DllImport("libmysqld_x86.dll")]
        static extern IntPtr mysql_fetch_lengths(IntPtr result);

        [DllImport("libmysqld_x86.dll")]
        static extern IntPtr mysql_store_result(IntPtr mysql);

        [DllImport("libmysqld_x86.dll")]
        static extern IntPtr mysql_fetch_row(IntPtr result);

        [DllImport("libmysqld_x86.dll")]
        static extern IntPtr mysql_fetch_fields(IntPtr result);

        [DllImport("libmysqld_x86.dll")]
        static extern uint mysql_field_count(IntPtr mysql);

        [DllImport("libmysqld_x86.dll")]
        static extern string mysql_error(IntPtr mysql);

        [DllImport("libmysqld_x86.dll")]
        static extern int mysql_real_query(IntPtr mysql, string query, uint length);

        [DllImport("libmysqld_x86.dll")]
        static extern void mysql_free_result(IntPtr mysql);

        [DllImport("libmysqld_x86.dll")]
        static extern void mysql_server_end();
        */

        [DllImport("libmysqld_x64.dll")]
        static extern int mysql_server_init(int argc, string[] argv, string[] groups);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_init(IntPtr mysql);

        [DllImport("libmysqld_x64.dll")]
        static extern int mysql_options(IntPtr mysql, MySQLH.mysql_option option, string[] arg);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_real_connect(IntPtr mysql, string host, string user, string passwd, string db, uint port, string unix_socket, uint client_flag);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_fetch_lengths(IntPtr result);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_store_result(IntPtr mysql);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_fetch_row(IntPtr result);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_fetch_field(IntPtr result);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_fetch_fields(IntPtr result);

        [DllImport("libmysqld_x64.dll")]
        static extern uint mysql_field_count(IntPtr mysql);

        [DllImport("libmysqld_x64.dll")]
        static extern IntPtr mysql_error(IntPtr mysql);

        [DllImport("libmysqld_x64.dll")]
        static extern int mysql_real_query(IntPtr mysql, string query, uint length);

        [DllImport("libmysqld_x64.dll")]
        static extern void mysql_free_result(IntPtr mysql);

        [DllImport("libmysqld_x64.dll")]
        static extern uint mysql_errno(IntPtr mysql);

        [DllImport("libmysqld_x64.dll")]
        static extern void mysql_server_end();

        string[] _Argv;
        string[] _Groups;
        string _AppDataPath;
        string _DBName;

        IntPtr _MySQL;

        public eMySQL(string DBName = null)
        {
            _DBName = DBName;
            InitFolder();
            _Argv = new string[] {
            "mysql_test", /* dikkate alınmaz */
            //"--basedir=./";
            "--datadir="+_AppDataPath+"/data",
            "--character-sets-dir=./share/charsets",
            "--key_buffer_size=64M",
            "--language=./",
            "--default-storage-engine=MyISAM",
            "--default_tmp_storage_engine=MyISAM",
            "--innodb=OFF",
            "--skip-innodb"
            //"--console"
            //"--log=./mysql-bin.log";
         };
            _Groups = new string[]{
            "libmysqld_server"
                };

            Start();
        }

        public void Dispose()
        {
            if (_MySQL != null)
                mysql_server_end();
        }

        private void InitFolder()
        {
            var folder = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "eMySQL"));
            if (!folder.Exists)
                folder.Create();
            _AppDataPath = folder.FullName.Replace('\\', '/');

            //data klasörünü olutur
            folder = new DirectoryInfo(Path.Combine(folder.FullName, "data"));
            if (!folder.Exists)
                folder.Create();
        }

        private void Start()
        {
            try
            {
                int res;
                if ((res = mysql_server_init(_Argv.Length - 1, _Argv, _Groups)) == 1)
                    throw new Exception(String.Format("MySQL Library Init Failed with error code: {0}", res));

                _MySQL = new IntPtr();
                _MySQL = mysql_init(IntPtr.Zero);
                mysql_options(_MySQL, MySQLH.mysql_option.MYSQL_OPT_USE_EMBEDDED_CONNECTION, null);
                mysql_real_connect(_MySQL, null, null, "", _DBName, 0, "", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Array MarshalArray(Type structureType, IntPtr arrayPtr, int length)
        {
            if (structureType == null)
                throw new ArgumentNullException("structureType");
            if (!structureType.IsValueType)
                throw new ArgumentException("Only struct types are supported.", "structureType");
            if (length < 0)
                throw new ArgumentOutOfRangeException("length", length, "length must be equal to or greater than zero.");
            if (arrayPtr == IntPtr.Zero)
                return null;
            int size = System.Runtime.InteropServices.Marshal.SizeOf(structureType);
            Array array = Array.CreateInstance(structureType, length);
            for (int i = 0; i < length; i++)
            {
                IntPtr offset = new IntPtr((long)arrayPtr + (size * i));
                object value = System.Runtime.InteropServices.Marshal.PtrToStructure(offset, structureType);
                array.SetValue(value, i);
            }
            return array;
        }

        private void MySQLQuery(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
                throw new DBException("Param 'query' must be filled!", -1);
            int result = mysql_real_query(_MySQL, query, (uint)query.Length);
            if (result == 0)
                return;
            CheckError();
        }

        private void CheckError()
        {
            var ErrNo = (int)mysql_errno(_MySQL);
            if (ErrNo != 0)
            {
                var ErrPrt = mysql_error(_MySQL);
                var ErrMsg = Marshal.PtrToStringAnsi(ErrPrt);
                throw new DBException(ErrMsg, ErrNo);
            }
        }

        public void ExecuteNoneQuery(string query)
        {
            MySQLQuery(query);
        }

        public List<List<string>> ExecuteQuery(string query)
        {
            var ResultList = new List<List<string>>();

            MySQLQuery(query);

            IntPtr result = mysql_store_result(_MySQL);
            if (result == IntPtr.Zero)
            {
                int errno = (int)mysql_errno(_MySQL);
                if (errno == 0)
                    throw new ArgumentException("Query didn't return reponse!");
                throw new ArgumentException(mysql_error(_MySQL) + " ErrNo: " + errno);
            }

            uint fieldCount = mysql_field_count(_MySQL);
            Debug.WriteLine("Field count: {0}", fieldCount);

            if (fieldCount == 0)
                throw new ArgumentException("Query didn't return reponse!");

            //IntPtr fields = mysql_fetch_fields(result);

            //var field = mysql_fetch_field(result);
            //var obj = (MySQLH.MYSQL_FIELD)Marshal.PtrToStructure(field, typeof(MySQLH.MYSQL_FIELD));
            //Debug.WriteLine(obj.GetType());

            //var Fields = (IntPtr[])MarshalArray(typeof(IntPtr), fields, (int)fieldCount);

            //var obj = (MySQLH.MYSQL_FIELD)Marshal.PtrToStructure(fields, typeof(MySQLH.MYSQL_FIELD));

            for (IntPtr ptrRow = mysql_fetch_row(result); ptrRow != IntPtr.Zero; ptrRow = mysql_fetch_row(result))
            {
                var Line = new List<string>();
                IntPtr[] mysqlRow = (IntPtr[])MarshalArray(typeof(IntPtr), ptrRow, (int)fieldCount);
                IntPtr ptrLengths = mysql_fetch_lengths(result);
                uint[] lengths = (uint[])MarshalArray(typeof(uint), ptrLengths, (int)fieldCount);
                for (int i = 0; i < (int)fieldCount; i++)
                {
                    var temp = new byte[(int)lengths[i]];
                    Marshal.Copy(mysqlRow[i], temp, 0, temp.Length);
                    var str = Encoding.UTF8.GetString(temp);
                    Debug.WriteLine(str);
                    Line.Add(str);
                }
                ResultList.Add(Line);
            }
            mysql_free_result(_MySQL);
            return ResultList;
        }
    }
}