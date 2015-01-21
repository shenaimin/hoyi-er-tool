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
using System.IO;

namespace ModelCode.DocumentWriter
{
    public class DocumentsWriter
    {
        /// <summary>
        /// 创建文档.
        /// </summary>
        /// <param name="path"></param>
        public void CreateDocument(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);  
            }
        }
        /// <summary>
        /// 写文档.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public void Write(string path, string content)
        {
            FileStream fs = File.Create(path);
            StreamWriter sw = new StreamWriter(fs,Encoding.UTF8);
            sw.Write(content);
            sw.Flush();
            sw.Close();
        }
    }

    public static class DocumentFactory
    {
        public static DocumentsWriter Create() 
        {
            return new DocumentsWriter();
        }
    }
}
