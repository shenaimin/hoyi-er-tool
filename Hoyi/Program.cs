/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.filetype;
using Hoyi.forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //MessageBox.Show("args[0]:" + args[0]);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            //RegTXT();
            REGISTER_REGTABLE();
            Application.Run(new FMClass(args));
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
                fileTypeRegInfo.ExePath = Application.ExecutablePath;
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
            //else
            //{
            //    FileTypeRegInfo fileTypeRegInfo = new FileTypeRegInfo(".hoyi"); //文件类型信息
            //    fileTypeRegInfo.Description = "HOYI ER图、类图设计";
            //    fileTypeRegInfo.ExePath = Application.ExecutablePath;
            //    fileTypeRegInfo.ExtendName = ".hoyi";
            //    fileTypeRegInfo.IcoPath = Application.StartupPath + "\\hoyi.ico"; //文件图标使用应用程序的
            //    FileTypeRegister.UpdateFileTypeRegInfo(fileTypeRegInfo);

            //    Process[] process = Process.GetProcesses(); //重启Explorer进程，使更新立即生效
            //    var p = (from proc in process
            //             where proc.ProcessName.Equals("explorer")
            //             select proc).FirstOrDefault();
            //    p.Kill();
            //}
        }
    }
}
