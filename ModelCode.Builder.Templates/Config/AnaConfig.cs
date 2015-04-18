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

namespace ModelCode.Builder.Templates.Config
{
    public class AnaConfig
    {
        /// <summary>
        /// 单个模板字段开始.
        /// "<%%#"
        /// </summary>
        public static string EM_HEAD = "<%%#";
        /// <summary>
        /// 单个模板字段结束.
        /// "#%%>"
        /// </summary>
        public static string EM_END = "#%%>";

        /// <summary>
        /// 
        /// 0 以"[Fields["开头, 以"]={"结尾的内容
        /// 1 以"]={"开头, 以"}]"结尾的内容
        /// 
        /// Fields 条件的头，也就是整个表达式的头.
        /// "[Fields["
        /// </summary>
        public static string FIELD_EXP_FILTER_HEAD = "[Fields[";
        /// <summary>
        /// Operate的模板写法，用于单个表的操作列表.
        /// </summary>
        public static string OPERATE_EXP_FILETER_HEAD = "[Operaters[";
        /// <summary>
        /// 
        /// 0 以"[Fields["开头, 以"]={"结尾的内容
        /// 1 以"]={"开头, 以"}]"结尾的内容
        /// 
        /// Fields 条件的尾， 也是数值函数的头.
        /// "]={"
        /// 
        /// </summary>
        public static string FIELD_EXP_FILTER_SUFFIX = "]={";
        /// <summary>
        /// 以表开始的头，用于循环表，其他操作跟Fields一样.
        /// </summary>
        public static string TABLE_EXP_FILTER_HEAD = "[Tables[";
        /// <summary>
        /// Field 数值函数的尾.
        /// "}]"
        /// </summary>
        public static string FIELD_EXP_VAL_SUFFIX = "}]";

        /// <summary>
        /// 单列值的头
        /// "<%#="
        /// </summary>
        public static string COLUMN_SIM_EXP_VALUE_HEAD = "<%#=";
        /// <summary>
        /// 单列值的尾
        /// "#%>"
        /// </summary>
        public static string COLUMN_SIM_EXP_VALUE_END = "#%>";
    }
}
