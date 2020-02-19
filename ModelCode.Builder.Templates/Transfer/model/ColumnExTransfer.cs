/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelCode.Builder.Templates.Util;
using ModelCode.Builder.Templates.Transfer.exec;

namespace ModelCode.Builder.Templates.Transfer.model
{
    /// <summary>
    /// 对单挑Column进行的翻译处理.
    /// </summary>
    public class ColumnExTransfer : IExTransfer
    {
        /// <summary>
        /// 翻译.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        public string Transfer(string content, EntityInfo modelinfo, Object modelObj)
        {
            content = content.TrimEnTa().TrimCVSS();
            IObjExecute execute; 
            if (content.TrimEnTa().StartsWith("if("))
            {
                 execute = new JudgeExecute();
            }
            else
            {
                 execute = new BaseExecute();
            }
            //return execute.Execute(modelObj, modelinfo, content) as string;
            object obb = execute.Execute(modelObj, modelinfo, content);
            string res = obb as string;
            return res;
        }
    }
}
