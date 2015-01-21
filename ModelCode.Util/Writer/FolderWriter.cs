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
    public class FolderWriter
    {
        /// <summary>
        /// 创建文件夹.
        /// </summary>
        /// <param name="path"></param>
        public void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }

    public static class FolderFactory
    {
        public static FolderWriter Create()
        {
            return new FolderWriter();
        }
    }
}
