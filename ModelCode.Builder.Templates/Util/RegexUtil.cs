/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
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
using System.Text.RegularExpressions;

namespace ModelCode.Builder.Templates.Util
{
    /// <summary>
    /// 函数的正则表达式分析
    /// </summary>
    public static class RegexUtil
    {

        #region 基础方法.

        /// <summary>
        /// 解析函数基本方法.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static MatchCollection MatchReg(string pattern, string input)
        {
            Regex regex = new Regex(pattern);

            Match match = regex.Match(input);
            MatchCollection matches = regex.Matches(input);
            return matches;
        }
        /// <summary>
        /// 根据公式返回 Dictionary<int, string> 类型.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Dictionary<int, string> RegBaseDic(this string content,string pattern)
        {
            Dictionary<int, string> expresslist = new Dictionary<int, string>();

            MatchCollection matches = MatchReg(pattern, content);
            foreach (Match mat in matches)
            {
                expresslist.Add(mat.Index, mat.Value);
            }
            return expresslist;
        }
        /// <summary>
        /// 根据公式，返回符合条件的 List<string> 集合.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static List<string> RegBaseStrList(this string content, string pattern)
        {
            List<string> expressList = new List<string>();

            MatchCollection matches = MatchReg(pattern, content);
            foreach (Match mat in matches)
            {
                expressList.Add(mat.Value);
            }

            return expressList;
        }
        /// <summary>
        /// 根据公式，返回符合条件的 List<int> 集合.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static List<int> RegBaseIntList(this string content, string pattern)
        {
            List<int> expressList = new List<int>();

            MatchCollection matches = MatchReg(pattern, content);
            foreach (Match mat in matches)
            {
                expressList.Add(Convert.ToInt32(mat.Value));
            }

            return expressList;
        }
        /// <summary>
        /// 返回满足条件的一个Int, 返回第一个.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int RegBaseInt(this string content, string pattern)
        {
            return content.RegBaseIntList(pattern)[0];
        }
        /// <summary>
        /// 返回满足条件的一个Str, 返回第一个.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string RegBaseStr(this string content, string pattern)
        {
            return content.RegBaseStrList(pattern)[0];
        }

        #endregion


        #region Pattern Expression的方法.

        /// <summary>
        /// 返回文档中公式模板的起始位置、字符集合。
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetExpressList(string content)
        {
            //(?is)<%%#.*?#%%>
            string pattern = @"(?is)" + AnaConfig.EM_HEAD + ".*?" + AnaConfig.EM_END;

            return content.RegBaseDic(pattern);
        }
        /// <summary>
        /// 返回Field 公式的分析结果.
        /// 
        /// 
        /// 开始结尾的index和内容.
        /// 取内容为：
        /// 0 以"[Fields["开头, 以"]={"结尾的内容
        /// 1 以"]={"开头, 以"}]"结尾的内容
        /// 例如：
        /// 函数为：<%%# [Fields[x]={<div>aac <%#= AttributeInfo.ColumnName #%></div>abcdef }]  #%%>
        /// 存储的内容: 
        ///   ElementAt(0) Key[Index]=5 Value[x]
        ///   ElementAt(1) Key[Index]=10 Value[<div>aac <%#= AttributeInfo.ColumnName #%></div>abcdef]
        ///   
        /// CTRLNAME="Fields", "Operates"
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetFie_FILTER_Sta_EnInfo(string content, string CTRLNAME)
        {
            // (?is)[Fields[.*?]={
            //string pattern = @"(?is)" + AnaConfig.FIELD_EXP_FILTER_HEAD + ".*?" + AnaConfig.FIELD_EXP_FILTER_SUFFIX;
            string pattern = @"(?is)" + "\\[" + CTRLNAME + "\\[" + ".*?" + "\\]\\=\\{";

            return content.RegBaseDic(pattern);
        }
        /// <summary>
        /// 值的头和尾的计算.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetFie_ValueEX_Sta_EnInfo(string content)
        {
            // (?is)]={.*?}];
            //string pattern = @"(?is)" + AnaConfig.FIELD_EXP_FILTER_SUFFIX + ".*?" + AnaConfig.FIELD_EXP_VAL_SUFFIX;
            string pattern = @"(?is)" + "\\]\\=\\{" + ".*?" + "\\}\\]";

            return content.RegBaseDic(pattern);
        }

        /// <summary>
        /// Tables
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetTable_FILTER_Sta_EnInfo(string content)
        {
            // (?is)[Fields[.*?]={
            //string pattern = @"(?is)" + AnaConfig.FIELD_EXP_FILTER_HEAD + ".*?" + AnaConfig.FIELD_EXP_FILTER_SUFFIX;
            string pattern = @"(?is)" + "\\[Tables\\[" + ".*?" + "\\]\\=\\{";

            return content.RegBaseDic(pattern);
        }
        /// <summary>
        /// 值的头和尾的计算.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetTable_ValueEX_Sta_EnInfo(string content)
        {
            // (?is)]={.*?}];
            //string pattern = @"(?is)" + AnaConfig.FIELD_EXP_FILTER_SUFFIX + ".*?" + AnaConfig.FIELD_EXP_VAL_SUFFIX;
            string pattern = @"(?is)" + "\\]\\=\\{" + ".*?" + "\\}\\]";

            return content.RegBaseDic(pattern);
        }
        #endregion
    }
}
