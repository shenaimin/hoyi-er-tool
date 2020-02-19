/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
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
using ModelCode.CreateBusiness;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Transfer.model
{
    /// <summary>
    /// 单表操作的解析.
    /// </summary>
    public class OperateTransfer : IExTransfer
    {
        public string Transfer(string pattern, EntityInfo entity, object obj)
        {
            try
            {
                EntityInfo modelInfo = obj as EntityInfo;

                // Fields_Express = Fields.Filter + Fields.Values;  没有头尾，中间的东东。
                Dictionary<int, string> exfiltersets = RegexUtil.GetFie_FILTER_Sta_EnInfo(pattern, "Operaters");
                Dictionary<int, string> exvaluesets = RegexUtil.GetFie_ValueEX_Sta_EnInfo(pattern);
                
                string Result = "";

                List<AttributeInfo> columns = new List<AttributeInfo>();

                foreach (IOperater op in entity.operaters)
                {
                    //op.currentModel = modelinfo;
                    columns = new List<AttributeInfo>();
                    foreach (int i in op.FieldIndex)
                    {
                        columns.Add(entity.Attributes[i]);
                    }

                    string OperateName = exfiltersets.ElementAt(0).Value.TrimFFSS();
                    string OperatePattern = exvaluesets.ElementAt(0).Value.TrimFVSS();

                    if (OperateName.Equals(op.Type.ToString()))
                    {
                        string regex = @"(?is)" + AnaConfig.COLUMN_SIM_EXP_VALUE_HEAD + ".*?" + AnaConfig.COLUMN_SIM_EXP_VALUE_END;
                        IExTransferFactory transFactory = new ColumnExTransferFactory();

                        string res = ContentAnalysis.Instance().AnalyAndReplace(OperatePattern, @regex, entity, op, transFactory);
                        Result += res;
                    }
                }

                return Result;
            }
            catch (Exception ex)
            {
                return ExCtr.Return_EX(ex, pattern);
            }
        }
    }
}
