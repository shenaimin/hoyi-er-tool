/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using ModelCode.Model;
using ModelCode.ModelInfo;
using ModelCode.CreateBusiness;
using Hoyi.ctrl;
using Hoyi.model;

namespace ModelCode
{
    public partial class ConfigForm : Form
    {
        /// <summary>
        /// 要操作的表
        /// </summary>
        public EntityInfo Table { get; set; }
        /// <summary>
        /// 操作列表.
        /// </summary>
        public List<IOperater> Operaters { get; set; }
        /// <summary>
        /// 父窗体个数列表的序号.
        /// </summary>
        public int ParentITEMIDX = 0;

        public delegate void RefreshOperateCount(int x, string count);

        public event RefreshOperateCount RefreshOpera;

        public delegate void RefreshOperate2(EntityInfo ent);

        public event RefreshOperate2 RefreshOpera2;

        public ConfigForm()
        {
            InitializeComponent();

            DEFAULT_OPERATE_READER.Instance.INIT_DEFAULT_OPERA();
            List<string> default_OPS = DEFAULT_OPERATE_READER.Instance.ALL_OPERATES;
            lbAddOperate.Items.Clear();
            foreach (string op in default_OPS)
            {
                lbAddOperate.Items.Add(op);
            }

            lbAddOperate.SelectedIndex = 0;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            DEFAULT_OPERATE_READER.Instance.INIT_DEFAULT_OPERA();

            if (this.Table.operaters.Count <= 0)
            {
                //if (this.Operaters == null)
                //{
                    this.Operaters = DEFAULT_OPERATE_READER.Instance.DEFAULT_OPERATE;
                //}
            }
            else
            {
                this.Operaters = this.Table.operaters;
            }
            Table.operaters = this.Operaters;

            this.Text += this.Table.EntityName + "[" + this.Table.ClassName + "]";
            this.lbTable.Text = this.Table.ClassName;
            this.lbFieldList.DataSource = this.Table.Attributes;
            this.lbFieldList.DisplayMember = "ColumnName";
            this.BindOperater();
        }

        private void lbDelete_Click(object sender, EventArgs e)
        {
            int i = lbOperaterList.SelectedIndex;
            if (lbOperaterList.SelectedItem == null)
                return;
            this.Operaters.Remove(this.lbOperaterList.Items[i] as IOperater);
            this.lbFieldName.Items.Remove(lbFieldName.Items[i]);
            lbOperaterList.Items.Remove(lbOperaterList.Items[i]);

            this.REFRESH_OPERA();
            lbFieldName.SelectedIndex = lbFieldName.Items.Count - 1;
        }

        public void BindOperater()
        {
            this.lbOperaterList.Items.Clear();
            this.lbFieldName.Items.Clear();

            if (cbSort.Checked)
            {
                var query = from a in Operaters
                            orderby a.Type
                            select a;

                this.Operaters = query.ToList();
            }

            foreach (IOperater op in this.Operaters)
            {
                this.lbOperaterList.Items.Add(op);
                string fields = "";
                for (int i = 0; i < op.FieldIndex.Count; i++)
                {
                    fields += this.Table.Attributes[op.FieldIndex[i]].ColumnName + ",";
                }
                if (fields.Length > 0)
                    fields = fields.Substring(0, fields.Length - 1);
                this.lbFieldName.Items.Add(fields);
            }
            this.lbOperaterList.DisplayMember = "Type";
        }

        private void lbFinidshed_Click(object sender, EventArgs e)
        {
            //SingleOperate sops = ParenterForm.Opers.Operaters.Single(op => op.Tables == this.Table) as SingleOperate;
            //ParenterForm.Opers.Operaters.Remove(sops);
            //SingleOperate sop = new SingleOperate(this.Table, this.GetListOpera());
            //ParenterForm.Opers.Operaters.Add(sop);
            
            this.Close();
        }

        public void SetEntities()
        {
            this.Table.operaters = this.GetListOpera();

            this.REFRESH_OPERA();
        }

        protected override void OnClosed(EventArgs e)
        {
            SetEntities();

            base.OnClosed(e);
        }
        /// <summary>
        /// 获取List内的操作列表.
        /// </summary>
        /// <returns></returns>
        public List<IOperater> GetListOpera()
        {
            List<IOperater> ops = new List<IOperater>();
            foreach (var item in lbOperaterList.Items)
            {
                ops.Add(item as IOperater);
            }
            return ops;
        }

        public void REFRESH_OPERA()
        {
            if (this.RefreshOpera != null)
            {
                this.RefreshOpera(this.ParentITEMIDX, this.Operaters.Count.ToString());
            }
            if (this.RefreshOpera2 != null)
            {
                this.RefreshOpera2(this.Table);
            }
        }

        private void lbOperaterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbFieldName.SelectedIndex = lbOperaterList.SelectedIndex;
        }

        private void lbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbOperaterList.SelectedIndex = lbFieldName.SelectedIndex;
        }

        private void lbAdd_Click(object sender, EventArgs e)
        {
            // 先获取到操作列表.

            List<string> operats = new List<string>();
            foreach (string op in lbAddOperate.SelectedItems)
            {
                operats.Add(op);
            }

            List<int> fieldops = new List<int>();

            for (int i = 0; i < lbFieldList.SelectedIndices.Count; i++)
            {
                fieldops.Add(lbFieldList.SelectedIndices[i]);
            }
            AddLog("");
            AddLog("编辑操作组.   【" + DateTime.Now.ToString() + "】");
            foreach (string op in operats)
            {
                IOperater ops = new IOperater(op, fieldops);
                if (!ContainedOPS(op, fieldops))
                {
                    this.Operaters.Add(ops);
                    AddLog("--->添加操作:" + op.ToString() + ":" + string.Join(",", fieldops.ToArray()));
                }
                else
                {
                    AddLog("已存在操作:" + op.ToString() + ":" + string.Join(",", fieldops.ToArray()));
                }
            }
            AddLog("");

            BindOperater();
            REFRESH_OPERA();
        }
        /// <summary>
        /// 判断是否已经包含当前操作。
        /// 有包含方法，返回TRUE, 否则返回FALSE。
        /// </summary>
        /// <param name="op"></param>
        /// <param name="fieldops"></param>
        /// <returns></returns>
        public bool ContainedOPS(string op, List<int> fieldops)
        {
            var query = from s in Operaters
                        where s.Type.Equals(op) && s.FieldIndex.SequenceEqual(fieldops)
                        select s;

            return query.ToList().Count > 0;
        }
        /// <summary>
        /// 添加日志.
        /// </summary>
        /// <param name="log"></param>
        public void AddLog(string log)
        {
            if (lsLog.Items.Count > 1000)
            {
                lsLog.Items.Clear();
            }
            lsLog.Items.Add(log);
            lsLog.SelectedIndex = lsLog.Items.Count - 1;
        }

        private void lbFieldList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbAdd_Click(null, null);
        }

        private void lbAddOperate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbAdd_Click(null, null);
        }

        private void lbFieldName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lbDelete_Click(null, null);
        }
    }
}
