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

using ModelCode.Builder.Templates.Util;
using ModelCode.Builder.Templates.Field_CTR;
using ModelCode.ModelInfo;

namespace ModelCode.Builder.Templates.Transfer.exec
{
    public class URLExecute : IObjExecute
    {
        public object Execute(object obj, EntityInfo modelinfo, string pattern)
        {
            try
            {
                List<string> regex = pattern.RegBaseStrList(@"(?is)\[.*?\]");
                BaseExecute exec = new BaseExecute();
                string tmpstr = "";
                foreach (string str in regex)
                {
                    tmpstr = str.TrimStart('[').TrimEnd(']');
                    string result = exec.Execute(obj, modelinfo, tmpstr) as string;
                    pattern = pattern.Replace('[' + tmpstr + ']', result);
                }

                return pattern;
            }
            catch (Exception ex)
            {
                //如果打开检查，则返回 检查的结果，否则返回空。
                return ExCtr.Return_EX(ex, pattern);
            }
        }
    }
}
