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
using ModelCode.Builder.Templates.Field_CTR;
using ModelCode.Builder.Templates.RegAnalysis;
using ModelCode.Builder.Templates.Util;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Transfer.model
{
    public class TableExTransfer : IExTransfer
    {
        public string Transfer(string pattern, EntityInfo modelinfo, Object modelobj)
        {
            try
            {
                EntityInfo modelInfo = modelobj as EntityInfo;
                // Fields_Express = Fields.Filter + Fields.Values;  没有头尾，中间的东东。
                Dictionary<int, string> exfiltersets = RegexUtil.GetTable_FILTER_Sta_EnInfo(pattern);
                Dictionary<int, string> exvaluesets = RegexUtil.GetTable_ValueEX_Sta_EnInfo(pattern);

                // 先用 Fiter 来筛选符合条件的List<AttributeInfo>
                List<EntityInfo> tbs = new FieldCtr().GetTableListByFilter(modelInfo, exfiltersets.ElementAt(0).Value);

                string Result = "";

                foreach (EntityInfo tb in tbs)
                {
                    string fieldSTR = exvaluesets.ElementAt(0).Value.TrimFVSS();

                    string regex = @"(?is)" + AnaConfig.COLUMN_SIM_EXP_VALUE_HEAD + ".*?" + AnaConfig.COLUMN_SIM_EXP_VALUE_END;
                    IExTransferFactory transFactory = new ColumnExTransferFactory();

                    string res = ContentAnalysis.Instance().AnalyAndReplace(fieldSTR, @regex, modelinfo, tb, transFactory);
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
        public List<EntityInfo> GetExpressedColumn(string filter, EntityInfo modelInfo)
        {
            FieldCtr fieldCtr = new FieldCtr();
            return fieldCtr.GetTableListByFilter(modelInfo, filter);
        }
    }
}
