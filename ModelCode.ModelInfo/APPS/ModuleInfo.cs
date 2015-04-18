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

namespace ModelCode.ModelInfo
{
    /// <summary>
    /// 一个模块.
    /// </summary>
    public class ModuleInfo
    {
        public ModuleInfo() { }

        public ModuleInfo(string moduleName)
        {
            this.ModuleName = moduleName;
        }
        /// <summary>
        /// 模块名称.
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 模块标题，常用于中英文的区分.
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 模块类型.
        /// </summary>
        public string ModuleType { get; set; }
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 后缀
        /// </summary>
        public string Suffix { get; set; }

        public ModuleInfo Clone() {
            ModuleInfo module = new ModuleInfo();
            module.ModuleName = this.ModuleName;
            module.Caption = this.Caption;
            module.ModuleType = this.ModuleType;
            module.Prefix = this.Prefix;
            module.Suffix = this.Suffix;
            return module;
        }

        public List<EntityInfo> Entitys = new List<EntityInfo>();

        public override string ToString()
        {
            return "[Modules:{moduleName:" + ModuleName + ", Prefix:" + Prefix + ", Suffix:" + Suffix + ", modulecaption:" + Caption + ", moduleType:" + ModuleType + "}]";
        }
    }
}
