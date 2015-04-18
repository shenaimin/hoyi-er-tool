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
using ModelCode.Builder.Templates.Transfer;
using ModelCode.Builder.Templates.Util;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.RegAnalysis
{
    public class ContentAnalysis
    {
        private static ContentAnalysis _instance;

        public static ContentAnalysis Instance()
        {
            if (_instance == null)
            {
                _instance = new ContentAnalysis();
            }
            return _instance;
        }

        /// <summary>
        /// 根据模板分析，并且返回已替换内容
        /// </summary>
        /// <param name="content"></param>
        /// <param name="regex"></param>
        /// <param name="modelInfo"></param>
        /// <param name="TransferFactory"></param>
        /// <returns></returns>
        public string AnalyAndReplace(string content, string regex, EntityInfo entity, Object obj, IExTransferFactory TransferFactory)
        {
            string Result = "";

            Dictionary<int, string> expresses = content.RegBaseDic(@regex); ;
            
            Dictionary<int, int> patternS_E = AnaUtil.Instance().GetKeyIndVal(expresses);

            Result += patternS_E.Count > 0 ? content.Substring(0, patternS_E.ElementAt(0).Key) : "";

            KeyValuePair<int, int> S_EPair = new KeyValuePair<int, int>();
            KeyValuePair<int, int> S_EPair2 = new KeyValuePair<int, int>();
            for (int i = 0; i < expresses.Count; i++)
            {
                Result += TransferFactory.CreateTransfer(expresses.ElementAt(i).Value).Transfer(expresses.ElementAt(i).Value, entity, obj);
                S_EPair = patternS_E.ElementAt(i);
                S_EPair2 = patternS_E.Count > (i + 1) ? patternS_E.ElementAt(i + 1) : patternS_E.ElementAt(i);

                Result += S_EPair2.Equals(S_EPair) ? "" : content.Substring(S_EPair.Value, S_EPair2.Key - S_EPair.Value);
            }
            Result += patternS_E.Count > 0 ? content.Substring(S_EPair.Value, content.Length - S_EPair.Value) : "";

            Result = patternS_E.Count == 0 ? content : Result;

            return Result;
        }
    }
}
