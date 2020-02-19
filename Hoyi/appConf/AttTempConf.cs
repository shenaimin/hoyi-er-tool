using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hoyi.appConf
{
    /// <summary>
    /// 这里放所有的字段模板及操作
    /// </summary>
    public class AttTempConf
    {
        private static AttTempConf _instance;

        public static AttTempConf Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AttTempConf();
                    //_instance.InitTemps();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 所有的字段模板.
        /// </summary>
        public List<string> alltemps = new List<string>();
        /// <summary>
        /// 初始化字段模板.
        /// </summary>
        public void InitTemps()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\att_temps");
            if (dir.Exists)
            {
                foreach (FileInfo dd in dir.GetFiles())
                {
                    alltemps.Add(dd.Name);
                }
            }
        }

    }
}
