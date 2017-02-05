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
using Hoyi.appConf;
using Hoyi.conf;
using Hoyi.ctrl;
using ModelCode.ModelInfo;
using ModelCode.ModelInfo.ENTITYS;
using ModelCode.ModelInfo.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.forms
{
    public class ClassDiagCtrl
    {
        private static ClassDiagCtrl _instance;

        public static ClassDiagCtrl Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClassDiagCtrl();
                }
                return _instance;
            }
        }
        public Table NewEntity(Model model1, int x, int y)
        {
            EntityInfo entity = new EntityInfo();
            Table table = EntityCtrl.CRA().CreateTable(entity, x, y);
            entity.X = x;
            entity.Y =y;
            table.Tag = entity;
            table.LocationChanged += table_LocationChanged;

            ProTreeCtrl.Ins.CheckedModule.Entitys.Add(entity);
            
            AppConf.Ins.views_enkey.Add(entity, table);
            AppConf.Ins.views_tbkey.Add(table, entity);
            entity.ElementID = "Element" + Guid.NewGuid();
            model1.Shapes.Add(entity.ElementID, table);
            table.SelectedChanged += properGridCtrl.Ins.table_SelectedChanged;
            return table;
        }
        /// <summary>
        /// 在当前Model上添加一个Table.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Table NewRelationTable(EntityInfo entity)
        {
            return this.NewTable(this.currentModel, entity);
        }

        public Table NewTable(Model model1, EntityInfo entity)
        {
            Table table = EntityCtrl.CRA().CreateTable(entity, entity.X, entity.Y);
            table.Tag = entity;
            if (entity.ElementID == null)
            {
                entity.ElementID = "Element" + Guid.NewGuid();
            }
            try
            {
                model1.Shapes.Add(entity.ElementID, table);
            }
            catch (Exception)
            {

            }

            table.LocationChanged += table_LocationChanged;
            table.SelectedChanged += properGridCtrl.Ins.table_SelectedChanged;

            AppConf.Ins.views_enkey.Add(entity, table);
            AppConf.Ins.views_tbkey.Add(table, entity);

            return table;
        }

        void table_LocationChanged(object sender, LocationChangedEventArgs e)
        {
            if (AppConf.Ins.views_tbkey.ContainsKey(formConf.Editedtable))
            {
                EntityInfo entity = AppConf.Ins.views_tbkey[formConf.Editedtable];
                entity.X = Int32.Parse(e.Location.X.ToString());
                entity.Y = Int32.Parse(e.Location.Y.ToString());
            }
        }

        public Table NewEntity(Model model1)
        {
            formConf.Editedtable = NewEntity(model1, 100, 50);
            return formConf.Editedtable;
        }
        public Form classForm;

        public void InitModelEvent(Model model1, Form _classForm) {
            this.classForm = _classForm;

            model1.ElementDoubleClick += model1_ElementDoubleClick;
            model1.DiagramDoubleClick += model1_DiagramDoubleClick;
            model1.ElementInserted += model1_ElementInserted;
            model1.ElementRemoved += model1_ElementRemoved;
            model1.MouseMove += model1_MouseMove;

            model1.ElementMouseDown += model1_ElementMouseDown;
            model1.MouseUp += model1_MouseUp;
        }

        void model1_MouseUp(object sender, MouseEventArgs e)
        {
            Element els = (sender as Model).ElementFromPoint(e);
            if (els != null)
            {
                formConf.MouseUpTable = els as Table;
            }
        }

        void model1_ElementMouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Table)
            {
                formConf.MouseDownTable = sender as Table;
            }
        }

        void model1_ElementInserted(object sender, ElementsEventArgs e)
        {
            //插入时候调用的方法，要判断是否已经在模型内存在，如果不存在，则加一个新的
            if (e.Value is Table)
            {
                Table table = e.Value as Table;
                EntityInfo ent = table.Tag as EntityInfo;

                if (!formConf.ContainEntity(ent)) // 包含就不用管，不包含要加入关联.
                {
                    //ProTreeCtrl.Ins.CheckedModule.Entitys.Add(ent);
                    //ProTreeCtrl.Ins.ReLoadTree();
                    //ProTreeCtrl.Ins.ReloadModule();

                    MessageBox.Show("暂时不支持复制、剪贴，请不要尝试 CTRL+C、CTRL+V.","无法撤销警告");
                    //EntityInfo newen = ent.Clone();
                    //table.LocationChanged += table_LocationChanged;
                    //table.SelectedChanged += properGridCtrl.Ins.table_SelectedChanged;

                    //AppConf.Ins.views_enkey.Add(ent, table);
                    //AppConf.Ins.views_tbkey.Add(table, ent);

                    //ProTreeCtrl.Ins.CheckedModule.Entitys.Add(ent);
                    //ProTreeCtrl.Ins.ReLoadTree();
                }
            }
            else if (e.Value is Line)
            {
                try
                {
                    if (formConf.MouseDownTable != null)
                    {
                        if (formConf.MouseUpTable != null)
                        {
                            Console.WriteLine("MouseDown:" + formConf.MouseDownTable.ToString());

                            formConf.MouseUpTable = (sender as Model).CurrentMouseElements.MouseMoveElement as Table;
                            Console.WriteLine("MouseUp:" + formConf.MouseUpTable.ToString());

                            ConnInfo con = new ConnInfo();
                            con.SrcElementID = formConf.MouseDownTable.ToString();
                            con.TargetElementID = formConf.MouseUpTable.ToString();
                            con.linetype = formConf.linetype;

                            if (!formConf.lineConKeys.Keys.Contains((Line)e.Value))
                            {
                                formConf.conLineKeys.Add(con, (Line)e.Value);
                                formConf.lineConKeys.Add((Line)e.Value, con);

                                AppConf.Ins.Application.Conns.Add(con);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 模型被删除了，要找到对应的对象，然后删除之.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void model1_ElementRemoved(object sender, ElementsEventArgs e)
        {
            try
            {
                if (e.Value is Table)
                {
                    Table table = e.Value as Table;
                    EntityInfo ent = table.Tag as EntityInfo;
                    AppConf.Ins.views_enkey.Remove(ent);
                    AppConf.Ins.views_tbkey.Remove(table);

                    if (formConf.ContainEntity(ent)) // 包含就不用管，不包含要加入关联.
                    {
                        ModuleInfo mo = formConf.GetEntityModule(ent);
                        if (mo != null)
                        {
                            mo.Entitys.Remove(ent);
                        }
                    }
                    // 从系统内删除这些EntityInfo.
                    //EntityInfo newent = ent.Clone();
                    ProTreeCtrl.Ins.ReLoadTree();
                }
                else if (e.Value is Line)
                {
                    if (formConf.lineConKeys.Keys.Contains((Line)e.Value))
                    {
                        ConnInfo con = formConf.lineConKeys[(Line)e.Value];

                        if (AppConf.Ins.Application.Conns.Contains(con))
                        {
                            AppConf.Ins.Application.Conns.Remove(con);
                        }
                        formConf.lineConKeys.Remove((Line)e.Value);
                        formConf.conLineKeys.Remove(con);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        Point currentPoint = new Point();

        void model1_MouseMove(object sender, MouseEventArgs e)
        {
            currentPoint = new Point(e.X, e.Y);
        }

        private void model1_DiagramDoubleClick(object sender, EventArgs e)
        {
            formConf.Editedtable = ClassDiagCtrl.Ins.NewEntity(sender as Model, currentPoint.X - 20, currentPoint.Y - 20);
            ProTreeCtrl.Ins.ReLoadTree();
        }
        void model1_ElementDoubleClick(object sender, EventArgs e)
        {
            formConf.Editedtable = sender as Table;
            EntityInfo entity = AppConf.Ins.views_tbkey[formConf.Editedtable];
            //MessageBox.Show(entity.ToString());

            FMEntityEditor editor = new FMEntityEditor();
            editor.entity = entity;
            editor.WindowState = FormWindowState.Maximized;
            editor.RefreshModeltable += editor_RefreshModeltable;
            editor.Show();
            //MessageBox.Show(sender.ToString());
        }

        public void editor_RefreshModeltable(EntityInfo _entity)
        {
            if (formConf.Editedtable != null)
            {
                if (AppConf.Ins.views_enkey.Keys.Contains(_entity))
                {
                    formConf.Editedtable = AppConf.Ins.views_enkey[_entity];

                    string cons = "conscount:" + _entity.constraints.Count + "  ";
                    foreach (ConstraintInfo c in _entity.constraints)
                    {
                        cons += "\n" + c.Constraint_name + ",";
                    }
                    formConf.Editedtable.Heading = _entity.EntityName;
                    formConf.Editedtable.SubHeading = _entity.ClassName + "[" + cons + "]\n" + "   [" + _entity.Attributes.Count.ToString() + " Fields]";
                    
                    ProTreeCtrl.Ins.ReLoadTree();
                }
            }
        }

        /// <summary>
        /// 从外部加载，并且加载到模型上面.
        /// </summary>
        /// <param name="model"></param>
        public void LoadAndRefreshModel(Model model)
        {
            foreach (EntityInfo _entity in AppConf.Ins.Application.Modules[0].Entitys)
            {
                NewTable(model, _entity);
            }
        }

        public Model currentModel;
        /// <summary>
        /// 清空模型.
        /// </summary>
        public void ClearModel()
        {
            this.currentModel.Clear();
        }
        public void LoadFromModuleInfo(ModuleInfo module)
        {
            foreach (EntityInfo _entity in module.Entitys)
            {
                NewTable(currentModel, _entity);
            }
        }
        /// <summary>
        /// 从数据库内导入，前提，之前操作的记录都有保存.
        /// </summary>
        /// <param name="entities"></param>
        public void LoadFromDatabase(List<EntityInfo> entities, ModuleInfo mod)
        {
            AppConf.Ins.views_enkey = new Dictionary<EntityInfo, Table>();
            AppConf.Ins.views_tbkey = new Dictionary<Table, EntityInfo>();

            //AppConf.Ins.Application = null;
            ProTreeCtrl.Ins.ReLoadTree();

            int i = 0;
            int X = 20;
            int Y = 70;
            foreach (EntityInfo _entity in entities)
            {
                i++;
                X += 180;
                if (i % 6 == 0)
                {
                    Y += 100;
                    X = 20;
                }
                _entity.X = X;
                _entity.Y = Y;
                mod.Entitys.Add(_entity);
                NewTable(currentModel, _entity);
            }

            ProTreeCtrl.Ins.ReLoadTree();
        }
    }
}
