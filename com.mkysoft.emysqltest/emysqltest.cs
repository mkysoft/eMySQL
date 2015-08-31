using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.mkysoft.emysql;
using System.Diagnostics;

namespace com.mkysoft.emysqltest
{
    [TestClass]
    public class com_mkysoft_emysqltest
    {
        [TestMethod]
        public void CreateDatabase()
        {
            try
            {
                var mysql = new eMySQL();

                string query = "CREATE DATABASE test;";
                mysql.ExecuteNoneQuery(query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void CreateTable()
        {
            try
            {
                var mysql = new eMySQL("test");

                string query = "CREATE TABLE test (c CHAR(20) CHARACTER SET utf8 COLLATE utf8_bin);";
                mysql.ExecuteNoneQuery(query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void DropTable()
        {
            try
            {
                var mysql = new eMySQL("test");

                string query = "DROP TABLE test;";
                mysql.ExecuteNoneQuery(query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void Select()
        {
            try
            {
                var mysql = new eMySQL();

                string query = "SHOW TABLES";
                query = "SELECT NOW(),CURDATE(),CURTIME()";

                Debug.WriteLine("Executing query: {0}", query);
                var result = mysql.ExecuteQuery(query);
                foreach (var item in result)
                    Debug.WriteLine(string.Join(",", item));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void SelectWithError()
        {
            try
            {
                var mysql = new eMySQL();
                string query = "SELECT NNOW()";

                Debug.WriteLine("Executing query: {0}", query);
                var result = mysql.ExecuteQuery(query);
                foreach (var item in result)
                    Debug.WriteLine(string.Join(",", item));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
