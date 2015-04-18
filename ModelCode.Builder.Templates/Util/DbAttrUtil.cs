/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelCode.Util;

namespace ModelCode.Builder.Templates.Util
{
    public class DbAttrUtil
    {
        /// <summary>
        /// 获取列的描述.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GOTColumnDBAttr(object obj)
        { 

        //[DbAttr(datatype.Bigint, 20, isPK= false, Identity=false, Comment = "规格编号", FieldName = "standid",Prefix=12, suffix=21)]

            AttributeInfo atts = obj as AttributeInfo;
            string dbattr = "";
            dbattr += "[DbAttr(datatype." + atts.TypeName.ToParscal() + ", " + atts.Length + ",";
            dbattr += " Comment = \"" + ((atts.Comment != null && atts.Comment.Trim().Length > 0) ? atts.Comment : atts.ColumnName) + "\",";
            dbattr += " FieldName = \"" + atts.ColumnName + "\",";
            dbattr += atts.IsPK ? "isPK= true," : "";
            dbattr += atts.IsIdentity ? "Identity=true," : "";
            //NotNULL =
            dbattr += atts.cisNull ? " NotNULL = true," : "";
            dbattr += ((atts.DefaultVal != null && atts.DefaultVal.Trim().Length > 0) ? " DefaultValue = \"" + atts.DefaultVal + "\"," : "");
            dbattr += ((atts.Preci != null && atts.Preci.Trim().Length > 0) ? " Prefix = " + atts.Preci + "," : "");
            dbattr += ((atts.Scale != null && atts.Scale.Trim().Length > 0) ? " suffix = " + atts.Scale + "," : "");
            dbattr = dbattr.TrimEnd(',');
            dbattr += ")]";
            return dbattr;
        }
    }
}
