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
using Hoyi.conf;
using ModelCode.ModelInfo;
using ModelCode.ModelInfo.ENTITYS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.appConf
{
    public class formConf
    {
        /// <summary>
        /// 退出是否删除自动保存项目 。
        /// </summary>
        public static bool AreExitRemoveAutoSave = true;
        /// <summary>
        /// 获取配置内的所有的实体.
        /// </summary>
        /// <returns></returns>
        public static List<EntityInfo> getConfEntity()
        {
            List<EntityInfo> entities = new List<EntityInfo>();

            foreach (ModuleInfo module in AppConf.Ins.Application.Modules)
            {
                entities.AddRange(module.Entitys);
            }

            return entities;
        }
        /// <summary>
        /// 当前操作的模型.
        /// </summary>
        public static Model CurrentModel;

        public static string DefaultConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public static string connectionString;

        public static Table Editedtable;

        public static LineType linetype { get; set; }
        /// <summary>
        /// 按下的Table
        /// </summary>
        public static Table MouseDownTable { get; set; }
        /// <summary>
        /// 抬起的Table
        /// </summary>
        public static Table MouseUpTable { get; set; }
        /// <summary>
        /// 启动时间 。
        /// </summary>
        public static DateTime StartTime { get; set; }
        /// <summary>
        /// 记录 Connector和Line
        /// </summary>
        public static Dictionary<ConnInfo, Line> conLineKeys = new Dictionary<ConnInfo, Line>();
        /// <summary>
        /// 记录 Connector和Line
        /// </summary>
        public static Dictionary<Line, ConnInfo> lineConKeys = new Dictionary<Line, ConnInfo>();
        /// <summary>
        /// 导入数据表的时候,已选择的数据库名称.
        /// </summary>
        public static string CheckedDatabase = "";
        /// <summary>
        /// 是否包含实体.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool ContainEntity(EntityInfo entity)
        {
            foreach (ModuleInfo mo in AppConf.Ins.Application.Modules)
            {
                foreach (EntityInfo ent in mo.Entitys)
                {
                    if (ent.Equals(entity))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 获取包含的模块名
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ModuleInfo GetEntityModule(EntityInfo entity)
        {
            foreach (ModuleInfo mo in AppConf.Ins.Application.Modules)
            {
                foreach (EntityInfo ent in mo.Entitys)
                {
                    if (ent.Equals(entity))
                    {
                        return mo;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 根据表名找到表，然后加上modules的前缀 。
        /// </summary>
        /// <param name="modules"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static string GetPrefixClassName(List<ModuleInfo> modules, string className)
        {
            foreach (ModuleInfo mo in modules)
            {
                foreach (EntityInfo ent in mo.Entitys)
                {
                    if (ent.ClassName.Equals(className))
                    {
                        return mo.Prefix + ent.ClassName;
                    }
                }
            }
            return "";
        }
    }
}
