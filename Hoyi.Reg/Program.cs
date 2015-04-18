using Hoyi.filetype;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.Reg
{
    class Program
    {
        static void Main(string[] args)
        {
            REGISTER_REGTABLE();
            Console.WriteLine("HOYI文件注册完成.");
        }
        /// <summary>
        /// 注册注册表.
        /// http://blog.csdn.net/jiutao_tang/article/details/6563646
        /// </summary>
        private static void REGISTER_REGTABLE()
        {
            //bool action = true;
            if (!FileTypeRegister.FileTypeRegistered(".hoyi")) //如果文件类型没有注册，则进行注册
            {
                FileTypeRegInfo fileTypeRegInfo = new FileTypeRegInfo(".hoyi"); //文件类型信息
                fileTypeRegInfo.Description = "HOYI ER图、类图设计";
                fileTypeRegInfo.ExePath = Application.StartupPath + "\\Hoyi.exe";
                fileTypeRegInfo.ExtendName = ".hoyi";
                fileTypeRegInfo.IcoPath = Application.StartupPath + "\\hoyi.ico"; //文件图标使用应用程序的
                FileTypeRegister fileTypeRegister = new FileTypeRegister(); //注册
                FileTypeRegister.RegisterFileType(fileTypeRegInfo);

                Process[] process = Process.GetProcesses(); //重启Explorer进程，使更新立即生效
                var p = (from proc in process
                         where proc.ProcessName.Equals("explorer")
                         select proc).FirstOrDefault();
                p.Kill();
            }
            else
            {
                FileTypeRegInfo fileTypeRegInfo = new FileTypeRegInfo(".hoyi"); //文件类型信息
                fileTypeRegInfo.Description = "HOYI ER图、类图设计";
                fileTypeRegInfo.ExePath = Application.StartupPath + "\\Hoyi.exe";
                fileTypeRegInfo.ExtendName = ".hoyi";
                fileTypeRegInfo.IcoPath = Application.StartupPath + "\\hoyi.ico"; //文件图标使用应用程序的
                FileTypeRegister.UpdateFileTypeRegInfo(fileTypeRegInfo);

                Process[] process = Process.GetProcesses(); //重启Explorer进程，使更新立即生效
                var p = (from proc in process
                         where proc.ProcessName.Equals("explorer")
                         select proc).FirstOrDefault();
                p.Kill();
            }
        }
    }
}
