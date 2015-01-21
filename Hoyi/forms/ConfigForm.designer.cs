namespace ModelCode
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOperaterList = new System.Windows.Forms.ListBox();
            this.lbTable = new System.Windows.Forms.Label();
            this.lbDelete = new System.Windows.Forms.Button();
            this.lbFinidshed = new System.Windows.Forms.Button();
            this.lbFieldName = new System.Windows.Forms.ListBox();
            this.cmbOpera = new System.Windows.Forms.GroupBox();
            this.lsLog = new System.Windows.Forms.ListBox();
            this.lbAddOperate = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbAdd = new System.Windows.Forms.Button();
            this.lbFieldList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSort = new System.Windows.Forms.CheckBox();
            this.cmbOpera.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "表信息:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "操作列表:[本页面双击列表可以操作]";
            // 
            // lbOperaterList
            // 
            this.lbOperaterList.FormattingEnabled = true;
            this.lbOperaterList.ItemHeight = 12;
            this.lbOperaterList.Location = new System.Drawing.Point(10, 52);
            this.lbOperaterList.Name = "lbOperaterList";
            this.lbOperaterList.Size = new System.Drawing.Size(135, 316);
            this.lbOperaterList.TabIndex = 0;
            this.lbOperaterList.SelectedIndexChanged += new System.EventHandler(this.lbOperaterList_SelectedIndexChanged);
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.Location = new System.Drawing.Point(65, 9);
            this.lbTable.Name = "lbTable";
            this.lbTable.Size = new System.Drawing.Size(41, 12);
            this.lbTable.TabIndex = 6;
            this.lbTable.Text = "label4";
            // 
            // lbDelete
            // 
            this.lbDelete.Location = new System.Drawing.Point(347, 5);
            this.lbDelete.Name = "lbDelete";
            this.lbDelete.Size = new System.Drawing.Size(176, 44);
            this.lbDelete.TabIndex = 6;
            this.lbDelete.Text = "删除";
            this.lbDelete.UseVisualStyleBackColor = true;
            this.lbDelete.Click += new System.EventHandler(this.lbDelete_Click);
            // 
            // lbFinidshed
            // 
            this.lbFinidshed.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.lbFinidshed.Location = new System.Drawing.Point(492, 46);
            this.lbFinidshed.Name = "lbFinidshed";
            this.lbFinidshed.Size = new System.Drawing.Size(150, 71);
            this.lbFinidshed.TabIndex = 5;
            this.lbFinidshed.Text = "配置完成";
            this.lbFinidshed.UseVisualStyleBackColor = true;
            this.lbFinidshed.Click += new System.EventHandler(this.lbFinidshed_Click);
            // 
            // lbFieldName
            // 
            this.lbFieldName.FormattingEnabled = true;
            this.lbFieldName.ItemHeight = 12;
            this.lbFieldName.Location = new System.Drawing.Point(144, 52);
            this.lbFieldName.Name = "lbFieldName";
            this.lbFieldName.Size = new System.Drawing.Size(379, 316);
            this.lbFieldName.TabIndex = 1;
            this.lbFieldName.SelectedIndexChanged += new System.EventHandler(this.lbFieldName_SelectedIndexChanged);
            this.lbFieldName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFieldName_MouseDoubleClick);
            // 
            // cmbOpera
            // 
            this.cmbOpera.Controls.Add(this.lsLog);
            this.cmbOpera.Controls.Add(this.lbAddOperate);
            this.cmbOpera.Controls.Add(this.label4);
            this.cmbOpera.Controls.Add(this.lbFinidshed);
            this.cmbOpera.Controls.Add(this.lbAdd);
            this.cmbOpera.Controls.Add(this.lbFieldList);
            this.cmbOpera.Controls.Add(this.label3);
            this.cmbOpera.Location = new System.Drawing.Point(529, 14);
            this.cmbOpera.Name = "cmbOpera";
            this.cmbOpera.Size = new System.Drawing.Size(724, 350);
            this.cmbOpera.TabIndex = 13;
            this.cmbOpera.TabStop = false;
            this.cmbOpera.Text = "添加操作";
            // 
            // lsLog
            // 
            this.lsLog.FormattingEnabled = true;
            this.lsLog.ItemHeight = 12;
            this.lsLog.Location = new System.Drawing.Point(336, 131);
            this.lsLog.Name = "lsLog";
            this.lsLog.Size = new System.Drawing.Size(382, 208);
            this.lsLog.TabIndex = 13;
            // 
            // lbAddOperate
            // 
            this.lbAddOperate.FormattingEnabled = true;
            this.lbAddOperate.ItemHeight = 12;
            this.lbAddOperate.Location = new System.Drawing.Point(188, 47);
            this.lbAddOperate.Name = "lbAddOperate";
            this.lbAddOperate.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAddOperate.Size = new System.Drawing.Size(142, 292);
            this.lbAddOperate.TabIndex = 3;
            this.lbAddOperate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAddOperate_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "操作列表：";
            // 
            // lbAdd
            // 
            this.lbAdd.Location = new System.Drawing.Point(336, 47);
            this.lbAdd.Name = "lbAdd";
            this.lbAdd.Size = new System.Drawing.Size(150, 68);
            this.lbAdd.TabIndex = 4;
            this.lbAdd.Text = "添加";
            this.lbAdd.UseVisualStyleBackColor = true;
            this.lbAdd.Click += new System.EventHandler(this.lbAdd_Click);
            // 
            // lbFieldList
            // 
            this.lbFieldList.FormattingEnabled = true;
            this.lbFieldList.ItemHeight = 12;
            this.lbFieldList.Location = new System.Drawing.Point(8, 47);
            this.lbFieldList.Name = "lbFieldList";
            this.lbFieldList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFieldList.Size = new System.Drawing.Size(174, 292);
            this.lbFieldList.TabIndex = 2;
            this.lbFieldList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFieldList_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "字段列表:";
            // 
            // cbSort
            // 
            this.cbSort.AutoSize = true;
            this.cbSort.Checked = true;
            this.cbSort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSort.Location = new System.Drawing.Point(243, 29);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(96, 16);
            this.cbSort.TabIndex = 14;
            this.cbSort.Text = "启用操作排序";
            this.cbSort.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.lbFinidshed;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.lbFinidshed;
            this.ClientSize = new System.Drawing.Size(1265, 376);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.cmbOpera);
            this.Controls.Add(this.lbFieldName);
            this.Controls.Add(this.lbDelete);
            this.Controls.Add(this.lbTable);
            this.Controls.Add(this.lbOperaterList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "正在配置表.";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.cmbOpera.ResumeLayout(false);
            this.cmbOpera.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbOperaterList;
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.Button lbDelete;
        private System.Windows.Forms.Button lbFinidshed;
        private System.Windows.Forms.ListBox lbFieldName;
        private System.Windows.Forms.GroupBox cmbOpera;
        private System.Windows.Forms.ListBox lbFieldList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button lbAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbAddOperate;
        private System.Windows.Forms.ListBox lsLog;
        private System.Windows.Forms.CheckBox cbSort;
    }
}