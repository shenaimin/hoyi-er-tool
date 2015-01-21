/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
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
using System.Xml;
using ModelCode.ModelInfo;
using ModelCode.Builder.Templates.Infos;
using ModelCode.Util;
using ModelCode.Builder.Templates.Util;
using ModelCode.Builder.Templates.Transfer;
using ModelCode.Builder.Templates.Transfer.model;
using ModelCode.Builder.Templates.RegAnalysis;
using ModelCode.Builder.Templates.Transfer.exec;

namespace ModelCode.Builder.Templates.Analysis
{
    /// <summary>
    /// 控制Template生成路径和
    /// </summary>
    public class TemplateURLControl
    {
        public List<TemplateRule> tempRules = new List<TemplateRule>();

        public void LoadTemplateURL(string templates_navi_url)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(System.AppDomain.CurrentDomain.BaseDirectory + templates_navi_url);

            string x = xml.ToString();

            XmlNodeList nList = xml.SelectNodes("//Docments/Document");

            foreach (XmlNode node in nList)
            {
                TemplateRule rule = new TemplateRule();
                rule.ID = node.Attributes["id"].InnerXml;
                rule.TemplateURL = node.Attributes["Template"].InnerXml;
                rule.TargetURL = node.Attributes["TargetURL"].InnerXml;

                tempRules.Add(rule);
            }
        }

        MCTemplates template = new MCTemplates();

        /// <summary>
        /// 根据模板规则生成到TargetURL路径的值.
        /// </summary>
        /// <param name="TargetURL"></param>
        public void Execute(EntityInfo modelInfo, string TargetURL)
        { 
            foreach (TemplateRule rule in tempRules)
            {
                string STR_TargetURL = rule.TargetURL;
                Console.WriteLine(STR_TargetURL);

                URLExecute execute = new URLExecute();
                STR_TargetURL = execute.Execute(TargetURL, modelInfo, STR_TargetURL) as string;

                Console.WriteLine(STR_TargetURL);

                template.ExecuteContent(modelInfo, rule.TemplateURL, STR_TargetURL);
            }
        }
    }
}
