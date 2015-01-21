/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
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
using System.Data.SqlClient;
using ModelCode.Model;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using ModelCode.ModelInfo;
using Hoyi.appConf;

namespace ModelCode.Controll
{
    public class GetObjectHelper
    {
        /// <summary>
        /// 获取数据库列表.
        /// </summary>
        /// <returns></returns>
        public List<string> GetDataBaseName(DBTYPE dbtype)
        {
            switch (dbtype)
            {
                case DBTYPE.UNKNOW:
                    break;
                case DBTYPE.SQLSERVER:
                    using (SqlConnection conn = new SqlConnection(formConf.connectionString))
                    {
                        conn.Open();
                        List<string> nameList = new List<string>();
                        string cmdText = "select [name] from sys.databases where snapshot_isolation_state = 0";
                        SqlCommand cmd = new SqlCommand(cmdText, conn);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nameList.Add(dr["name"].ToString());
                            }
                        }
                        return nameList;
                    }
                case DBTYPE.MYSQL_MARIADB:
                    using (MySqlConnection conn = new MySqlConnection(formConf.connectionString))
                    {
                        conn.Open();
                        List<string> nameList = new List<string>();
                        string cmdText = "SELECT `SCHEMA_NAME` FROM `information_schema`.`SCHEMATA`SCHEMATA";
                        MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                nameList.Add(dr["SCHEMA_NAME"].ToString());
                            }
                        }
                        return nameList;
                    }
                case DBTYPE.ORACLE:
                    break;
                default:
                    break;
            }
            return null;
        }
        /// <summary>
        /// 获取数据库表集合.
        /// </summary>
        /// <returns></returns>
        public List<EntityInfo> GetTables(DBTYPE dbtype, string database)
        {
            switch (dbtype)
            {
                case DBTYPE.UNKNOW:
                    break;
                case DBTYPE.SQLSERVER:
                    if (formConf.connectionString.Contains("Database=tempdb"))
                        return new List<EntityInfo>();
                    using (SqlConnection conn = new SqlConnection(formConf.connectionString))
                    {
                        conn.Open();

                        List<EntityInfo> tables = new List<EntityInfo>();
                        string cmdText = "select * from sys.tables";
                        SqlCommand cmd = new SqlCommand(cmdText, conn);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EntityInfo table = new EntityInfo();
                                table.EntityName = table.ClassName = dr["name"].ToString();
                                table.CreateDate = dr["create_date"].ToString();

                                if (table.ClassName != "sysdiagrams")      //数据库关系图自动生成的表
                                    tables.Add(table);
                            }
                        }
                        return tables;
                    }
                case DBTYPE.MYSQL_MARIADB:
                    if (formConf.connectionString.Contains("Database=information_schema") || formConf.connectionString.Contains("Database=performance_schema"))
                            return new List<EntityInfo>();
                    using (MySqlConnection conn = new MySqlConnection(formConf.connectionString))
                        {
                            conn.Open();

                            List<EntityInfo> tables = new List<EntityInfo>();
                            string cmdText = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + database + "'";
                            MySqlCommand cmd = new MySqlCommand(cmdText, conn);

                            using (MySqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    EntityInfo table = new EntityInfo();
                                    table.ClassName = dr["TABLE_NAME"].ToString();
                                    table.EntityName = dr["TABLE_COMMENT"].ToString().Length > 0 ? dr["TABLE_COMMENT"].ToString() : dr["TABLE_NAME"].ToString();

                                    if (table.ClassName != "sysdiagrams")      //数据库关系图自动生成的表
                                        tables.Add(table);
                                }
                            }
                            return tables;
                        }
                case DBTYPE.ORACLE:
                    break;
                default:
                    break;
            }
            return null;
        }
        /// <summary>
        /// 获取单表列的集合.
        /// </summary>
        /// <param name="table_Schema">数据库名.</param>
        /// <param name="tableID">表名.</param>
        /// <param name="dbtype"></param>
        /// <returns></returns>
        public List<AttributeInfo> GetTableFields(string tableID, DBTYPE dbtype, string table_Schema)
        {
            switch (dbtype)
            {
                case DBTYPE.UNKNOW:
                    break;
                case DBTYPE.SQLSERVER:

                    using (SqlConnection conn = new SqlConnection(formConf.connectionString))
                    {
                        conn.Open();

                        List<AttributeInfo> columns = new List<AttributeInfo>();
                        string cmdText = "SELECT  *,syscolumns.length as max_length,systypes.name as typeName FROM  syscolumns, systypes WHERE  syscolumns.xusertype  =  systypes.xusertype AND  syscolumns.id  =   '" + tableID + "'";

                        SqlCommand cmd = new SqlCommand(cmdText, conn);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                AttributeInfo column = new AttributeInfo();

                                column.cisNull = Convert.ToBoolean(dr["isnullable"]);
                                column.ColumnName = dr["name"].ToString();
                                //column.DefaultVal
                                //column.DeText
                                //column.IsIdentity = Convert.ToBoolean(dr["is_identity"]);
                                //column.IsPK
                                //column.Length = dr["max_length"].ToString();
                                column.Length = dr["length"].ToString();
                                column.Preci = dr["prec"].ToString();
                                column.Scale = dr["scale"].ToString();
                                column.TypeName = dr["typeName"].ToString();

                                columns.Add(column);
                            }
                        }
                        return columns;
                    }
                case DBTYPE.MYSQL_MARIADB:
                    //string strcc =  formConf.connectionString.Replace(table_Schema, "information_schema");
                    using (MySqlConnection conn = new MySqlConnection(formConf.connectionString))
                    {
                        conn.Open();

                        List<AttributeInfo> columns = new List<AttributeInfo>();
                        //string cmdText = "show columns from " + tableID;
                        string cmdText = "SHOW FULL FIELDS from " + tableID;
           //string cmdText = "select * from COLUMNS where table_schema='" + table_Schema + "' and table_name='" + tableID + "'";
                        //string cmdText = "SELECT  *,syscolumns.length as max_length,systypes.name as typeName FROM  syscolumns, systypes WHERE  syscolumns.xusertype  =  systypes.xusertype AND  syscolumns.id  =   ' " + tableID + "'";

                        MySqlCommand cmd = new MySqlCommand(cmdText, conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
//  use information_schema;
//  SELECT TABLE_NAME '表名',ORDINAL_POSITION '顺序',COLUMN_NAME '字段',DATA_TYPE '类型'
//       ,CHARACTER_OCTET_LENGTH '字节长',if(COLUMN_KEY='PRI',"√","") '主键',if(EXTRA='auto_increment',"√","") '自增长'
//       ,if(IS_NULLABLE='YES',"√","") '空',CHARACTER_SET_NAME '编码',COLUMN_DEFAULT '默认值',COLUMN_COMMENT '说明'
//  FROM COLUMNS WHERE TABLE_SCHEMA = 'webmanagesystem' ORDER BY TABLE_NAME,ORDINAL_POSITION;

                                AttributeInfo column = new AttributeInfo();

                                column.ColumnName = dr["Field"].ToString();
                                column.TypeName = dr["Type"].ToString();
                                
                                Regex r = new Regex(@"\d+");
                                Regex r1 = new Regex(@"\w+");

                                column.TypeName = r1.Match(dr["Type"].ToString()).Value;
                                column.Length = r.Match(dr["Type"].ToString()).Value;
                                column.Collation = dr["Collation"].ToString();
                                column.cisNull = dr["Null"].ToString().ToUpper().Equals("YES");

                                column.IsPK = dr["KEY"].ToString().Equals("PRI");
                                //column.IsUnique = dr["IsUnique"].ToString();

                                column.Extra = dr["Extra"].ToString();
                                column.IsIdentity = column.Extra == "auto_increment";

                                column.Comment = dr["Comment"].ToString().Length > 0 ? dr["Comment"].ToString() : dr["Field"].ToString();

                                string fdd = dr["Type"].ToString();

                                string lll = fdd.Split('(')[1];
                                if (lll.Contains(','))
                                {
                                    column.Preci = lll.TrimEnd(')').Split(',')[0];
                                    column.Scale = lll.TrimEnd(')').Split(',')[1];
                                }

                                columns.Add(column);
                            }
                        }
                        return columns;
                    }
                case DBTYPE.ORACLE:
                    break;
                default:
                    break;
            }
            return null;
        }
        /// <summary>
        /// 返回外键，主键不在这里返回.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbtype"></param>
        /// <param name="table_schema"></param>
        /// <returns></returns>
        public List<ConstraintInfo> GetConstaint(string tableName, DBTYPE dbtype, string table_schema)
        {
            List<ConstraintInfo> constrains = new List<ConstraintInfo>();
            switch (dbtype)
            {
                case DBTYPE.UNKNOW:
                    break;
                case DBTYPE.SQLSERVER:
                    return null;
                    
                case DBTYPE.MYSQL_MARIADB:
                    using (MySqlConnection conn = new MySqlConnection(formConf.connectionString))
                    {
                        conn.Open();
                        string cmdText = "select * from INFORMATION_SCHEMA.KEY_COLUMN_USAGE  where TABLE_NAME='" + tableName + "' and CONSTRAINT_NAME !='PRIMARY'";
                        MySqlCommand cmd = new MySqlCommand(cmdText, conn);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ConstraintInfo constraint = new ConstraintInfo();

                                constraint.Constraint_catalog = dr["CONSTRAINT_CATALOG"].ToString();
                                constraint.Constraint_schema = dr["CONSTRAINT_SCHEMA"].ToString();
                                constraint.Constraint_name = dr["CONSTRAINT_NAME"].ToString();
                                constraint.Table_Catalog = dr["TABLE_CATALOG"].ToString();
                                constraint.Table_Schema = dr["TABLE_SCHEMA"].ToString();
                                constraint.Table_Name = dr["TABLE_NAME"].ToString();
                                constraint.Column_Name = dr["COLUMN_NAME"].ToString();
                                constraint.ORDINAL_POSITION = dr["ORDINAL_POSITION"].ToString();
                                constraint.POSITION_IN_UNIQUE_CONSTRAINT = dr["POSITION_IN_UNIQUE_CONSTRAINT"].ToString();
                                constraint.REFERENCED_TABLE_SCHEMA = dr["REFERENCED_TABLE_SCHEMA"].ToString();
                                constraint.REFERENCED_TABLE_NAME = dr["REFERENCED_TABLE_NAME"].ToString();
                                constraint.REFERENCED_COLUMN_NAME = dr["REFERENCED_COLUMN_NAME"].ToString();

                                constrains.Add(constraint);
                            }
                        }
                        return constrains;
                    }
                case DBTYPE.ORACLE:
                    break;
                default:
                    break;
            }
            return constrains;
        }
    }
}