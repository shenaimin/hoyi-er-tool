/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.conf;
using ModelCode.Builder.Templates.Config;
using ModelCode.Builder.Templates.RegAnalysis;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Transfer.model
{
    /// <summary>
    /// 模板的生成方法.
    /// </summary>
    public class TemplateExTransfer : IExTransfer
    {
        /// <summary>
        /// calltemp_<%# Template名称 #%>
        /// </summary>
        /// <param name="content"></param>
        /// <param name="modelinfo"></param>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        public string Transfer(string methodname, EntityInfo entity, object obj)
        {
            entity = AppConf.Ins.CurrentExeEntity;

            string templateName = methodname.Replace("calltemp_", "");

            StreamReader objReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "//Template//" + AppConf.ExeTemplatename.Replace(".xml", "") + "//subtemp//" + templateName + ".hoyitm");
            string content = objReader.ReadToEnd();
            objReader.Close();


            string regex = @"(?is)" + AnaConfig.EM_HEAD + ".*?" + AnaConfig.EM_END;
            IExTransferFactory transFactory = new ExTransferFactory();

            string result = ContentAnalysis.Instance().AnalyAndReplace(content, @regex, entity, obj, transFactory);

            return result;


            //content = content.TrimEnTa().TrimCVSS();
            //IObjExecute execute;
            //if (content.TrimEnTa().StartsWith("if("))
            //{
            //    execute = new JudgeExecute();
            //}
            //else
            //{
            //    execute = new BaseExecute();
            //}
            //return execute.Execute(modelObj, modelinfo, content) as string;

        }
    }
}
