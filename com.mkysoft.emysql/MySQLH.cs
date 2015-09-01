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

        public enum enum_charset_types : uint
        {
            armscii8_bin = 64,
            armscii8_general_ci = 32,
            ascii_bin = 65,
            ascii_general_ci = 11,
            big5_bin = 84,
            big5_chinese_ci = 1,
            binary = 63,
            cp1250_bin = 66,
            cp1250_croatian_ci = 44,
            cp1250_czech_cs = 34,
            cp1250_general_ci = 26,
            cp1251_bin = 50,
            cp1251_bulgarian_ci = 14,
            cp1251_general_cs = 52,
            cp1251_ukrainian_ci = 23,
            cp1251_general_ci = 51,
            cp1256_bin = 67,
            cp1256_general_ci = 57,
            cp1257_bin = 58,
            cp1257_lithuanian_ci = 29,
            cp1257_general_ci = 59,
            cp850_bin = 80,
            cp850_general_ci = 4,
            cp852_bin = 81,
            cp852_general_ci = 40,
            cp866_bin = 68,
            cp866_general_ci = 36,
            cp932_bin = 96,
            cp932_japanese_ci = 95,
            dec8_bin = 69,
            dec8_swedish_ci = 3,
            eucjpms_bin = 98,
            eucjpms_japanese_ci = 97,
            euckr_bin = 85,
            euckr_korean_ci = 19,
            gb2312_bin = 86,
            gb2312_chinese_ci = 24,
            gbk_bin = 87,
            gbk_chinese_ci = 28,
            geostd8_bin = 93,
            geostd8_general_ci = 92,
            greek_bin = 70,
            greek_general_ci = 25,
            hebrew_bin = 71,
            hebrew_general_ci = 16,
            hp8_bin = 72,
            hp8_english_ci = 6,
            keybcs2_bin = 73,
            keybcs2_general_ci = 37,
            koi8r_bin = 74,
            koi8r_general_ci = 7,
            koi8u_bin = 75,
            koi8u_general_ci = 22,
            latin1_bin = 47,
            latin1_danish_ci = 15,
            latin1_general_ci = 48,
            latin1_general_cs = 49,
            latin1_german1_ci = 5,
            latin1_german2_ci = 31,
            latin1_spanish_ci = 94,
            latin1_swedish_ci = 8,
            latin2_bin = 77,
            latin2_croatian_ci = 27,
            latin2_czech_cs = 2,
            latin2_hungarian_ci = 21,
            latin2_general_ci = 9,
            latin5_bin = 78,
            latin5_turkish_ci = 30,
            latin7_bin = 79,
            latin7_estonian_cs = 20,
            latin7_general_cs = 42,
            latin7_general_ci = 41,
            macce_bin = 43,
            macce_general_ci = 38,
            macroman_bin = 53,
            macroman_general_ci = 39,
            sjis_bin = 88,
            sjis_japanese_ci = 13,
            swe7_bin = 82,
            swe7_swedish_ci = 10,
            tis620_bin = 89,
            tis620_thai_ci = 18,
            ucs2_bin = 90,
            ucs2_czech_ci = 138,
            ucs2_danish_ci = 139,
            ucs2_esperanto_ci = 145,
            ucs2_estonian_ci = 134,
            ucs2_hungarian_ci = 146,
            ucs2_icelandic_ci = 129,
            ucs2_latvian_ci = 130,
            ucs2_lithuanian_ci = 140,
            ucs2_persian_ci = 144,
            ucs2_polish_ci = 133,
            ucs2_romanian_ci = 131,
            ucs2_roman_ci = 143,
            ucs2_slovak_ci = 141,
            ucs2_slovenian_ci = 132,
            ucs2_spanish2_ci = 142,
            ucs2_spanish_ci = 135,
            ucs2_swedish_ci = 136,
            ucs2_turkish_ci = 137,
            ucs2_unicode_ci = 128,
            ucs2_general_ci = 35,
            ujis_bin = 91,
            ujis_japanese_ci = 12,
            utf8_bin = 83,
            utf8_czech_ci = 202,
            utf8_danish_ci = 203,
            utf8_esperanto_ci = 209,
            utf8_estonian_ci = 198,
            utf8_hungarian_ci = 210,
            utf8_icelandic_ci = 193,
            utf8_latvian_ci = 194,
            utf8_lithuanian_ci = 204,
            utf8_persian_ci = 208,
            utf8_polish_ci = 197,
            utf8_romanian_ci = 195,
            utf8_roman_ci = 207,
            utf8_slovak_ci = 205,
            utf8_slovenian_ci = 196,
            utf8_spanish2_ci = 206,
            utf8_spanish_ci = 199,
            utf8_swedish_ci = 200,
            utf8_turkish_ci = 201,
            utf8_unicode_ci = 192,
            utf8_general_ci = 33
        }

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
            string name;                 /* Name of column */
            string org_name;             /* Original column name, if an alias */
            string table;                /* Table of column if column was a field */
            string org_table;            /* Org table name, if table was an alias */
            string db;                   /* Database for table */
            string catalog;	             /* Catalog for table */
            string def;                  /* Default value (set by mysql_list_fields) */
            uint length;                 /* Width of column (create length) */
            uint max_length;             /* Max width for selected set */
            uint name_length;
            uint org_name_length;
            uint table_length;
            uint org_table_length;
            uint db_length;
            uint catalog_length;
            uint def_length;
            uint flags;                  /* Div flags */
            uint decimals;               /* Number of decimals in field */
            enum_charset_types charset;  /* Character set */
            //uint charsetnr;            /* Character set */
            enum_field_types type;       /* Type of field. See mysql_com.h for types */
            IntPtr extension;
        }

    }
}
