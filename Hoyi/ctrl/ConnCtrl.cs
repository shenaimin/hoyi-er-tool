/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Crainiate.ERM4;
using Hoyi.appConf;
using Hoyi.conf;
using Hoyi.forms;
using ModelCode.ModelInfo;
using ModelCode.ModelInfo.ENTITYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.ctrl
{
    public class ConnCtrl
    {

        private static ConnCtrl _instance;

        public static ConnCtrl Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConnCtrl();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 添加一个新的外键.
        /// </summary>
        /// <param name="entity1"></param>
        /// <param name="att1"></param>
        /// <param name="entity2"></param>
        /// <param name="att2"></param>
        /// <returns></returns>
        public ConstraintInfo AddConstraint(string Fori_NAME,  EntityInfo entity1, AttributeInfo att1, EntityInfo entity2, AttributeInfo att2)
        {
            ConstraintInfo constraint = new ConstraintInfo();
            if (Fori_NAME== "")
            {
                constraint.Constraint_name = "FK_" + entity1.ClassName + "_" + att1.ColumnName + "_" + entity2.ClassName + "_" + att2.ColumnName;

            }
            constraint.Table_Name = entity1.ClassName;
            constraint.Column_Name = att1.ColumnName;
            constraint.ORDINAL_POSITION = entity1.Attributes.IndexOf(att1).ToString();

            constraint.POSITION_IN_UNIQUE_CONSTRAINT = entity2.Attributes.IndexOf(att2).ToString();
            constraint.REFERENCED_TABLE_NAME = entity2.ClassName;
            constraint.REFERENCED_COLUMN_NAME = att2.ColumnName;

            entity1.constraints.Add(constraint);
            return constraint;
        }
        public void RemoveLine(EntityInfo src, EntityInfo target)
        {
            // 没存KEY，这里暂时不做操作.
            //Model model = ClassDiagCtrl.Ins.currentModel;
            //ConnInfo con = new ConnInfo();
            //con.SrcElementID = src.ElementID;
            //con.TargetElementID = target.ElementID;
            //con.linetype = LineType.Line;
            //model.Lines.Remove()
        }

        public void AddLine(EntityInfo src, EntityInfo target)
        {
            try
            {
                Model model = ClassDiagCtrl.Ins.currentModel;
                ConnInfo con = new ConnInfo();
                con.SrcElementID = src.ElementID;
                con.TargetElementID = target.ElementID;
                con.linetype = LineType.Line;
                AppConf.Ins.Application.Conns.Add(con);
                Line line = new Line((Shape)model.Shapes[con.SrcElementID], (Shape)model.Shapes[con.TargetElementID]);
                formConf.conLineKeys.Add(con, line);
                formConf.lineConKeys.Add(line, con);
                model.Lines.Add(model.Lines.CreateKey(), line);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 加载上一次的Connects,s
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cons"></param>
        public void LoadConnects(Model model, List<ConnInfo> cons)
        {
            foreach (ConnInfo con in cons)
            {
                try
                {
                    Line line = null;
                    switch (con.linetype)
                    {
                        case LineType.Line:
                            line = new Line((Shape)model.Shapes[con.SrcElementID], (Shape)model.Shapes[con.TargetElementID]);
                            break;
                        case LineType.Connector:
                            line = new Connector((Shape)model.Shapes[con.SrcElementID], (Shape)model.Shapes[con.TargetElementID]);
                            break;
                        case LineType.ComplexLine:
                            line = new ComplexLine((Shape)model.Shapes[con.SrcElementID], (Shape)model.Shapes[con.TargetElementID]);
                            break;
                        case LineType.Circle:
                            line = new Curve((Shape)model.Shapes[con.SrcElementID], (Shape)model.Shapes[con.TargetElementID]);
                            break;
                        default:
                            break;
                    }
                    if (line != null)
                    {
                        model.Lines.Add(model.Lines.CreateKey(), line);
                        formConf.conLineKeys.Add(con, line);
                        formConf.lineConKeys.Add(line, con);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
