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
using ModelCode.Builder.Templates.Field_CTR;
using ModelCode.Builder.Templates.RegAnalysis;
using ModelCode.Builder.Templates.Transfer.model;
using ModelCode.Builder.Templates.Util;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Transfer
{
    public class FieldExTransfer : IExTransfer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern">已经被拆分出来的字符串 
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
        ///    </param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        public string Transfer(string pattern, EntityInfo _entity, Object modelobj)
        {
            try
            {
                //IModelInfo modelInfo = modelobj as IModelInfo;
                // Fields_Express = Fields.Filter + Fields.Values;  没有头尾，中间的东东。
                Dictionary<int, string> exfiltersets = RegexUtil.GetFie_FILTER_Sta_EnInfo(pattern, "Fields");
                Dictionary<int, string> exvaluesets = RegexUtil.GetFie_ValueEX_Sta_EnInfo(pattern);

                // 先用 Fiter 来筛选符合条件的List<AttributeInfo>
                List<AttributeInfo> cols = new FieldCtr().GetFieldListByFilter(_entity, exfiltersets.ElementAt(0).Value);

                string Result = "";

                foreach (AttributeInfo col in cols)
                {
                    string fieldSTR = exvaluesets.ElementAt(0).Value.TrimFVSS();

                    string regex = @"(?is)" + AnaConfig.COLUMN_SIM_EXP_VALUE_HEAD + ".*?" + AnaConfig.COLUMN_SIM_EXP_VALUE_END;
                    IExTransferFactory transFactory = new ColumnExTransferFactory();

                    string res = ContentAnalysis.Instance().AnalyAndReplace(fieldSTR, @regex, _entity, col, transFactory);
                    Result += res;
                }
                return Result;
            }
            catch (Exception ex)
            {
                return ExCtr.Return_EX(ex, pattern);
            }
        }

        /// <summary>
        /// 找出符合条件的所有字段.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        public List<AttributeInfo> GetExpressedColumn(string filter, EntityInfo modelInfo)
        {
            FieldCtr fieldCtr = new FieldCtr();
            return fieldCtr.GetFieldListByFilter(modelInfo, filter);
        }
    }
}
