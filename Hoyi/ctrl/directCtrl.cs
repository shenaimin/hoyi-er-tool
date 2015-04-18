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

namespace Hoyi.ctrl
{
    public class directCtrl
    {
        public bool DeleteDir(string strPath)
        {
            try
            { // 清除空格 
                strPath = @strPath.Trim().ToString(); // 判断文件夹是否存在 
                if (System.IO.Directory.Exists(strPath))
                { // 获得文件夹数组 
                    string[] strDirs = System.IO.Directory.GetDirectories(strPath); // 获得文件数组 
                    string[] strFiles = System.IO.Directory.GetFiles(strPath); // 遍历所有子文件夹 
                    foreach (string strFile in strFiles)
                    { // 删除文件夹 
                        System.IO.File.Delete(strFile);
                    } // 遍历所有文件 
                    foreach (string strdir in strDirs)
                    { // 删除文件 
                        System.IO.Directory.Delete(strdir, true);
                    }
                } // 成功 
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString());
                return false;
            }
        }
    }
}
