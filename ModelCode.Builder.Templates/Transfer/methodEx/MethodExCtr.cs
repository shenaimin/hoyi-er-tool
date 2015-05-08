/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
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
using ModelCode.Util;
using ModelCode.Builder.Templates.SpecialTrans;
using System.Collections;
using ModelCode.ModelInfo;
using ModelCode.CreateBusiness;
using Hoyi.conf;
using ModelCode.Builder.Templates.Transfer.model;
using ModelCode.Builder.Templates.Field_CTR;
using ModelCode.Builder.Templates.ORM;
using ModelCode.Builder.Templates.Util;

namespace ModelCode.Builder.Templates.Transfer.methodEx
{
    /// <summary>
    /// 这里加入一些扩展方法的控制，例如某些扩展方法不能反射，某些
    /// </summary>
    public class MethodExCtr
    {
        private static MethodExCtr instance;
        public static MethodExCtr Create() {
            if (instance == null)
            {
                instance = new MethodExCtr();
            } 
            return instance;
        }
        /// <summary>
        /// 获取第一个可以用的Constraint.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ConstraintInfo get0c(EntityInfo ent)
        {
            var query = from m in ent.constraints
                        where m.Using
                        select m;

            return query.ToList().Count > 0 ? query.ToList()[0] : null;
        }
        /// <summary>
        /// 获取所有在用的外键.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public List<ConstraintInfo> geta(EntityInfo ent)
        {
            var query = from m in ent.constraints
                        where m.Using
                        select m;
            return query.ToList();
        }
        /// <summary>
        /// 内置方法，有些方法，可能反射不出来，就用内置方法解决。
        /// </summary>
        public List<String> InnerMethod = new List<string>();

        public MethodExCtr()
        {
            InitMethods();
        }

