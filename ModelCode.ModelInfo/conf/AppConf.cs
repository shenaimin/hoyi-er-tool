/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Crainiate.ERM4;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.conf
{
    /// <summary>
    /// 这里做全局的配置，所有的操作都从这个配置里面来拿.
    /// </summary>
    public class AppConf
    {
        private static AppConf _instance;

        public static AppConf Ins {
            set {
                _instance = value;
            }
            get{
                if (_instance == null)
                {
                    _instance = new AppConf();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 打开跟加载的路径.
        /// </summary>
        public static string LoadAndSavedPath { get; set; }
        /// <summary>
        /// 执行的模板名称.
        /// </summary>
        public static string ExeTemplatename { get; set; }

        /// <summary>
        /// 用来存储系统的版本号，请在Program中设置版本号.
        /// </summary>
        public string Version = "";

        /// <summary>
        /// 是否已经保存，用于在退出的时候判断是否已经全部保存了，全部保存的话就不弹出询问框。
        /// 第一次为true,第一次打开的都不用保存.
        /// </summary>
        public bool DocSaved = true;

        /// <summary>
        /// 全局的应用.
        /// </summary>
        private ApplicationInfo _application;
        /// <summary>
        /// 仓前系统.
        /// </summary>
        public ApplicationInfo Application {
            set {
                _application = value;
            }
            get
            {
                if (_application == null)
                {
                    _application = new ApplicationInfo();
                    ModuleInfo mod = new ModuleInfo("默认模块");
                    _application.Modules.Add(mod);
                }
                return _application;
            }
        }
        /// <summary>
        /// 是否打开了Edit.
        /// </summary>
        public bool EditOpenning = false;

        /// <summary>
        /// 当前模型内的视图.
        /// </summary>
        public Dictionary<EntityInfo, Table> views_enkey = new Dictionary<EntityInfo, Table>();
        public Dictionary<Table, EntityInfo> views_tbkey = new Dictionary<Table, EntityInfo>();

        public EntityInfo getEntiByEnname(string EnName)
        {
            foreach (ModuleInfo m in AppConf.Ins.Application.Modules)
            {
                foreach (EntityInfo e in m.Entitys)
                {
                    if (e.ClassName.Equals(EnName) || EnName.Equals(m.Prefix + e.ClassName))
                    {
                        return e;
                    }
                }
            }

            return null;
        }
        /// <summary>
        /// 获取entity的module.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ModuleInfo getByEntityInfo(EntityInfo entity)
        {
            var mods = from m in (AppConf.Ins.Application.Modules)
                       where m.Entitys.Contains(entity)
                       select m;
            foreach (var item in mods)
            {
                return item as ModuleInfo;
            }
            return null;
        }

        public ModuleInfo getByExeEntityInfo(EntityInfo entity)
        {
            var mods = from m in (CurrentExeModules)
                       where m.Entitys.Contains(entity)
                       select m;
            foreach (var item in mods)
            {
                return item as ModuleInfo;
            }
            return null;
        }
        /// <summary>
        /// 获取所有跟当前关联表有关系的实体.
        /// </summary>
        /// <param name="relationTB_NAME">关联表名称.</param>
        /// <returns></returns>
        public List<EntityInfo> getOut_UNI_Entity(string relationTB_NAME)
        {
            List<EntityInfo> entities = new List<EntityInfo>();

            foreach (ModuleInfo m in AppConf.Ins.Application.Modules)
            {
                foreach (EntityInfo e in m.Entitys)
                {
                    var querym = from ens in e.constraints
                                 where ens.REFERENCED_TABLE_NAME.Equals(relationTB_NAME) && ens.Using
                                 select ens;
                    if (querym != null && querym.Count() >0)
                    {
                        entities.Add(e);
                    }
                }
            }

            return entities;
        }

        /// <summary>
        /// 获取所有跟当前关联表有关系的实体.
        /// </summary>
        /// <param name="relationTB_NAME">关联表名称.</param>
        /// <param name="exp_class_name"> 除这个名字之外的关联.</param>
        /// <returns></returns>
        public List<EntityInfo> getOut_UNI_Entity(string relationTB_NAME, string exp_class_name)
        {
            List<EntityInfo> entities = new List<EntityInfo>();

            foreach (ModuleInfo m in AppConf.Ins.Application.Modules)
            {
                foreach (EntityInfo e in m.Entitys)
                {
                    var querym = from ens in e.constraints
                                 where ens.REFERENCED_TABLE_NAME.Equals(relationTB_NAME) && ens.Using
                                 select ens;
                    if (querym != null && querym.Count() > 0)
                    {
                        if (!e.ClassName.Equals(exp_class_name))
                        {
                            entities.Add(e);
                        }
                    }
                }
            }

            return entities;
        }
        /// <summary>
        /// 当前正在转换的Entity.
        /// </summary>
        public EntityInfo CurrentExeEntity { get; set; }
        /// <summary>
        /// 当前转换的Modules
        /// </summary>
        public List<ModuleInfo> CurrentExeModules { get; set; }
    }
}
