/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.conf;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.Builder.Templates.Field_CTR
{
    public class RELATION_METHOD_EX
    {
        private static RELATION_METHOD_EX _instance;

        public static RELATION_METHOD_EX Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RELATION_METHOD_EX();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 这里可能有好几个.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ConstraintInfo Get_Relation_Constraint(EntityInfo ent)
        {
            ModuleInfo module = AppConf.Ins.getByEntityInfo(ent);
            List<ConstraintInfo> cons = new List<ConstraintInfo>();
            foreach (ConstraintInfo con in ent.constraints)
            {
                if ((con.REFERENCED_TABLE_NAME.StartsWith("r_") || con.REFERENCED_TABLE_NAME.StartsWith(module.Prefix + "r_")) && con.Using)
                {
                    cons.Add(con);
                }
            }
            return cons.Count > 0 ? cons[0] : null;
        }
        /// <summary>
        /// 获取Relation关联的另外一段的实体.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public EntityInfo Get_Relation_Table(EntityInfo ent)
        {
            ConstraintInfo con = this.Get_Relation_Constraint(ent);
            // 获取到关联表.
            EntityInfo rel_table = AppConf.Ins.getEntiByEnname(con.REFERENCED_TABLE_NAME);
            return rel_table;
        }
        /// <summary>
        /// 获取Relation关联的另外一段的实体.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public EntityInfo Get_Relation_OUT_Table(EntityInfo ent)
        {
            ConstraintInfo con = this.Get_Relation_Constraint(ent);
            // 获取到关联表.
            EntityInfo rel_table = AppConf.Ins.getEntiByEnname(con.REFERENCED_TABLE_NAME);

            EntityInfo entity2 = AppConf.Ins.getOut_UNI_Entity(rel_table.ClassName, ent.ClassName)[0];
            // 全局查哪个表跟这张关联表的对应字段有关系.
            return entity2;
        }

    }
}
