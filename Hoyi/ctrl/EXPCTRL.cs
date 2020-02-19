/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.appConf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.ctrl
{
    public class EXPCTRL
    {
        private static EXPCTRL _instance;

        public static EXPCTRL Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EXPCTRL();
                }
                return _instance;
            }
        }

        public List<FileInfo> prestart = new List<FileInfo>();
        public List<FileInfo> started = new List<FileInfo>();

        public void GetAutoSaveFilesInfo()
        {
            started.Clear();
            prestart.Clear();
            string folderpath = Application.StartupPath + "\\autosave\\";
            if (Directory.Exists(folderpath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderpath);

                foreach (FileInfo fl in dirInfo.GetFiles())
                {
                    if (fl.CreationTime > formConf.StartTime)
                    {
                        started.Add(fl);
                    }
                    else
                    {
                        prestart.Add(fl);
                    }
                }
            }
        }
        /// <summary>
        /// 是否异常关闭 。
        /// </summary>
        public bool AreExClosed()
        {
            this.GetAutoSaveFilesInfo();
            return prestart.Count > 0;
        }
    }
}
