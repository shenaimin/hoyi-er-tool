/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace ModelCode.Util
{
    public class TP_Util
    {
        /*
         
    // 摘要:
    //     指定要用于 System.Data.SqlClient.SqlParameter 中的字段和属性的 SQL Server 特定的数据类型。
    public enum SqlDbType
    {
        // 摘要:
        //     System.Int64.64 位带符号整数。
        BigInt = 0,
        //
        // 摘要:
        //     System.Byte 类型的 System.Array。二进制数据的固定长度流，范围在 1 到 8,000 个字节之间。
        Binary = 1,
        //
        // 摘要:
        //     System.Boolean.无符号数值，可以是 0、1 或 null。
        Bit = 2,
        //
        // 摘要:
        //     System.String.非 Unicode 字符的固定长度流，范围在 1 到 8,000 个字符之间。
        Char = 3,
        //
        // 摘要:
        //     System.DateTime.日期和时间数据，值范围从 1753 年 1 月 1 日到 9999 年 12 月 31 日，精度为 3.33 毫秒。
        DateTime = 4,
        //
        // 摘要:
        //     System.Decimal.固定精度和小数位数数值，在 -10 38 -1 和 10 38 -1 之间。
        Decimal = 5,
        //
        // 摘要:
        //     System.Double.-1.79E +308 到 1.79E +308 范围内的浮点数。
        Float = 6,
        //
        // 摘要:
        //     System.Byte 类型的 System.Array。二进制数据的可变长度流，范围在 0 到 2 31 -1（即 2,147,483,647）字节之间。
        Image = 7,
        //
        // 摘要:
        //     System.Int32.32 位带符号整数。
        Int = 8,
        //
        // 摘要:
        //     System.Decimal.货币值，范围在 -2 63（即 -922,337,203,685,477.5808）到 2 63 -1（即 +922,337,203,685,477.5807）之间，精度为千分之十个货币单位。
        Money = 9,
        //
        // 摘要:
        //     System.String.Unicode 字符的固定长度流，范围在 1 到 4,000 个字符之间。
        NChar = 10,
        //
        // 摘要:
        //     System.String.Unicode 数据的可变长度流，最大长度为 2 30 - 1（即 1,073,741,823）个字符。
        NText = 11,
        //
        // 摘要:
        //     System.String.Unicode 字符的可变长度流，范围在 1 到 4,000 个字符之间。如果字符串大于 4,000 个字符，隐式转换会失败。在使用比
        //     4,000 个字符更长的字符串时，请显式设置对象。
        NVarChar = 12,
        //
        // 摘要:
        //     System.Single.-3.40E +38 到 3.40E +38 范围内的浮点数。
        Real = 13,
        //
        // 摘要:
        //     System.Guid.全局唯一标识符（或 GUID）。
        UniqueIdentifier = 14,
        //
        // 摘要:
        //     System.DateTime.日期和时间数据，值范围从 1900 年 1 月 1 日到 2079 年 6 月 6 日，精度为 1 分钟。
        SmallDateTime = 15,
        //
        // 摘要:
        //     System.Int16.16 位的带符号整数。
        SmallInt = 16,
        //
        // 摘要:
        //     System.Decimal.货币值，范围在 -214,748.3648 到 +214,748.3647 之间，精度为千分之十个货币单位。
        SmallMoney = 17,
        //
        // 摘要:
        //     System.String.非 Unicode 数据的可变长度流，最大长度为 2 31 -1（即 2,147,483,647）个字符。
        Text = 18,
        //
        // 摘要:
        //     System.Byte 类型的 System.Array。自动生成的二进制数字，它们保证在数据库中是唯一的。timestamp 通常用作为表行添加版本戳的机制。存储大小为
        //     8 字节。
        Timestamp = 19,
        //
        // 摘要:
        //     System.Byte.8 位无符号整数。
        TinyInt = 20,
        //
        // 摘要:
        //     System.Byte 类型的 System.Array。二进制数据的可变长度流，范围在 1 到 8,000 个字节之间。如果字节数组大于 8,000
        //     个字节，隐式转换会失败。在使用比 8,000 个字节大的字节数组时，请显式设置对象。
        VarBinary = 21,
        //
        // 摘要:
        //     System.String.非 Unicode 字符的可变长度流，范围在 1 到 8,000 个字符之间。
        VarChar = 22,
        //
        // 摘要:
        //     System.Object.特殊数据类型，可以包含数值、字符串、二进制或日期数据，以及 SQL Server 值 Empty 和 Null，后两个值在未声明其他类型的情况下采用。
        Variant = 23,
        //
        // 摘要:
        //     XML 值。使用 System.Data.SqlClient.SqlDataReader.GetValue(System.Int32) 方法或 System.Data.SqlTypes.SqlXml.Value
        //     属性获取字符串形式的 XML，或通过调用 System.Data.SqlTypes.SqlXml.CreateReader() 方法获取 System.Xml.XmlReader
        //     形式的 XML。
        Xml = 25,
        //
        // 摘要:
        //     SQL Server 2005 用户定义的类型 (UDT)。
        Udt = 29,
        //
        // 摘要:
        //     指定表值参数中包含的构造数据的特殊数据类型。
        Structured = 30,
        //
        // 摘要:
        //     日期数据，值范围从公元 1 年 1 月 1 日到公元 9999 年 12 月 31 日。
        Date = 31,
        //
        // 摘要:
        //     基于 24 小时制的时间数据。时间值范围从 00:00:00 到 23:59:59.9999999，精度为 100 毫微秒。对应于 SQL Server
        //     time 值。
        Time = 32,
        //
        // 摘要:
        //     日期和时间数据。日期值范围从公元 1 年 1 月 1 日到公元 9999 年 12 月 31 日。时间值范围从 00:00:00 到 23:59:59.9999999，精度为
        //     100 毫微秒。
        DateTime2 = 33,
        //
        // 摘要:
        //     显示时区的日期和时间数据。日期值范围从公元 1 年 1 月 1 日到公元 9999 年 12 月 31 日。时间值范围从 00:00:00 到 23:59:59.9999999，精度为
        //     100 毫微秒。时区值范围从 -14:00 到 +14:00。
        DateTimeOffset = 34,
    }
         */
        /*
         
        // 摘要:
        //     System.Int64.64 位带符号整数。
        BigInt = 0,
        Binary = 1,
        Bit = 2,
        Char = 3,
        DateTime = 4,
        Decimal = 5,
        Float = 6,
        Image = 7,
        Int = 8,
        Money = 9,
        NChar = 10,
        NText = 11,
        NVarChar = 12,
        Real = 13,
        UniqueIdentifier = 14,
        SmallDateTime = 15,
        SmallInt = 16,
        SmallMoney = 17,
        Text = 18,
        Timestamp = 19,
        TinyInt = 20,
        VarBinary = 21,
        VarChar = 22,
        Variant = 23,
        Xml = 25,
        Udt = 29,
        Structured = 30,
        Date = 31,
        Time = 32,
        DateTime2 = 33,
        DateTimeOffset = 34,
         */

        /// <summary>
        /// 修改数据库类型.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dbtype"> 0 表示SQL 1表示mysql</param>
        /// <returns></returns>
        public static string TransDBType(string type, int dbtype)
        {
            string TP = ""; 

            switch (dbtype)
            {
                case 1:
                       TP = Enum.GetNames(typeof(SqlDbType)).ToList().Find(s => s.ToLower().Equals(type.ToLower()));
                       SqlDbType sqldtp = (SqlDbType)Enum.Parse(typeof(SqlDbType), TP);
                       return sqldtp.ToString();
                    
                case 2:
                       switch (type.ToLower())
                       {
                           case "int":
                               return MySqlDbType.Int32.ToString();
                           case "bigint":
                               return MySqlDbType.Int64.ToString();
                           default:
                               break;
                       }

                       TP = Enum.GetNames(typeof(MySqlDbType)).ToList().Find(s => s.ToLower().Equals(type.ToLower()));
                       MySqlDbType mysqldtp = (MySqlDbType)Enum.Parse(typeof(MySqlDbType), TP);
                       return mysqldtp.ToString();
                    
                default:
                    break;
            }
            return "";
        }

        public static string GetDBTYPEDLENGTH(string type, int dbtype, string Length)
        {
            switch (dbtype)
            {
                case 1: // SQL
                    break;
                case 2: // MYSQL

                    string str = Length;
                    switch (type)
                    {
                        case "int":
                            break;
                        case "number":
                            str = "4";
                            break;

                        case "varchar2":
                            if (!(Length == ""))
                            {
                                str = Length;
                                break;
                            }
                            str = "50";
                            break;

                        case "char":
                            if (!(Length == ""))
                            {
                                str = Length;
                                break;
                            }
                            str = "50";
                            break;

                        case "date":
                        case "nchar":
                        case "nvarchar2":
                        case "long":
                        case "long raw":
                        case "bfile":
                        case "blob":
                            break;

                        default:
                            break;
                    }
                    string pstr = TransDBType(type, dbtype) + "," + str;
                    return pstr;
                default:
                    break;
            }
            return "";
        }

        /// <summary>
        /// 将name按照parscal规则转换,首字母大写.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NameConvertParscal(string name)
        {
            if (name.Length > 0)
            {
                string firValue = name.Substring(0, 1).ToUpper();
                string otherValue = name.Substring(1, name.Length - 1);
                return firValue + otherValue;
            }
            else
            {
                return name;
            }
        }
        /// <summary>
        /// 将name按照parscal规则转换,首字母小写.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NameConvertCamel(string name)
        {
            if (name.Length > 0)
            {
                string firValue = name.Substring(0, 1).ToLower();
                string otherValue = name.Substring(1, name.Length - 1);
                return firValue + otherValue;
            }
            else
            {
                return name;
            }
        }
    }
}