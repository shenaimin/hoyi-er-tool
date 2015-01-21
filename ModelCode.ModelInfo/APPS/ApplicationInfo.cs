/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.ModelInfo.ENTITYS;
using ModelCode.ModelInfo.ROS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.ModelInfo
{
    /// <summary>
    /// 一个应用程序.
    /// </summary>
    public class ApplicationInfo
    {
        public ApplicationInfo()
        {
            this.Modules = new List<ModuleInfo>();
            Conns = new List<ConnInfo>();
            this.AppName = "默认项目";
        }
        public string AppName { get; set; }
        /// <summary>
        /// 顶级命名空间.
        /// </summary>
        public string NameSpace { get; set; }
        /// <summary>
        /// 程序内的所有模块.
        /// </summary>
        public List<ModuleInfo> Modules { get; set; }
        /// <summary>
        /// 模型保存路径
        /// </summary>
        public string SavedPath { get; set; }
        /// <summary>
        /// 应用程序中的所有角色.
        /// </summary>
        public List<RolesInfo> Roles { get; set; }
        /// <summary>
        /// 连接的集合.
        /// </summary>
        public List<ConnInfo> Conns { get; set; }
    }
}
