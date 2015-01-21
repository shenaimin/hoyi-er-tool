/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.Builder.Templates.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Util
{
    public static class STREX
    {
        /// <summary>
        /// 删除模板头
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimPatStart(this string name)
        {
            return name.TrimStart(AnaConfig.EM_HEAD.ToCharArray());
        }
        /// <summary>
        /// 删除模板尾
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimPatEnd(this string name)
        {
            return name.TrimEnd(AnaConfig.EM_END.ToCharArray());
        }
        /// <summary>
        /// 删掉头尾模板
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimPat(this string name)
        {
            return name.TrimPatStart().TrimPatEnd();
        }
        /// <summary>
        /// 去除空格.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimBlank(this string name)
        {
            return name.Replace(" ", "");
        }
        /// <summary>
        /// 去除Fields的Filter内的\r\t\n、空格、全小写.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimFilterR(this string name)
        {
            return name.TrimEnTa().Replace(" ", "").ToLower();
        }
        /// <summary>
        /// 删掉回车和换行
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimEnTa(this string name)
        {
            return name.Replace("\n", "").Replace("\r", "").Replace("\t", "").Trim();
        }
        /// <summary>
        /// 去掉一个函数的首尾符号.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimPSS(this string name)
        {
            return name.TrimStart(AnaConfig.EM_HEAD.ToArray()).TrimEnd(AnaConfig.EM_END.ToArray());
        }
        /// <summary>
        /// 去掉Field函数的Filter首尾.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimFFSS(this string name)
        {
            return name.TrimStart(AnaConfig.FIELD_EXP_FILTER_HEAD.ToArray()).TrimStart(AnaConfig.OPERATE_EXP_FILETER_HEAD.ToArray()).TrimStart(AnaConfig.TABLE_EXP_FILTER_HEAD.ToArray()).TrimEnd(AnaConfig.FIELD_EXP_FILTER_SUFFIX.ToArray());
        }
        /// <summary>
        /// 去掉Field函数的Value首尾.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimFVSS(this string name)
        {
            return name.TrimStart(AnaConfig.FIELD_EXP_FILTER_SUFFIX.ToArray()).TrimEnd(AnaConfig.FIELD_EXP_VAL_SUFFIX.ToArray());
        }
        /// <summary>
        /// 去掉Column函数的Value首尾.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TrimCVSS(this string name)
        {
            return name.TrimStart(AnaConfig.COLUMN_SIM_EXP_VALUE_HEAD.ToArray()).TrimEnd(AnaConfig.COLUMN_SIM_EXP_VALUE_END.ToArray());
        }
    }
}
