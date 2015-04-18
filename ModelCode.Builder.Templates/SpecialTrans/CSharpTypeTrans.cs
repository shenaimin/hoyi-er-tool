/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.Builder.Templates.Field_CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.SpecialTrans
{
    public class CSharpTypeTrans
    {
        Dictionary<string, string> maria2cshaprPackaged = new Dictionary<string, string>();
        Dictionary<string, string> maria2csharpUnPackaged = new Dictionary<string, string>();

        public CSharpTypeTrans()
        {
            if (maria2cshaprPackaged.Count == 0)
            {
                maria2cshaprPackaged.Add("int", "Integer");
                maria2cshaprPackaged.Add("bigint", "Int64");
                maria2cshaprPackaged.Add("varchar", "String");
                maria2cshaprPackaged.Add("datetime", "Date");
                maria2cshaprPackaged.Add("decimal", "Decimal");
            }
            if (maria2csharpUnPackaged.Count == 0)
            {
                maria2csharpUnPackaged.Add("int", "int");
                maria2csharpUnPackaged.Add("bigint", "Int64");
                maria2csharpUnPackaged.Add("varchar", "string");
                maria2csharpUnPackaged.Add("decimal", "decimal");
                maria2csharpUnPackaged.Add("datetime", "Date");
            }
        }
        /// <summary>
        /// 根据MariaDB转换称 Java的封包Type
        /// </summary>
        /// <param name="mariaType"></param>
        /// <returns></returns>
        public string MariaToCSPackagedClass(string mariaType) {
            if (maria2cshaprPackaged.Keys.ToList().Contains(mariaType))
            {
                return maria2cshaprPackaged[mariaType];
            }
            //如果打开检查，则返回 检查的结果，否则返回空。
            return ExCtr.Retuen_CANOT_TRANS(mariaType);
        }
        /// <summary>
        /// 根据MariaDB转换称 Java的封包Type
        /// </summary>
        /// <param name="mariaType"></param>
        /// <returns></returns>
        public string MariaToCSUnPackagedClass(string mariaType)
        {
            if (maria2csharpUnPackaged.Keys.ToList().Contains(mariaType))
            {
                return maria2csharpUnPackaged[mariaType];
            }
            //如果打开检查，则返回 检查的结果，否则返回空。
            return ExCtr.Retuen_CANOT_TRANS(mariaType);
        }
    }
}
