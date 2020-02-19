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
using ModelCode.Util;

namespace ModelCode.Builder.Templates.Util
{
    public class AnaUtil
    {
        private static AnaUtil _instance;

        public static AnaUtil Instance()
        {
            if (_instance == null)
            {
                _instance = new AnaUtil();
            }
            return _instance;
        }
        /// <summary>
        /// 根据模板首位置和长度，返回首位置、末位置.
        /// </summary>
        /// <param name="expresses"></param>
        /// <returns></returns>
        public Dictionary<int, int> GetKeyIndVal(Dictionary<int, string> expresses)
        {
            Dictionary<int, int> patternS_E = new Dictionary<int, int>();
            KeyValuePair<int, string> tmpair;
            for (int i = 0; i < expresses.Count; i++)
            {
                tmpair = expresses.ElementAt(i);
                patternS_E.Add(tmpair.Key, tmpair.Key + tmpair.Value.Length);
            }
            return patternS_E;
        }
    }
}