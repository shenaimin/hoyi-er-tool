/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.CreateBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.ModelInfo
{
    public class EntityInfo
    {
        public EntityInfo()
        {
            Attributes = new List<AttributeInfo>();
            operaters = new List<IOperater>();
            constraints = new List<ConstraintInfo>();
        }
        /// <summary>
        /// 创建的日期.
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// 实体名称,直接拿这个过来做Comment.
        /// </summary>
        public string EntityName { get; set; }
        /// <summary>
        /// 表名.
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 在模型中的X坐标.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// 在模型中的Y坐标.
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// 记录Entity Element 的ID.
        /// </summary>
        public string ElementID { get; set; }

        /// <summary>
        /// 列.
        /// </summary>
        public List<AttributeInfo> Attributes { get; set; }
        /// <summary>
        /// 操作列表.
        /// </summary>
        public List<IOperater> operaters { get; set; }
        /// <summary>
        /// 外键.
        /// </summary>
        public List<ConstraintInfo> constraints { get; set; }

        public bool NeedfpyTable = false;
        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        public EntityInfo Clone()
        {
            EntityInfo ent = new EntityInfo();
            ent.CreateDate = this.CreateDate;
            ent.EntityName = this.EntityName;
            ent.ClassName = this.ClassName;
            ent.X = this.X;
            ent.Y = this.Y;
            // 这里考虑是否要克隆一组，而不是直接赋值.
            ent.Attributes = this.Attributes;
            ent.operaters = this.operaters;
            ent.constraints = this.constraints;
            ent.NeedfpyTable = NeedfpyTable;
            ent.Notes = this.Notes;
            return ent;
        }

        public override string ToString()
        {
            string str = "";
            foreach (AttributeInfo att in Attributes)
            {
                str += att.ToString();
            }
            str = "[EntityInfo:{EntityName:" + EntityName + ", ClassName: " + ClassName + ",CreateDate:" + CreateDate + ",Attrs:" + str +" }]";
            return str;
        }
    }
}
