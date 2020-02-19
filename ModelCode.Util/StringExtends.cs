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

namespace ModelCode.Util
{
    public static class StringExtends
    {
        /// <summary>
        /// 转换成Parscal命名规则.首字母大写.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToParscal(this string name)
        {
            return TP_Util.NameConvertParscal(name);
        }
        /// <summary>
        /// 转换成Camel命名规则,首字母小写.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToCamel(this string name)
        {
            return TP_Util.NameConvertCamel(name);
        }
    }
}
