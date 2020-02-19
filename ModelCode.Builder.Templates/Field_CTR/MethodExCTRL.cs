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
    public class MethodExCTRL
    {
        private static MethodExCTRL _instance;

        public static MethodExCTRL Ins
        {
            get {
                if (_instance == null)
                {
                    _instance = new MethodExCTRL();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 获取自循环的外键对象.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ConstraintInfo GetSelfConstraint(EntityInfo ent)
        {
            var query = ent.constraints.Where(s => s.REFERENCED_TABLE_NAME.Equals(ent.ClassName) && s.Using);
            return query.Count() > 0 ? query.ToList()[0] : null;
        }
        /// <summary>
        /// 获取自循环对象的外键名字，一般为ParentId
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public string GetSelfCons_OUT_ColumnName(EntityInfo ent)
        {
            return this.GetSelfConstraint(ent).REFERENCED_COLUMN_NAME;
        }
        /// <summary>
        /// 获取自循环对象的外键名字，一般为ParentId
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public string GetSelfCons_IN_ColumnName(EntityInfo ent)
        {
            return this.GetSelfConstraint(ent).Column_Name;
        }
        /// <summary>
        /// 获取非自循环的外键
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ConstraintInfo GetUN_SELF_CONSTRANIT(EntityInfo ent)
        {
            var query = ent.constraints.Where(s => (!s.REFERENCED_TABLE_NAME.Equals(ent.ClassName) && s.Using));
            return query.Count() > 0 ? query.ToList()[0] : null;
        }
        /// <summary>
        /// 获取非自循环对象的第一个外键.
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ConstraintInfo GetConstraint(EntityInfo ent)
        {
            //var query = ent.constraints.Where(s => (!s.REFERENCED_TABLE_NAME.Equals(ent.ClassName)));
            //return query.Count() > 0 ? query.ToList()[0] : null;
            var query = ent.constraints.Where(s=>s.Using);
            return query.Count() > 0 ? query.ToList()[0] : null;
            //return ent.constraints[0];
        }
        /// <summary>
        /// 根据表名返回实体对象.
        /// </summary>
        /// <param name="obj">表名.</param>
        /// <returns></returns>
        public EntityInfo RefByEntityName(Object obj)
        {
            return AppConf.Ins.getEntiByEnname(obj.ToString());
        }
        /// <summary>
        /// 获取字段对应的外键.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ConstraintInfo GetAttCons(Object obj)
        { 
            AttributeInfo tmpAtt = obj as AttributeInfo;
            return AppConf.Ins.CurrentExeEntity.constraints.Where(s => s.Column_Name.Equals(tmpAtt.ColumnName) && s.Using).ToList()[0];
        }
    }
}
