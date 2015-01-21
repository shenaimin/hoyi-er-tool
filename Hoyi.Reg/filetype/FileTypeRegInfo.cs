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
