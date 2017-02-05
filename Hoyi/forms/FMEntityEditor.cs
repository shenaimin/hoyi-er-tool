/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.appConf;
using Hoyi.conf;
using Hoyi.ctrl;
using Hoyi.model;
using ModelCode.ModelInfo;
using ModelCode.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.forms
{
    public partial class FMEntityEditor : Form
    {
        public FMEntityEditor()
        {
            InitializeComponent();
        }

        public delegate void RefreshModelTablehandler(EntityInfo _entity);

        public event RefreshModelTablehandler RefreshModeltable;

        public EntityInfo entity;
     

        private void FMEntityEditor_Load(object sender, EventArgs e)
        {
            txEntityName.Focus();
            foreach (string item in AttTempConf.Ins.alltemps)
            {
                cmbTemplate.Items.Add(item);
            }
            if (AttTempConf.Ins.alltemps.Count > 0)
            {
                cmbTemplate.SelectedIndex = 0;
            }
            cmbMySQLDataType.DataSource = Enum.GetValues(typeof(MySqlDbType));

            this.splitContainer3.Panel2Collapsed = true;
            if (entity == null)
            {
                entity = new EntityInfo();
            }
            chkNeedFPYTable.Checked = entity.NeedfpyTable;
            txNotes.Text = entity.Notes;

            BindAttributes();
            BindConstraintAtt();
        }
        /// <summary>
        /// 绑定外键字段.
        /// </summary>
        public void BindConstraintAtt()
        {
            cmbSrcAttribute.Items.Clear();

            cmbSrcAttribute.DisplayMember = "ColumnName";
            foreach (AttributeInfo att in entity.Attributes)
            {
                cmbSrcAttribute.Items.Add(att);
            }
            if (entity.Attributes.Count > 0)
            {
                cmbSrcAttribute.SelectedIndex = 0;
            }

            cmbTargeTable.Items.Clear();
            cmbTargeTable.DisplayMember = "ClassName";

            cmbTargeTable.SelectedIndexChanged += cmbTargeTable_SelectedIndexChanged;

            foreach (EntityInfo ent in formConf.getConfEntity())
            {
                cmbTargeTable.Items.Add(ent);
            }
            if (formConf.getConfEntity().Count > 0)
            {
                cmbTargeTable.SelectedIndex = 0;
            }

            datagridContraint.DataSource = null;
            CONSCTRL cons = new CONSCTRL();
            cons.Copyfrom(entity);
            datagridContraint.DataSource = cons.cons;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ConnCtrl.Ins.AddConstraint(txForignName.Text, entity, (cmbSrcAttribute.SelectedItem as AttributeInfo), (cmbTargeTable.SelectedItem as EntityInfo), (cmbTargetAttribute.SelectedItem as AttributeInfo));

            if (chkDrawLine.Checked)
            {
                // 表跟表中画一条直线.
                ConnCtrl.Ins.AddLine(entity, (cmbTargeTable.SelectedItem as EntityInfo));
            }
            BindConstraintAtt();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ConstraintInfo cons;
                EntityInfo entity2;
                foreach (DataGridViewRow item in datagridContraint.SelectedRows)
                {
                    cons = entity.constraints[item.Index];
                    entity2 = AppConf.Ins.getEntiByEnname(cons.REFERENCED_TABLE_NAME);
                    ConnCtrl.Ins.RemoveLine(entity, entity2);
                }

                foreach (DataGridViewRow item in datagridContraint.SelectedRows)
                {
                    entity.constraints.RemoveAt(item.Index);
                }

                this.BindConstraintAtt();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbSrcAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txForignName.Text = "FK_" + entity.ClassName + "_" + (cmbSrcAttribute.SelectedItem as AttributeInfo).ColumnName
                    + "_" + (cmbTargeTable.SelectedItem as EntityInfo).ClassName
                    + "_" + (cmbTargetAttribute.SelectedItem as AttributeInfo).ColumnName;
            }
            catch (Exception ex)
            {
            }
        }

        void cmbTargeTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTargetAttribute.Items.Clear();
            cmbTargetAttribute.DisplayMember = "ColumnName";
            EntityInfo ee = cmbTargeTable.SelectedItem as EntityInfo;
            foreach (AttributeInfo att in ee.Attributes)
            {
                cmbTargetAttribute.Items.Add(att);
            }
            if (ee.Attributes.Count > 0)
            {
                cmbTargetAttribute.SelectedIndex = 0;
            }
        }

        public void BindAttributes()
        {
            this.txEntityName.Text = entity.EntityName;
            this.tx_ClassName.Text = entity.ClassName;

            AttributeRows rows = new AttributeRows();
            rows.CopyFromAttrs(entity.Attributes);
            gridAttributes.DataSource = null;
            gridAttributes.DataSource = rows.rows;

            checkedRowIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(entity.ToString());
        }

        private void txEntityName_TextChanged(object sender, EventArgs e)
        {
            if (entity != null)
            {
                entity.EntityName = txEntityName.Text;
            }
        }

        private void tx_ClassName_TextChanged(object sender, EventArgs e)
        {
            if (entity != null)
            {
                entity.ClassName = tx_ClassName.Text;
            }
        }

        private void gridAttributes_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("双击了第" + e.RowIndex + "行");
            AttributeInfo attr = entity.Attributes[e.RowIndex];

            tx_AttributeName.Text = attr.Comment;
            txColumnName.Text = attr.ColumnName;
            chkPrimaryKey.Checked = attr.IsPK;

            rdbAllowNullY.Checked = attr.cisNull;
            rdbAllowNullN.Checked = !rdbAllowNullY.Checked;
        }
        int checkedRowIndex = -1;

        private void btnDeleteAttr_Click(object sender, EventArgs e)
        {
            if (checkedRowIndex != -1)
            {
                entity.Attributes.RemoveAt(checkedRowIndex);
                this.BindAttributes();
                this.BindConstraintAtt();
            }
        }

        private void gridAttributes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkedRowIndex = e.RowIndex;
        }

        private void btnAddAttr_Click(object sender, EventArgs e)
        {
            AttributeInfo attribute = new AttributeInfo();
            //attribute.Collation = Guid.NewGuid().ToString();
            attribute.Comment = tx_AttributeName.Text;
            attribute.ColumnName = txColumnName.Text;

            entity.Attributes.Add(attribute);

            tx_AttributeName.Text = "";
            txColumnName.Text = "";
            this.BindAttributes();
            tx_AttributeName.Focus();
        }

        private void gridAttributes_SelectionChanged(object sender, EventArgs e)
        {
            checkedRowIndex = gridAttributes.CurrentRow.Index;
            //MessageBox.Show(checkedRowIndex.ToString());
        }

        private void btnAddModelAttrs_Click(object sender, EventArgs e)
        {
            List<AttributeInfo> attrs = AttrTemplateCtrl.Cr().GetTemplate(entity, cmbTemplate.SelectedItem.ToString());
            entity.Attributes.AddRange(attrs);
            this.BindAttributes();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (RefreshModeltable != null)
            {
                this.RefreshModeltable(this.entity);
            }
            ProTreeCtrl.Ins.ReLoadTree();
            base.OnClosed(e);
        }

        private void chkNeedFPYTable_CheckedChanged(object sender, EventArgs e)
        {
            entity.NeedfpyTable = chkNeedFPYTable.Checked;
        }

        public void DownAttr(int idx)
        {
            int index = idx;
            //int index = checkedRowIndex;
            entity.Attributes.kk交换(index, index + 1);
            BindAttributes();
            //gridAttributes.Rows[0].Selected = false;
            //gridAttributes.Rows[index == gridAttributes.Rows.Count - 1 ? index : index + 1].Selected = true;
            checkedRowIndex = index == gridAttributes.Rows.Count - 1 ? index : index + 1;
        }

        List<int> downidx = new List<int>();

        private void btnDownAttr_Click(object sender, EventArgs e)
        {
            if (gridAttributes.SelectedRows.Count > 0)
            {
                downidx.Clear();
                foreach (DataGridViewRow item in gridAttributes.SelectedRows)
                {
                    downidx.Add(item.Index);
                    item.Selected = false;
                }
                downidx = downidx.OrderByDescending(s => s).ToList();
                foreach (int item in downidx)
                {
                    entity.Attributes.kk移动(item, item + 1);
                    //entity.Attributes.kk交换(item, item + 1);
                }
                BindAttributes();

                foreach (DataGridViewRow item in gridAttributes.Rows)
                {
                    item.Selected = false;
                }
                
                foreach (int item in downidx)
                {
                    try
                    {
                        gridAttributes.Rows[item + 1].Selected = true;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else if (checkedRowIndex < gridAttributes.Rows.Count)
            {
                DownAttr(checkedRowIndex);
                gridAttributes.Rows[0].Selected = false;
                gridAttributes.Rows[checkedRowIndex == gridAttributes.Rows.Count - 1 ? checkedRowIndex : checkedRowIndex + 1].Selected = true;
            }
        }

        public void UpAttr(int idx)
        {
            //gridAttributes.Rows[0].Selected = false;
            //gridAttributes.Rows[index == gridAttributes.Rows.Count - 1 ? index : index + 1].Selected = true;

            int index = idx;
            entity.Attributes.kk交换(index, index - 1);
            BindAttributes();
            //gridAttributes.Rows[0].Selected = false;
            //gridAttributes.Rows[index == 0 ? index : index - 1].Selected = true;
            checkedRowIndex = index == 0 ? index : index - 1;
        }

        private void btnUpAttr_Click(object sender, EventArgs e)
        {
            if (gridAttributes.SelectedRows.Count > 0)
            {
                downidx.Clear();
                foreach (DataGridViewRow item in gridAttributes.SelectedRows)
                {
                    downidx.Add(item.Index);
                    item.Selected = false;
                }
                downidx = downidx.OrderBy(s => s).ToList();
                for (int i = 0; i < downidx.Count; i++)
                //for (int i = (downidx.Count -1); i >=0; i--)
                //foreach (int item in downidx)
                {
                    var item = downidx[i];
                    entity.Attributes.kk移动(item, item - 1);
                    //entity.Attributes.kk交换(item, item - 1);
                }

                BindAttributes();


                foreach (DataGridViewRow item in gridAttributes.Rows)
                {
                    item.Selected = false;
                }
               
                foreach (int item in downidx)
                {
                    try
                    {
                        gridAttributes.Rows[item - 1].Selected = true;
                    }
                    catch (Exception)
                    {

                    }
                }
                
            }
            else if (checkedRowIndex >= 0)
            {
                UpAttr(checkedRowIndex);
                gridAttributes.Rows[0].Selected = false;
                gridAttributes.Rows[checkedRowIndex == 0 ? checkedRowIndex : checkedRowIndex - 1].Selected = true;
                //checkedRowIndex = index == 0 ? index : index - 1;
            }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (gridAttributes.SelectedRows.Count > 0)
            {
                downidx.Clear();
                foreach (DataGridViewRow item in gridAttributes.SelectedRows)
                {
                    downidx.Add(item.Index);
                    item.Selected = false;
                }

                downidx = downidx.OrderBy(s => s).ToList();
                for (int i = 0; i < downidx.Count; i++)
                    //for (int i = (downidx.Count - 1); i >= 0; i--)
                {
                    entity.Attributes.kk移动(downidx[i], i);
                }
                BindAttributes();
                for (int i = 0; i < downidx.Count; i++)
                {
                    gridAttributes.Rows[i].Selected = true;
                }
            }
            else if (checkedRowIndex >= 0){
                int index = checkedRowIndex;
                entity.Attributes.kk顶部(index);
                BindAttributes();
                gridAttributes.Rows[0].Selected = false;
                gridAttributes.Rows[0].Selected = true;
                //checkedRowIndex = index == 0 ? index : index - 1;
                checkedRowIndex = 0;
            }
        }
        /// <summary>
        /// 置底
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (gridAttributes.SelectedRows.Count > 0)
            {
                downidx.Clear();
                foreach (DataGridViewRow item in gridAttributes.SelectedRows)
                {
                    downidx.Add(item.Index);
                    item.Selected = false;
                }

                downidx = downidx.OrderByDescending(s => s).ToList();
                for (int i = 0; i < downidx.Count; i++)
                    //for (int i = (downidx.Count - 1); i >= 0; i--)
                {
                    entity.Attributes.kk移动(downidx[i], gridAttributes.Rows.Count - 1 - i);
                }

                BindAttributes();
                foreach (DataGridViewRow item in gridAttributes.Rows)
                {
                    item.Selected = false;
                }
                for (int i = gridAttributes.Rows.Count - 1; i > gridAttributes.Rows.Count - 1 - downidx.Count; i--)
                {
                    gridAttributes.Rows[i].Selected = true;
                }
            }else if (checkedRowIndex < gridAttributes.Rows.Count){
                int index = checkedRowIndex;
                entity.Attributes.kk底部(index);
                BindAttributes();
                gridAttributes.Rows[0].Selected = false;
                gridAttributes.Rows[gridAttributes.Rows.Count - 1].Selected = true;
                //checkedRowIndex = index == gridAttributes.Rows.Count - 1 ? index : index + 1;

                checkedRowIndex = gridAttributes.Rows.Count - 1; ;
            }
        }

        private void btnCopyAndUni_Click(object sender, EventArgs e)
        {
            // 将目标表的字段拷贝并插入当前表中，

            AttributeInfo att = (cmbTargetAttribute.SelectedItem as AttributeInfo).Clone();
            att.IsPK =  false;
            att.IsIdentity  = false;
            entity.Attributes.Add(att);

            // 给当前表加上外键.

            ConnCtrl.Ins.AddConstraint("", entity, att, (cmbTargeTable.SelectedItem as EntityInfo), att);

            if (chkDrawLine.Checked)
            {
                // 表跟表中画一条直线.
                ConnCtrl.Ins.AddLine(entity, (cmbTargeTable.SelectedItem as EntityInfo));
            }

            BindAttributes();
            BindConstraintAtt();
        }


        private void btnNewRelation_Click(object sender, EventArgs e)
        {
            // 拷贝两个主键表的字段，添加到新建的关系表内.

            EntityInfo entity1 = entity;
            EntityInfo entity2 = cmbTargeTable.SelectedItem as EntityInfo;

            AttributeInfo att1 = (cmbSrcAttribute.SelectedItem as AttributeInfo).Clone();
            AttributeInfo att2 = (cmbTargetAttribute.SelectedItem as AttributeInfo).Clone();

            EntityInfo relation = new EntityInfo();

            ModuleInfo module = AppConf.Ins.getByEntityInfo(entity1);
            string ClassName = "";
            if (module.Prefix != null && module.Prefix != "")
            {
                ClassName = module.Prefix + "r_" + entity1.ClassName.Replace(module.Prefix, "") + "_" + entity2.ClassName.Replace(module.Prefix, "");
            }
            else {

                ClassName = "r_" + entity1.ClassName + "_" + entity2.ClassName;
            }

            relation.EntityName = entity.EntityName + " " + entity2.EntityName + " 关联表";
            relation.ClassName = ClassName;
            att1.IsPK = att2.IsPK = false;
            att1.IsIdentity = att2.IsIdentity = false;
            relation.Attributes.Add(att1);
            relation.Attributes.Add(att2);

            formConf.GetEntityModule(entity1).Entitys.Add(relation);

            ClassDiagCtrl.Ins.NewRelationTable(relation);

            // 给两个主表加上外键约束.

            ConnCtrl.Ins.AddConstraint("", entity1, att1, relation, att1);
            ConnCtrl.Ins.AddConstraint("", entity2, att2, relation, att2);

            // 给两个表画线。 条件，如果两个表都是在同一个模块下面，则画，否则，不鸟.

            ModuleInfo module1 = AppConf.Ins.getByEntityInfo(entity1);
            ModuleInfo module2 = AppConf.Ins.getByEntityInfo(entity2);

            if (chkDrawLine.Checked)
            {
                if (module1.Equals(module2))
                {
                    ConnCtrl.Ins.AddLine(entity1, relation);
                    ConnCtrl.Ins.AddLine(entity2, relation);
                }
            }

            if (RefreshModeltable != null)
            {
                this.RefreshModeltable(entity1);
                this.RefreshModeltable(entity2);
            }
            BindConstraintAtt();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ConstraintInfo cons;
                EntityInfo entity2;
                foreach (DataGridViewRow item in datagridContraint.Rows)
                {
                    cons = entity.constraints[item.Index];
                    entity2 = AppConf.Ins.getEntiByEnname(cons.REFERENCED_TABLE_NAME);
                    ConnCtrl.Ins.RemoveLine(entity, entity2);
                }

                foreach (DataGridViewRow item in datagridContraint.Rows)
                {
                    entity.constraints.RemoveAt(item.Index);
                }

                this.BindConstraintAtt();
            }
            catch (Exception ex)
            {

            }
        }
        private void txNotes_TextChanged(object sender, EventArgs e)
        {
            if (entity != null)
            {
                entity.Notes = txNotes.Text;
            }
        }

        public List<AttributeInfo> checkattrs = new List<AttributeInfo>();

        private void cmbsysfield_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    List<AttributeInfo> attrs = new List<AttributeInfo>();

                    AttributeInfo att = checkattrs[cmbsysfield.SelectedIndex];

                    att.IsPK = false;
                    att.IsIdentity = false;

                    attrs.Add(att);
                    entity.Attributes.AddRange(attrs);
                    this.BindAttributes();
                }
                catch (Exception)
                {
                }
            }
        }

        private void cmbsysfield_TextUpdate(object sender, EventArgs e)
        {
            cmbsysfield.DroppedDown = true;
            cmbsysfield.Items.Clear();
            checkattrs.Clear();


            foreach (ModuleInfo item in AppConf.Ins.Application.Modules)
            {
                foreach (EntityInfo ents in item.Entitys)
                {
                    foreach (AttributeInfo attrs in ents.Attributes)
                    {
                        if (attrs.ColumnName.Contains(cmbsysfield.Text) || attrs.Comment.Contains(cmbsysfield.Text))
                        {
                            checkattrs.Add(attrs);
                        }
                    }
                }
            }

            foreach (AttributeInfo item in checkattrs)
            {
                cmbsysfield.Items.Add(item.Comment + "(" + item.ColumnName + ")");
            }

            cmbsysfield.SelectionStart = cmbsysfield.Text.Length;
        }
        /// <summary>
        /// 检索出来的templatename.
        /// </summary>
        public List<String> checkedtempalte = new List<string>();

        private void cmbchecktemplate_TextUpdate(object sender, EventArgs e)
        {
            cmbchecktemplate.DroppedDown = true;
            cmbchecktemplate.Items.Clear();
            checkedtempalte.Clear();

            foreach (String item in AttTempConf.Ins.alltemps)
            {
                if (item.Contains(cmbchecktemplate.Text))
                {
                    checkedtempalte.Add(item);
                }
            }
            foreach (String item in checkedtempalte)
            {
                cmbchecktemplate.Items.Add(item);
            }

            cmbchecktemplate.SelectionStart = cmbchecktemplate.Text.Length;
        }

        private void cmbchecktemplate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                try
                {
                    List<AttributeInfo> attrs = new List<AttributeInfo>();
                    attrs =   AttrTemplateCtrl.Cr().GetTemplate(entity, cmbchecktemplate.SelectedItem.ToString());
                    entity.Attributes.AddRange(attrs);
                    this.BindAttributes();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
