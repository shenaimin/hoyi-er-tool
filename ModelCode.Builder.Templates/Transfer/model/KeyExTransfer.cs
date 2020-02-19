/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.Builder.Templates.Transfer.exec;
using ModelCode.Builder.Templates.Util;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ModelCode.Builder.Templates.Transfer
{
    /// <summary>
    /// 只做Key 的转换
    /// </summary>
    public class KeyExTransfer : IExTransfer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern">已经被拆分出来的字符串</param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        public string Transfer(string pattern, EntityInfo modelinfo, Object modelobj)
        {
            pattern = pattern.TrimPat().TrimEnTa();
            BaseExecute exec = new BaseExecute();
            return exec.Execute(modelobj, modelinfo, pattern) as string;
        }
    }
}
