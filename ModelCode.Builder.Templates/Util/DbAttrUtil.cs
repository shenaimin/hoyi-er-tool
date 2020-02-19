/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
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
            AttributeInfo attributeInfo = obj as AttributeInfo;
            string text = "";
            string text2 = text;
            text = string.Concat(new string[]
            {
        text2,
        "[DbAttr(datatype.",
        attributeInfo.TypeName.ToParscal(),
        ", ",
        attributeInfo.Length,
        ","
            });
            text = text + " Comment = \"" + ((attributeInfo.Comment != null && attributeInfo.Comment.Trim().Length > 0) ? attributeInfo.Comment : attributeInfo.ColumnName) + "\",";
            text = text + " FieldName = \"" + attributeInfo.ColumnName + "\",";
            text += (attributeInfo.IsPK ? "isPK= true," : "");
            text += (attributeInfo.IsIdentity ? "Identity=true," : "");
            text += (attributeInfo.cisNull ? " NotNULL = true," : "");
            text += ((attributeInfo.DefaultVal != null && attributeInfo.DefaultVal.Trim().Length > 0) ? (" DefaultValue = \"" + attributeInfo.DefaultVal + "\",") : "");
            text += ((attributeInfo.Preci != null && attributeInfo.Preci.Trim().Length > 0) ? (" Prefix = " + attributeInfo.Preci + ",") : "");
            text += ((attributeInfo.Scale != null && attributeInfo.Scale.Trim().Length > 0) ? (" suffix = " + attributeInfo.Scale + ",") : "");
            text = text.TrimEnd(new char[]
            {
        ','
            });
            return text + ")]";
        }



        public static string GOTColumnJAVADBAttr(object obj)
        {
            AttributeInfo attributeInfo = obj as AttributeInfo;
            string text = "";
            string text2 = text;
            text = string.Concat(new string[]
            {
        text2,
        "@DbAttrANNO(type=datatype.",
        attributeInfo.TypeName.ToParscal(),
        ",  Length = ",
        attributeInfo.Length,
        ","
            });
            text = text + " Comment = \"" + ((attributeInfo.Comment != null && attributeInfo.Comment.Trim().Length > 0) ? attributeInfo.Comment : attributeInfo.ColumnName) + "\",";
            text = text + " FieldName = \"" + attributeInfo.ColumnName + "\",";
            text += (attributeInfo.IsPK ? "isPK= true," : "");
            text += (attributeInfo.IsIdentity ? "Identity=true," : "");
            text += (attributeInfo.cisNull ? " NotNULL = true," : "");
            text += ((attributeInfo.DefaultVal != null && attributeInfo.DefaultVal.Trim().Length > 0) ? (" DefaultValue = \"" + attributeInfo.DefaultVal + "\",") : "");
            text += ((attributeInfo.Preci != null && attributeInfo.Preci.Trim().Length > 0) ? (" Prefix = " + attributeInfo.Preci + ",") : "");
            text += ((attributeInfo.Scale != null && attributeInfo.Scale.Trim().Length > 0) ? (" suffix = " + attributeInfo.Scale + ",") : "");
            text = text.TrimEnd(new char[]
            {
        ','
            });
            return text + ")";
        }

    }
}
