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
using ModelCode.Builder.Templates.Util;

namespace ModelCode.Builder.Templates.Transfer
{
    /// <summary>
    /// 字段的正则表达式分析.
    /// 
    /// 已经被拆分出来的字符串 
    ///         x 表示循环所有值,0表示第一个，>2表示从第三个开始，<2表示从第一个到第二个,Last表示最后一个,Last2表示最后两个,First表示第一个，First2表示前两个.
    ///     {} 表示内容.
    /// 
    ///     aaaa <%%# [Fields[x]={<div>aac <%#= AttributeInfo.ColumnName #%></div>abcdef<div> aab <%#= AttributeInfo.ColumnName.ToParscal() #%></div> }]  #%%>abcd
    /// 
    ///     first2<%%# [Fields[first,2]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>first2
    ///  
    ///     last2<%%# [Fields[last,2]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>last2
    ///  
    ///     equal(1)<%%# [Fields[equal(1)]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>equal(1)
    ///   
    ///     equal(3)<%%# [Fields[equal(3)]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>equal(3)
    /// 
    ///     >1<%%# [Fields[>1]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>>1
    /// 
    ///     <3<%%# [Fields[<3]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%><3
    /// 
    ///     Fields[greatless, 2, 3] 表示取<2 并且大于3 的对象.
    ///     [greatless, 2, 4]<%%# [Fields[greatless, 2, 4]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>[greatless, 2, 4]
    /// 
    ///         
    ///     [greatless, 2, last(1)] 表示取<2 并且大于长度 count - 1的值..
    ///     [greatless, 2, last(1)]<%%# [Fields[greatless, 2, last(1)]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>[greatless, 2, last(1)]
    /// 
    /// 
    ///     [inner, 2, last(1)] 表示取>2 并且 < 长度 count - 1的值..
    ///     [inner, 2, last(1)]<%%# [Fields[inner, 2, last(1)]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>[inner, 2, last(1)]
    /// 
    /// 
    ///     [inner, 2, 4] 表示取>2 并且 < 长度 4 的值..
    ///     [inner, 2, 4]<%%# [Fields[inner, 2, 4]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>[inner, 2, 4]
    /// 
    ///     abc<%%# [Fields[x]={<div><%#= AttributeInfo.ColumnName.ToParscal()#%></div> }]  #%%>bcd
    ///     
    /// </summary>
    public class FieldExRegAna
    {
        /// <summary>
        /// 返回First的的值.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int RegFirst(string expression)
        {
            return RegOnlyG_Num(expression);
            //return expression.TrimFilterR().RegBaseInt(@"(?is)[^first,]\d*$");
        }
        /// <summary>
        /// 返回Last之后的参数 。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int RegLast(string expression)
        {
            return RegOnlyG_Num(expression);
            //return expression.TrimFilterR().RegBaseInt(@"(?is)[^last,]\d*$");
        }
        /// <summary>
        /// 匹配:equal(1)
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int RegEquals(string expression)
        {
            return RegOnlyG_Num(expression);
        }
        /// <summary>
        /// 只取里面的数字.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static int RegOnlyG_Num(string expression)
        {
            return expression.TrimFilterR().RegBaseInt(@"(?is)\d+");
        }
        /// <summary>
        /// 取所有符合的数字列表。
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static List<int> RegAllNum(string expression)
        {
            return expression.TrimFilterR().RegBaseIntList(@"(?is)\d+");
        }
    }
}
