/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.appConf;
using Hoyi.conf;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.ctrl
{
    public class GeneralSQL
    {
        private static GeneralSQL _instance;

        public static GeneralSQL Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GeneralSQL();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AddDropTable"></param>
        /// <param name="AddYin"></param>
        /// <param name="AddEncode"></param>
        /// <param name="Encode"></param>
        /// <param name="AddComment"></param>
        /// <param name="AddEngine"></param>
        /// <param name="Engine"></param>
        /// <param name="AddPrefix"></param>
        /// <param name="AddSuffix"></param>
        /// <param name="modules">转换的模型.</param>
        /// <returns></returns>
        public string GenerSQL(
            bool QiangFPY, bool QiangDeleteFPY,
        bool AddFPY, bool DeleteFPY, bool AddCreateTable, bool RemoveFori, bool AddForiPre,
        bool AddDropTable, bool AddYin, bool AddEncode, string Encode,
        bool AddComment, bool AddEngine, string Engine, bool AddPrefix,
        bool AddSuffix, bool AddForien, List<ModuleInfo> modules
        )
        {
            string result = "";

            foreach (ModuleInfo mo in modules)
            {
                foreach (EntityInfo ent in mo.Entitys)
                {
                    if (AddDropTable)
                    {
                        result += "DROP TABLE IF EXISTS `" + (AddPrefix ? mo.Prefix : "") + ent.ClassName + (AddSuffix ? mo.Suffix : "") + "`;\n\n";
                    }
                    if (AddCreateTable)
                    {
                        result += "CREATE TABLE `" + (AddPrefix ? mo.Prefix : "") + ent.ClassName + (AddSuffix ? mo.Suffix : "") + "` (\n";
                        foreach (AttributeInfo att in ent.Attributes)
                        {
                            result += "     `" + att.ColumnName + "` " + att.TypeName + "(" + (att.TypeName.ToLower().Equals("decimal") ? att.Preci + ", " + att.Scale : att.Length) + ")";
                            result += att.cisNull ? " NULL " : " NOT NULL ";
                            result += att.DefaultVal == null ? "" :  " DEFAULT '" +  att.DefaultVal + "' ";
                            result += att.IsIdentity ? " AUTO_INCREMENT  " : " ";
                            result += AddComment ? " COMMENT '" + att.Comment + "' " : " ";
                            result += ",\n";
                        }
                        result = result.TrimEnd(",\n".ToArray());
                        foreach (AttributeInfo att in ent.Attributes)
                        {
                            result += att.IsPK ? ",\n    PRIMARY KEY (`" + att.ColumnName + "`)" : "";
                        }

                        result += "\n)";
                        result += AddEngine ? " ENGINE=" + Engine + " " : "";
                        result += AddEncode ? " DEFAULT CHARSET=" + Encode + " " : "";
                        result += AddComment ? " COMMENT='" + ent.EntityName + "' " : " ";
                        result += ";\n\n";
                    }
                    bool isneeddeletefpy = ent.NeedfpyTable;
                    isneeddeletefpy = (!isneeddeletefpy) ? isneeddeletefpy : DeleteFPY;
                    isneeddeletefpy = QiangDeleteFPY ? true : isneeddeletefpy;
                    if (isneeddeletefpy)
                    {
                        result += "DROP TABLE IF EXISTS `" + (AddPrefix ? mo.Prefix : "") + ent.ClassName + "_fpy" + (AddSuffix ? mo.Suffix : "") + "`;\n\n";
                    }
                    bool isneedfpy = ent.NeedfpyTable;
                    isneedfpy = (!isneedfpy) ? isneedfpy : AddFPY;
                    isneedfpy = QiangFPY ? true : isneedfpy;
                    if (isneedfpy)
                    {
                        result += "CREATE TABLE `" + (AddPrefix ? mo.Prefix : "") + ent.ClassName + "_fpy" + (AddSuffix ? mo.Suffix : "") + "` (\n";
                        foreach (AttributeInfo att in ent.Attributes)
                        {
                            result += "     `" + att.ColumnName + "` " + att.TypeName + "(" + (att.TypeName.ToLower().Equals("decimal") ? att.Preci + ", " + att.Scale : att.Length) + ")";
                            //result += att.cisNull ? " DEFAULT " + (att.DefaultVal == null ? "NULL " : att.DefaultVal) + " " : " NOT NULL ";
                            result += AddComment ? " COMMENT '" + att.Comment + "' " : " ";
                            result += ",\n";
                        }
                        result = result.TrimEnd(",\n".ToArray());

                        result += "\n)";
                        result += AddEngine ? " ENGINE=" + Engine + " " : "";
                        result += AddEncode ? " DEFAULT CHARSET=" + Encode + " " : "";
                        result += AddComment ? " COMMENT='" + ent.EntityName + "_FPY' " : " ";
                        result += ";\n\n";
                    }
                    if (AddForien)
                    {
                        foreach (ConstraintInfo cons in ent.constraints)
                        {
                            string srcTable = AddForiPre ? formConf.GetPrefixClassName(modules, ent.ClassName) : ent.ClassName;
                            string targetTable = AddForiPre ? formConf.GetPrefixClassName(modules, cons.REFERENCED_TABLE_NAME) : cons.REFERENCED_TABLE_NAME;
                            result += "alter table `" + srcTable + "` add constraint `" + cons.Constraint_name + "` foreign key(`" + cons.Column_Name + "`) REFERENCES  `" + targetTable + "` (`" + cons.REFERENCED_COLUMN_NAME + "`);\n\n";
                            //result += "    ,CONSTRAINT `" + cons.Constraint_name + "` FOREIGN KEY (`" + cons.Column_Name + "`) REFERENCES `" + cons.REFERENCED_TABLE_NAME + "` (`" + cons.REFERENCED_COLUMN_NAME + "`),\n";
                        }
                    }
                    if (RemoveFori)
                    {
                        foreach (ConstraintInfo cons in ent.constraints)
                        {
                            string srcTable = AddForiPre ? formConf.GetPrefixClassName(modules, ent.ClassName) : ent.ClassName;
                            string targetTable = AddForiPre ? formConf.GetPrefixClassName(modules, cons.REFERENCED_TABLE_NAME) : cons.REFERENCED_TABLE_NAME;
                            result += " ALTER TABLE `" +srcTable + "` DROP FOREIGN KEY `" +cons.Constraint_name +"`;\n";
                            //result += "alter table `" + srcTable + "` add constraint `" + cons.Constraint_name + "` foreign key(`" + cons.Column_Name + "`) REFERENCES  `" + targetTable + "` (`" + cons.REFERENCED_COLUMN_NAME + "`);\n\n";
                            //result += "    ,CONSTRAINT `" + cons.Constraint_name + "` FOREIGN KEY (`" + cons.Column_Name + "`) REFERENCES `" + cons.REFERENCED_TABLE_NAME + "` (`" + cons.REFERENCED_COLUMN_NAME + "`),\n";
                        }
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// 生成SQL 语句.
        /// </summary>
        /// <param name="AddDropTable"></param>
        /// <param name="AddYin"></param>
        /// <param name="AddEncode"></param>
        /// <param name="Encode"></param>
        /// <param name="AddComment"></param>
        /// <param name="AddEngine"></param>
        /// <param name="Engine"></param>
        /// <returns></returns>
        public string GenerSQL(
            bool QiangFPY, bool QiangDeleteFPY,
            bool AddFPY, bool DeleteFPY,
            bool AddCreateTable, bool RemoveFori, bool AddForiPre,
            bool AddDropTable, bool AddYin, bool AddEncode, string Encode,
            bool AddComment, bool AddEngine, string Engine, bool AddPrefix, 
            bool AddSuffix, bool AddForien
            )
        {
            return this.GenerSQL(QiangFPY, QiangDeleteFPY, AddFPY, DeleteFPY, AddCreateTable, RemoveFori, AddForiPre, AddDropTable, AddYin, AddEncode, Encode, AddComment, AddEngine, Engine, AddPrefix, AddSuffix, AddForien, AppConf.Ins.Application.Modules);
        }
    }
}
