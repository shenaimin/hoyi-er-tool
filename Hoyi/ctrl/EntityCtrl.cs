/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.ctrl
{
    public class EntityCtrl
    {
        public static EntityCtrl CRA()
        {
            return new EntityCtrl();
        }

        public Table CreateTable(EntityInfo entity, int x, int y)
        {
            Table table = new Table();

            //Set Element properties
            table.BackColor = Color.White;
            table.GradientColor = Color.FromArgb(96, SystemColors.Highlight);
            table.Location = new PointF(x, y);
            table.Width = 140;
            table.Height = 200;
            table.Indent = 10;
            if (entity == null)
            {
                table.Heading = "[UnNamed Element]";
                table.SubHeading = "[UnNamed Class]";
            }
            else
            {
                if (entity != null)
                {
                    string cons = "conscount:" + entity.constraints.Count + "  ";
                    foreach (ConstraintInfo c in entity.constraints)
                    {
                        cons += "\n" + c.Constraint_name + ",";
                    }
                    table.Heading = entity.EntityName;
                    table.SubHeading = entity.ClassName + "[" + cons + "]\n" + "   [" + entity.Attributes.Count.ToString() + " Fields]";
                    //table.SubHeading = entity.ClassName + "   [" + entity.Attributes.Count.ToString() + " Fields]";
                }
            }
            table.DrawExpand = true;
            table.Tag = entity;
            return table;
        }
    }
}
