/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
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
using System.Threading.Tasks;

namespace Hoyi.filetype
{
    public class FileTypeRegInfo
    {
        /// <summary>
        /// 目标类型文件的扩展名
        /// </summary>
        public string ExtendName;  //".xcf"
        /// <summary>
        /// 目标文件类型说明
        /// </summary>
        public string Description; //"XCodeFactory项目文件"
        /// <summary>
        /// 目标类型文件关联的图标
        /// </summary>
        public string IcoPath;
        /// <summary>
        /// 打开目标类型文件的应用程序
        /// </summary>
        public string ExePath;
        public FileTypeRegInfo()
        {
        }
        public FileTypeRegInfo(string extendName)
        {
            this.ExtendName = extendName;
        }
    }
}
