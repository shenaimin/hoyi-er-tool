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
using System.IO;
using ModelCode.ModelInfo;
using System.Configuration;
using ModelCode.Builder.Templates.RegAnalysis;
using ModelCode.Builder.Templates.Config;
using ModelCode.Builder.Templates.Transfer;

namespace ModelCode.Builder.Templates.Infos
{
    /// <summary>
    /// 单个模板, 单个模板生成单个实体的文件.
    /// </summary>
    public class MCTemplates
    {
        public EntityInfo modelInfo;
        
        /// <summary>
        /// 执行内容生成,
        /// </summary>
        /// <param name="_modelInfo"></param>
        /// <param name="templateURL"></param>
        /// <param name="targetURL"></param>
        public void ExecuteContent(EntityInfo _modelInfo, string templateURL, string targetURL)
        {
            FileInfo file = new FileInfo(targetURL);
            string folName = file.DirectoryName;
            if (!Directory.Exists(folName))
            {
                Directory.CreateDirectory(folName);
            }

            this.modelInfo = _modelInfo;

            StreamReader objReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + templateURL);
            string Encode = ConfigurationManager.AppSettings["Encode"];

            Encoding encoding = Encoding.UTF8;
            if (Encode.ToLower().Equals("utf8"))
            {
                encoding = Encoding.UTF8;
            }
            else if (Encode.ToLower().Equals("unicode"))
            {
                encoding = Encoding.Unicode;
            }
            else if (Encode.ToLower().Equals("ascii"))
            {
                encoding = Encoding.ASCII;
            }
            else if (Encode.ToLower().Equals("bigendianunicode"))
            {
                encoding = Encoding.BigEndianUnicode;
            }

            StreamWriter templateWriter = new StreamWriter(targetURL, false, encoding);

            string content = objReader.ReadToEnd();
            string regex = @"(?is)" + AnaConfig.EM_HEAD + ".*?" + AnaConfig.EM_END;
            IExTransferFactory transFactory = new ExTransferFactory();

            string result = ContentAnalysis.Instance().AnalyAndReplace(content, @regex, modelInfo, modelInfo, transFactory);

            templateWriter.Write(result);

            objReader.Close();
            templateWriter.Close();
        }

        #region 之前写法

        /// <summary>
        /// 所有的Key，这里的Key直接对应系统内的Key,在系统里面加上Key的翻译方法.
        /// </summary>
        //public List<string> Keys;

        //public KeyTrans Translater = new KeyTrans();
        //string sLine = "";
        // 这里可以读一行，翻译一行，写一行。这样就不会有太大的性能和内存问题了.
        //while (sLine != null)
        //{
        //    sLine = objReader.ReadLine();

        //    if (sLine != null)
        //    {
        //        // 这里开始解析和转换内容.
        //        string result = Translater.TransLineStr(sLine, modelInfo);
        //        templateWriter.WriteLine(result);
        //    }
        //}

        #endregion
    }
}
