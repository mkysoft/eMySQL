using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace com.mkysoft.emysql
{
    public class MySQLH
    {
        public enum mysql_option
        {
            MYSQL_OPT_CONNECT_TIMEOUT, MYSQL_OPT_COMPRESS, MYSQL_OPT_NAMED_PIPE,
            MYSQL_INIT_COMMAND, MYSQL_READ_DEFAULT_FILE, MYSQL_READ_DEFAULT_GROUP,
            MYSQL_SET_CHARSET_DIR, MYSQL_SET_CHARSET_NAME, MYSQL_OPT_LOCAL_INFILE,
            MYSQL_OPT_PROTOCOL, MYSQL_SHARED_MEMORY_BASE_NAME, MYSQL_OPT_READ_TIMEOUT,
            MYSQL_OPT_WRITE_TIMEOUT, MYSQL_OPT_USE_RESULT,
            MYSQL_OPT_USE_REMOTE_CONNECTION, MYSQL_OPT_USE_EMBEDDED_CONNECTION,
            MYSQL_OPT_GUESS_CONNECTION, MYSQL_SET_CLIENT_IP, MYSQL_SECURE_AUTH,
            MYSQL_REPORT_DATA_TRUNCATION, MYSQL_OPT_RECONNECT,
            MYSQL_OPT_SSL_VERIFY_SERVER_CERT, MYSQL_PLUGIN_DIR, MYSQL_DEFAULT_AUTH,
            MYSQL_OPT_BIND,
            MYSQL_OPT_SSL_KEY, MYSQL_OPT_SSL_CERT,
            MYSQL_OPT_SSL_CA, MYSQL_OPT_SSL_CAPATH, MYSQL_OPT_SSL_CIPHER,
            MYSQL_OPT_SSL_CRL, MYSQL_OPT_SSL_CRLPATH,
            MYSQL_OPT_CONNECT_ATTR_RESET, MYSQL_OPT_CONNECT_ATTR_ADD,
            MYSQL_OPT_CONNECT_ATTR_DELETE,
            MYSQL_SERVER_PUBLIC_KEY,
            MYSQL_ENABLE_CLEARTEXT_PLUGIN,
            MYSQL_OPT_CAN_HANDLE_EXPIRED_PASSWORDS
        };

        public enum enum_field_types
        {
            MYSQL_TYPE_DECIMAL, MYSQL_TYPE_TINY,
            MYSQL_TYPE_SHORT, MYSQL_TYPE_LONG,
            MYSQL_TYPE_FLOAT, MYSQL_TYPE_DOUBLE,
            MYSQL_TYPE_NULL, MYSQL_TYPE_TIMESTAMP,
            MYSQL_TYPE_LONGLONG, MYSQL_TYPE_INT24,
            MYSQL_TYPE_DATE, MYSQL_TYPE_TIME,
            MYSQL_TYPE_DATETIME, MYSQL_TYPE_YEAR,
            MYSQL_TYPE_NEWDATE, MYSQL_TYPE_VARCHAR,
            MYSQL_TYPE_BIT,
            MYSQL_TYPE_TIMESTAMP2,
            MYSQL_TYPE_DATETIME2,
            MYSQL_TYPE_TIME2,
            MYSQL_TYPE_NEWDECIMAL = 246,
            MYSQL_TYPE_ENUM = 247,
            MYSQL_TYPE_SET = 248,
            MYSQL_TYPE_TINY_BLOB = 249,
            MYSQL_TYPE_MEDIUM_BLOB = 250,
            MYSQL_TYPE_LONG_BLOB = 251,
            MYSQL_TYPE_BLOB = 252,
            MYSQL_TYPE_VAR_STRING = 253,
            MYSQL_TYPE_STRING = 254,
            MYSQL_TYPE_GEOMETRY = 255

        };

        [StructLayout(LayoutKind.Sequential)]
        public struct MYSQL_FIELD
        {
            public IntPtr name;                 /* Name of column */
            public IntPtr org_name;             /* Original column name, if an alias */
            public IntPtr table;                /* Table of column if column was a field */
            public IntPtr org_table;            /* Org table name, if table was an alias */
            public IntPtr db;                   /* Database for table */
            public IntPtr catalog;	             /* Catalog for table */
            public IntPtr def;                  /* Default value (set by mysql_list_fields) */
            public ulong length;                /* Width of column (create length) */
            public ulong max_length;            /* Max width for selected set */
            public uint name_length;
            public uint org_name_length;
            public uint table_length;
            public uint org_table_length;
            public uint db_length;
            public uint catalog_length;
            public uint def_length;
            public uint flags;             /* Div flags */
            public uint decimals;          /* Number of decimals in field */
            public uint charsetnr;         /* Character set */
            public enum_field_types type;  /* Type of field. See mysql_com.h for types */
            public IntPtr extension;
        }

    }
}
