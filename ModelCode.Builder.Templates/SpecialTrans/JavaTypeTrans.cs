/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.Builder.Templates.Field_CTR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.SpecialTrans
{
    public class JavaTypeTrans
    {
        Dictionary<string, string> maria2JavaPackaged = new Dictionary<string, string>();
        Dictionary<string, string> maria2JavaUnPackaged = new Dictionary<string, string>();

        public JavaTypeTrans()
        {
            if (maria2JavaPackaged.Count == 0)
            {
                maria2JavaPackaged.Add("int", "Integer");
                maria2JavaPackaged.Add("bigint", "Integer");
                maria2JavaPackaged.Add("varchar", "String");
                maria2JavaPackaged.Add("datetime", "Date");
                
            }
            if (maria2JavaUnPackaged.Count == 0)
            {
                maria2JavaUnPackaged.Add("int", "int");
                maria2JavaUnPackaged.Add("bigint", "int");
                maria2JavaUnPackaged.Add("varchar", "string");
                maria2JavaUnPackaged.Add("datetime", "Date");
            }
        }
        /// <summary>
        /// 根据MariaDB转换称 Java的封包Type
        /// </summary>
        /// <param name="mariaType"></param>
        /// <returns></returns>
        public string MariaToJavaPackagedClass(string mariaType) {
            if (maria2JavaPackaged.Keys.ToList().Contains(mariaType))
            {
                return maria2JavaPackaged[mariaType];
            }
            //如果打开检查，则返回 检查的结果，否则返回空。
            return ExCtr.Retuen_CANOT_TRANS(mariaType);
        }
        /// <summary>
        /// 根据MariaDB转换称 Java的封包Type
        /// </summary>
        /// <param name="mariaType"></param>
        /// <returns></returns>
        public string MariaToJavaUnPackagedClass(string mariaType)
        {
            if (maria2JavaUnPackaged.Keys.ToList().Contains(mariaType))
            {
                return maria2JavaUnPackaged[mariaType];
            }
            //如果打开检查，则返回 检查的结果，否则返回空。
            return ExCtr.Retuen_CANOT_TRANS(mariaType);
        }
    }
}