        public void InitMethods() {
            //if (InnerMethod.Count<=0)
            //{
            //    InnerMethod.Add("ToParscal");
            //    InnerMethod.Add("ToCamel");
            //}
        }
        /// <summary>
        /// 执行方法，返回内容.
        /// </summary>
        /// <param name="methodname"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Object Execute(string methodname, Object obj)
        {
            string tmp = "";
            List<AttributeInfo> columns = null;
            JavaTypeTrans tmpjttrans = null;
            IOperater tmpOp = null;
            EntityInfo tmpEntity = null;
            EntityInfo tmpEntity2 = null;
            ConstraintInfo tmpCos = null;
            AttributeInfo tmpAtt = null;

            string fieldPara = "";
            string valuesPara = "";
            string paraPara = "";
            string entiname = "";
            // calltemp_ 直接是最后一个方法.
            if (methodname.StartsWith("calltemp_"))
            {
                // 如果是调用模板方法，则启用模板执行事件，然后返回值。
                TemplateExTransfer extrans = new TemplateExTransfer();
                return extrans.Transfer(methodname, null, obj);
            }

            switch (methodname.ToLower())
            {
                case "contain_rela_uni":
                    return RELATION_METHOD_EX.Ins.Get_Relation_Constraint(obj as EntityInfo) != null;
                case "rela_uni_const":
                    return RELATION_METHOD_EX.Ins.Get_Relation_Constraint(obj as EntityInfo);
                case "rela_uni_tb":
                    /* 获取relation 关联中间的表. */
                    return RELATION_METHOD_EX.Ins.Get_Relation_Table(obj as EntityInfo);
                case "rela_uni_out_tb_name":
                    return RELATION_METHOD_EX.Ins.Get_Relation_OUT_Table(obj as EntityInfo).ClassName;
                case "rela_uni_out_tb":
                    return RELATION_METHOD_EX.Ins.Get_Relation_OUT_Table(obj as EntityInfo);
                case "rela_uni_in_field":
                    return RELATION_METHOD_EX.Ins.Get_Relation_Constraint(obj as EntityInfo).REFERENCED_COLUMN_NAME;
                case "rela_uni_out_tb_infield":
                    tmpEntity = obj as EntityInfo;
                    tmpEntity2 = RELATION_METHOD_EX.Ins.Get_Relation_OUT_Table(tmpEntity);
                    return RELATION_METHOD_EX.Ins.Get_Relation_Constraint(tmpEntity2).REFERENCED_COLUMN_NAME;
                case "needfpy":
                    return (obj as EntityInfo).NeedfpyTable;
                case "self_uni_constraint":
                    /* 获取自循环对象*/
                    return MethodExCTRL.Ins.GetSelfConstraint(obj as EntityInfo);
                case "self_uni_out_name":
                    /* 获取自循环的REF 字段名称 */
                    return MethodExCTRL.Ins.GetSelfCons_OUT_ColumnName(obj as EntityInfo);
                case "self_uni_in_name":
                    /* 获取自循环的主表 字段名称 */
                    return MethodExCTRL.Ins.GetSelfCons_IN_ColumnName(obj as EntityInfo);
                case "getselfconstraint":
                    /* 获取所有的外键. */
                    return geta(obj as EntityInfo);
                case "toentity":
                    // obj是表名,根据表名，获取这个表的实体.
                    return MethodExCTRL.Ins.RefByEntityName(obj);
                case "contain_uni":
                    /* 判断表内是否有外键. */
                    return geta(obj as EntityInfo).Count > 0;
                case "contain_unselfuni":
                    return MethodExCTRL.Ins.GetUN_SELF_CONSTRANIT(obj as EntityInfo) != null;
                case "unself_in_tb_name":
                    return MethodExCTRL.Ins.GetUN_SELF_CONSTRANIT(obj as EntityInfo).Table_Name;
                case "unself_in_field_name":
                    return MethodExCTRL.Ins.GetUN_SELF_CONSTRANIT(obj as EntityInfo).Column_Name;
                case "unself_out_tb_name":
                    return MethodExCTRL.Ins.GetUN_SELF_CONSTRANIT(obj as EntityInfo).REFERENCED_TABLE_NAME;
                case "unself_out_field_name":
                    return MethodExCTRL.Ins.GetUN_SELF_CONSTRANIT(obj as EntityInfo).REFERENCED_COLUMN_NAME;
                case "unself_out_tb":
                    return MethodExCTRL.Ins.RefByEntityName(MethodExCTRL.Ins.GetUN_SELF_CONSTRANIT(obj as EntityInfo).REFERENCED_TABLE_NAME);
                case "contain_selfuni":
                    return MethodExCTRL.Ins.GetSelfConstraint(obj as EntityInfo) != null;
                case "unikey_in_fieldname":
                    /* 获取第一个非自循环关联的自己的字段. */
                    return MethodExCTRL.Ins.GetConstraint(obj as EntityInfo).Column_Name;
                case "unikey_out_fieldname":
                    /* 获取第一个非自循环关联的关联表的表名. */
                    return MethodExCTRL.Ins.GetConstraint(obj as EntityInfo).REFERENCED_COLUMN_NAME;
                case "unikey_in_tb_name":
                    /* 获取第一个非自循环关联的自己的表名. */
                    return MethodExCTRL.Ins.GetConstraint(obj as EntityInfo).Table_Name;
                case "unikey_out_tb_name":
                    return MethodExCTRL.Ins.GetConstraint(obj as EntityInfo).REFERENCED_TABLE_NAME;
                case "en_unikey":
                    /* 返回实体内的非自循环外键. */
                    return MethodExCTRL.Ins.GetConstraint(obj as EntityInfo);
                case "e_uni_in_field":
                    /* 获取非自循环外键的主表对应的字段. */
                    tmpEntity = obj as EntityInfo;
                    fieldPara = MethodExCTRL.Ins.GetConstraint(obj as EntityInfo).Column_Name;
                    return tmpEntity.Attributes.Where(s => s.ColumnName.Equals(fieldPara)).ToList()[0];
                case "e_uni_out_field":
                    /* 获取外键的非自循环关联表对应的字段. */
                    tmpEntity = obj as EntityInfo;
                    tmpCos = MethodExCTRL.Ins.GetConstraint(obj as EntityInfo);
                    tmpEntity2 = AppConf.Ins.getEntiByEnname(tmpCos.REFERENCED_TABLE_NAME);
                    return tmpEntity2.Attributes.Where(s => s.ColumnName.Equals(tmpCos.REFERENCED_COLUMN_NAME)).ToList()[0];
                case "isunikey":
                    /* 是否是外键，是否有外键. */
                    if (obj is AttributeInfo)
                    {
                        tmpAtt = obj as AttributeInfo;
                        return AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).Count() > 0;
                    }
                    else if (obj is EntityInfo)
                    {
                        tmpEntity = obj as EntityInfo;
                        fieldPara = MethodExCTRL.Ins.GetConstraint(obj as EntityInfo).Column_Name;
                        tmpAtt = tmpEntity.Attributes.Where(s => s.ColumnName.Equals(fieldPara)).ToList()[0];
                        return AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).Count() > 0;
                    }
                    return "";
                case "unikey":
                    /* 返回第一个外键. */
                    if (obj is AttributeInfo)
                    {
                        tmpAtt = obj as AttributeInfo;
                        return AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0] as ConstraintInfo;
                    }
                    else if (obj is EntityInfo)
                    {
                        tmpEntity = obj as EntityInfo;
                        fieldPara = MethodExCTRL.Ins.GetConstraint(obj as EntityInfo).Column_Name;
                        tmpAtt = tmpEntity.Attributes.Where(s => s.ColumnName.Equals(fieldPara)).ToList()[0];
                        return AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0] as ConstraintInfo;
                    }
                    return "";
                case "unienti":
                    /* 返回字段外键的表 */
                    if (obj is AttributeInfo)
                    {
                        tmpAtt = obj as AttributeInfo;
                        entiname = AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0].REFERENCED_TABLE_NAME;
                        return AppConf.Ins.getEntiByEnname(entiname);
                    }
                    else if (obj is EntityInfo)
                    {
                        tmpEntity = obj as EntityInfo;
                        fieldPara = get0c(tmpEntity).Column_Name;
                        tmpAtt = tmpEntity.Attributes.Where(s => s.ColumnName.Equals(fieldPara)).ToList()[0];
                        entiname = AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0].REFERENCED_TABLE_NAME;
                        return AppConf.Ins.getEntiByEnname(entiname);
                    }
                    return "";
                case "uni1field":
                    /* 返回字段外键的表的第一个字段 */
                    if (obj is AttributeInfo)
                    {
                        tmpAtt = obj as AttributeInfo;
                        entiname = AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0].REFERENCED_TABLE_NAME;
                        return AppConf.Ins.getEntiByEnname(entiname).Attributes[0];
                    }
                    else if (obj is EntityInfo)
                    {
                        tmpEntity = obj as EntityInfo;
                        fieldPara = get0c(tmpEntity).Column_Name;
                        tmpAtt = tmpEntity.Attributes.Where(s => s.ColumnName.Equals(fieldPara)).ToList()[0];
                        entiname = AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0].REFERENCED_TABLE_NAME;
                        return AppConf.Ins.getEntiByEnname(entiname).Attributes[0];
                    }
                    else
                    {
                        return "";
                    }
                case "uni2field":
                    /* 返回字段外键的表的第二个字段 */
                    if (obj is AttributeInfo)
                    {
                        tmpAtt = obj as AttributeInfo;
                        entiname = AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0].REFERENCED_TABLE_NAME;
                        return AppConf.Ins.getEntiByEnname(entiname).Attributes[1];
                    }
                    else if (obj is EntityInfo)
                    {
                        tmpEntity = obj as EntityInfo;
                        fieldPara = get0c(tmpEntity).Column_Name;
                        tmpAtt = tmpEntity.Attributes.Where(s => s.ColumnName.Equals(fieldPara)).ToList()[0];
                        entiname = AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0].REFERENCED_TABLE_NAME;
                        return AppConf.Ins.getEntiByEnname(entiname).Attributes[1];
                    }
                    else
                    {
                        return "";
                    }
                case "toparscal":
                    return obj.ToString().ToParscal();
                case "tocamel":
                    return obj.ToString().ToCamel();
                case "tojavapackclass":
                    return new JavaTypeTrans().MariaToJavaPackagedClass(obj.ToString());
                case "tojavaunpackclass":
                    return new JavaTypeTrans().MariaToJavaUnPackagedClass(obj.ToString());
                case "tocstype":
                    return new CSharpTypeTrans().MariaToCSUnPackagedClass(obj.ToString());
                case "tocspaktype":
                    return new CSharpTypeTrans().MariaToCSPackagedClass(obj.ToString());
                case "now":
                    return DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                case "tourl":
                    return obj.ToString().Replace('.', '/');
                case "getfirfield":
                    return ((EntityInfo)obj).Attributes[0];
                case "getsecfield":
                    return ((EntityInfo)obj).Attributes[1];
                case "getfirfieldname":
                    return  ((EntityInfo)obj).Attributes[0].ColumnName;
                case "getsecfieldname":
                    return ((EntityInfo)obj).Attributes[1].ColumnName;
                case "gettablecols":
                    return (((EntityInfo)obj).Attributes.Count + 2).ToString();
                case "addonecols":
                    return (((EntityInfo)obj).Attributes.Count + 1).ToString();
                case "add3cols":
                    return (((EntityInfo)obj).Attributes.Count + 3).ToString();
                case "dbattr":
                    return DbAttrUtil.GOTColumnDBAttr(obj);
                case "dbjavaattr":
                    return DbAttrUtil.GOTColumnJAVADBAttr(obj);
                case "and":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }

                    if (columns.Count == 1)
                    {
                        return columns[0].ColumnName;
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += col.ColumnName + "And";
                        }

                        return tmp.TrimEnd("And".ToArray());
                    }
                case "andpar":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }

                    if (columns.Count == 1)
                    {
                        return columns[0].ColumnName.ToParscal();
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += col.ColumnName.ToParscal() + "And";
                        }

                        return tmp.TrimEnd("And".ToArray());
                    }
                case "andtoparam":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return tmpjttrans.MariaToJavaPackagedClass(columns[0].TypeName) + " _" + columns[0].ColumnName;
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += tmpjttrans.MariaToJavaPackagedClass(col.TypeName) + " _" + col.ColumnName + "And";
                        }

                        return tmp.TrimEnd("And".ToArray());
                    }
                case "anddouhaoparam":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return tmpjttrans.MariaToJavaPackagedClass(columns[0].TypeName) + " _" + columns[0].ColumnName;
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += tmpjttrans.MariaToJavaPackagedClass(col.TypeName) + " _" + col.ColumnName + ",";
                        }

                        return tmp.TrimEnd(",".ToArray());
                    }
                case "anddoustrparam":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return "String  _" + columns[0].ColumnName;
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += "String  _" + col.ColumnName + ", ";
                        }

                        return tmp.TrimEnd(", ".ToArray());
                    }
                case "anddoustrparamcs":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return "string  _" + columns[0].ColumnName;
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += "string  _" + col.ColumnName + ", ";
                        }

                        return tmp.TrimEnd(", ".ToArray());
                    }
                case "anddengwen":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return " " + columns[0].ColumnName + " = ? ";
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += " " + col.ColumnName + " = ? and ";
                        }

                        return tmp.TrimEnd("and ".ToArray());
                    }

                case "anddou":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return " " + columns[0].ColumnName + ", ";
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += " " + col.ColumnName + ",";
                        }

                        return tmp.TrimEnd(",".ToArray());
                    }
                case "anddouparam":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return "_" + columns[0].ColumnName + "";
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += "_" + col.ColumnName + ", ";
                        }

                        return tmp.TrimEnd(", ".ToArray());
                    }
                case "todengyu":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = getColumns(tmpOp, tmpEntity);
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    tmpjttrans = new JavaTypeTrans();

                    if (columns.Count == 1)
                    {
                        return "this." + columns[0].ColumnName + " = _" + columns[0].ColumnName + ";";
                    }
                    else
                    {
                        foreach (AttributeInfo col in columns)
                        {
                            tmp += "this." + col.ColumnName + " = _" + col.ColumnName + ";\n\t\t\t";
                        }

                        return tmp.TrimEnd("\n\t\t\t".ToArray());
                    }
                case "insertallcmd":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = tmpEntity.Attributes;
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    foreach (AttributeInfo col in columns)
                    {
                        fieldPara += col.ColumnName + ", ";
                        valuesPara += "?, ";
                        paraPara += "_" + tmpEntity.EntityName + ".get" + col.ColumnName + "(), ";
                    }
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());
                    valuesPara = valuesPara.TrimEnd(", ".ToArray());
                    paraPara = paraPara.TrimEnd(", ".ToArray());

                    string insertcmd = "String cmd = \"insert into " + tmpEntity.EntityName + " (" + fieldPara + ") values (" + valuesPara + ")\";\n\t\t" +
                                   "String[] params = new String[]{ " + paraPara + " };";

                    return insertcmd;

                case "insertunidcmd":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = tmpEntity.Attributes;
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    int xi = 0;
                    foreach (AttributeInfo col in columns)
                    {
                        if (xi > 0)
                        {
                            fieldPara += col.ColumnName + ", ";
                            valuesPara += "?, ";
                            paraPara += "_" + tmpEntity.EntityName + ".get" + col.ColumnName + "(), ";
                        }
                        xi++;
                    }
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());
                    valuesPara = valuesPara.TrimEnd(", ".ToArray());
                    paraPara = paraPara.TrimEnd(", ".ToArray());

                    string insertunidcmd = "String cmd = \"insert into " + tmpEntity.EntityName + " (" + fieldPara + ") values (" + valuesPara + ")\";\n\t\t" +
                                   "String[] params = new String[]{ " + paraPara + " };";

                    return insertunidcmd;

                case "updatebyidcmd":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = tmpEntity.Attributes;
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }

                    foreach (AttributeInfo col in tmpEntity.Attributes)
                    {
                        fieldPara += col.ColumnName + " = ?, ";
                        valuesPara += "_" + tmpEntity.EntityName + ".get" + col.ColumnName + "(), ";
                    }

                    paraPara += tmpEntity.Attributes[0].ColumnName + " = ? ";
                    valuesPara += "_" + tmpEntity.EntityName + ".get" + tmpEntity.Attributes[0].ColumnName + "() ";
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());

                    string updatebyidcmd = "String cmd = \"update " + tmpEntity.EntityName + " set " + fieldPara + " where " + paraPara + "\";\n\t\t";
                    updatebyidcmd += "String[] params = new String[]{  " + valuesPara + " };";

                    return updatebyidcmd;
                case "updateunidcmd":
                    if (obj is IOperater)
                    {
                        tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                        columns = tmpEntity.Attributes;
                    }
                    else
                    {
                        columns = obj as List<AttributeInfo>;
                    }
                    int sxxi = 0;

                    foreach (AttributeInfo col in tmpEntity.Attributes)
                    {
                        if (sxxi > 0)
                        {
                            fieldPara += col.ColumnName + " = ?, ";
                            valuesPara += "_" + tmpEntity.EntityName + ".get" + col.ColumnName + "(), ";
                        }
                        sxxi++;
                    }

                    paraPara += tmpEntity.Attributes[0].ColumnName + " = ? ";
                    valuesPara += "_" + tmpEntity.EntityName + ".get" + tmpEntity.Attributes[0].ColumnName + "() ";
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());

                    string updateunidcmd = "String cmd = \"update " + tmpEntity.EntityName + " set " + fieldPara + " where " + paraPara + "\";\n\t\t";
                    updateunidcmd += "String[] params = new String[]{  " + valuesPara + " };";

                    return updateunidcmd;

                case "likecount":
                    tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                    foreach (AttributeInfo col in getColumns(tmpOp, tmpEntity))
                    {
                        fieldPara += "_" + col.ColumnName + ", ";
                        valuesPara += " " + col.ColumnName + " like %?% and ";
                    }
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());
                    valuesPara = valuesPara.TrimEnd("and ".ToArray());

                    string likecount = "String cmd = \"select count(" + tmpEntity.Attributes[0].ColumnName + ") as count from " + tmpEntity.EntityName + " where " + valuesPara + "\";\n\t\t" +
                                        " String[] params = new String[]{  " + fieldPara + "   };";

                    return likecount;
                case "likers":

                    tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                    foreach (AttributeInfo col in getColumns(tmpOp, tmpEntity))
                    {
                        fieldPara += "_" + col.ColumnName + ", ";
                        valuesPara += " " + col.ColumnName + " like %?% and ";
                    }
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());
                    valuesPara = valuesPara.TrimEnd("and ".ToArray());

                    string likers = "String cmd = \"select * from " + tmpEntity.EntityName + " where " + valuesPara + " limit \" + info.getLimitIndex() + \",\" +info.getPageSize() + \" order by \"+ info.getOrder();\n\t\t" +
                                    "String[] params = new String[]{  " + fieldPara + "   };";

                    return likers;

                case "getbycount":
                    tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                    foreach (AttributeInfo col in getColumns(tmpOp, tmpEntity))
                    {
                        fieldPara += "_" + col.ColumnName + ", ";
                        valuesPara += " " + col.ColumnName + " = ? and ";
                    }
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());
                    valuesPara = valuesPara.TrimEnd("and ".ToArray());


                    string getbycount = "String cmd = \"select count(" + tmpEntity.Attributes[0].ColumnName + ") as count from " + tmpEntity.EntityName + " where " + valuesPara + "\";\n\t\t" +
                                    "String[] params = new String[]{  " + fieldPara + "   };";

                    return getbycount;

                case "getby":

                    tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                    foreach (AttributeInfo col in getColumns(tmpOp, tmpEntity))
                    {
                        fieldPara += "_" + col.ColumnName + ", ";
                        valuesPara += " " + col.ColumnName + " = ? and ";
                    }
                    fieldPara = fieldPara.TrimEnd(", ".ToArray());
                    valuesPara = valuesPara.TrimEnd("and ".ToArray());

                    string getby = "String cmd = \"select * from " + tmpEntity.EntityName + " where " + valuesPara + " limit \" + info.getLimitIndex() + \",\" +info.getPageSize() + \" order by \"+ info.getOrder();\n\t\t" +
                                    "String[] params = new String[]{  " + fieldPara + "   };";

                    return getby;

                case "allcount":
                    tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                    return "String cmd = \"select count(" + tmpEntity.Attributes[0].ColumnName + ") as count from " + tmpEntity.EntityName + " \";\n\t\t";
                case "allby":

                    tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                    return "String cmd = \"select * from " + tmpEntity.EntityName + " \";\n\t\t";
                case "simpleenti":

                    tmpOp = obj as IOperater;
                        tmpEntity = AppConf.Ins.CurrentExeEntity;

                    foreach (AttributeInfo col in getColumns(tmpOp, tmpEntity))
                    {
                        fieldPara += col.ColumnName.ToParscal() + "And";
                        valuesPara += "_" + col.ColumnName + ", ";
                    }
                    fieldPara = fieldPara.Substring(0, fieldPara.Length - 3);
                    valuesPara = valuesPara.Substring(0, valuesPara.Length - 2);

                    string simpleenti = "        info.setOrder(" + tmpEntity.EntityName.ToParscal() + ".F_" + tmpEntity.Attributes[0].ColumnName + ");     \n\n" +
                                        "        return this.GetBy" + fieldPara + "(" + valuesPara + ", info).get(0);";
                    return simpleenti;
                default:
                    break;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="modelinfo"></param>
        /// <returns></returns>
        public List<AttributeInfo> getColumns(IOperater op, EntityInfo modelinfo)
        {
            List<AttributeInfo> columns = new List<AttributeInfo>();
            foreach (int i in op.FieldIndex)
            {
                columns.Add(modelinfo.Attributes[i]);
            }
            return columns;
        }

    }
}
