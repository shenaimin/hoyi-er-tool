namespace Hoyi.forms
{
    partial class FMGenSQL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMGenSQL));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkQiangDeleteFPY = new System.Windows.Forms.CheckBox();
            this.chkQiangFPY = new System.Windows.Forms.CheckBox();
            this.chkDeleteFPY = new System.Windows.Forms.CheckBox();
            this.chkFPY = new System.Windows.Forms.CheckBox();
            this.chkFornAddPre = new System.Windows.Forms.CheckBox();
            this.chkRemoveFor = new System.Windows.Forms.CheckBox();
            this.chkCreateTable = new System.Windows.Forms.CheckBox();
            this.chkForn = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkSuffix = new System.Windows.Forms.CheckBox();
            this.chkPre = new System.Windows.Forms.CheckBox();
            this.txEngine = new System.Windows.Forms.TextBox();
            this.chkEngine = new System.Windows.Forms.CheckBox();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.txEncode = new System.Windows.Forms.TextBox();
            this.chkEncode = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnPre = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.rtxSQL = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.chkQiangDeleteFPY);
            this.splitContainer1.Panel1.Controls.Add(this.chkQiangFPY);
            this.splitContainer1.Panel1.Controls.Add(this.chkDeleteFPY);
            this.splitContainer1.Panel1.Controls.Add(this.chkFPY);
            this.splitContainer1.Panel1.Controls.Add(this.chkFornAddPre);
            this.splitContainer1.Panel1.Controls.Add(this.chkRemoveFor);
            this.splitContainer1.Panel1.Controls.Add(this.chkCreateTable);
            this.splitContainer1.Panel1.Controls.Add(this.chkForn);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.chkSuffix);
            this.splitContainer1.Panel1.Controls.Add(this.chkPre);
            this.splitContainer1.Panel1.Controls.Add(this.txEngine);
            this.splitContainer1.Panel1.Controls.Add(this.chkEngine);
            this.splitContainer1.Panel1.Controls.Add(this.chkComment);
            this.splitContainer1.Panel1.Controls.Add(this.txEncode);
            this.splitContainer1.Panel1.Controls.Add(this.chkEncode);
            this.splitContainer1.Panel1.Controls.Add(this.chkDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btnPre);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1059, 627);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(942, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 56);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkQiangDeleteFPY
            // 
            this.chkQiangDeleteFPY.AutoSize = true;
            this.chkQiangDeleteFPY.Location = new System.Drawing.Point(469, 47);
            this.chkQiangDeleteFPY.Name = "chkQiangDeleteFPY";
            this.chkQiangDeleteFPY.Size = new System.Drawing.Size(102, 16);
            this.chkQiangDeleteFPY.TabIndex = 18;
            this.chkQiangDeleteFPY.Text = "强制删除FPY表";
            this.chkQiangDeleteFPY.UseVisualStyleBackColor = true;
            // 
            // chkQiangFPY
            // 
            this.chkQiangFPY.AutoSize = true;
            this.chkQiangFPY.Location = new System.Drawing.Point(470, 12);
            this.chkQiangFPY.Name = "chkQiangFPY";
            this.chkQiangFPY.Size = new System.Drawing.Size(102, 16);
            this.chkQiangFPY.TabIndex = 17;
            this.chkQiangFPY.Text = "强制创建FPY表";
            this.chkQiangFPY.UseVisualStyleBackColor = true;
            // 
            // chkDeleteFPY
            // 
            this.chkDeleteFPY.AutoSize = true;
            this.chkDeleteFPY.Checked = true;
            this.chkDeleteFPY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteFPY.Location = new System.Drawing.Point(386, 47);
            this.chkDeleteFPY.Name = "chkDeleteFPY";
            this.chkDeleteFPY.Size = new System.Drawing.Size(78, 16);
            this.chkDeleteFPY.TabIndex = 16;
            this.chkDeleteFPY.Text = "删除FPY表";
            this.chkDeleteFPY.UseVisualStyleBackColor = true;
            // 
            // chkFPY
            // 
            this.chkFPY.AutoSize = true;
            this.chkFPY.Checked = true;
            this.chkFPY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFPY.Location = new System.Drawing.Point(386, 12);
            this.chkFPY.Name = "chkFPY";
            this.chkFPY.Size = new System.Drawing.Size(78, 16);
            this.chkFPY.TabIndex = 15;
            this.chkFPY.Text = "创建FPY表";
            this.chkFPY.UseVisualStyleBackColor = true;
            // 
            // chkFornAddPre
            // 
            this.chkFornAddPre.AutoSize = true;
            this.chkFornAddPre.Location = new System.Drawing.Point(655, 12);
            this.chkFornAddPre.Name = "chkFornAddPre";
            this.chkFornAddPre.Size = new System.Drawing.Size(84, 16);
            this.chkFornAddPre.TabIndex = 14;
            this.chkFornAddPre.Text = "外键加前缀";
            this.chkFornAddPre.UseVisualStyleBackColor = true;
            // 
            // chkRemoveFor
            // 
            this.chkRemoveFor.AutoSize = true;
            this.chkRemoveFor.Location = new System.Drawing.Point(577, 47);
            this.chkRemoveFor.Name = "chkRemoveFor";
            this.chkRemoveFor.Size = new System.Drawing.Size(72, 16);
            this.chkRemoveFor.TabIndex = 13;
            this.chkRemoveFor.Text = "删除外键";
            this.chkRemoveFor.UseVisualStyleBackColor = true;
            // 
            // chkCreateTable
            // 
            this.chkCreateTable.AutoSize = true;
            this.chkCreateTable.Checked = true;
            this.chkCreateTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateTable.Location = new System.Drawing.Point(296, 12);
            this.chkCreateTable.Name = "chkCreateTable";
            this.chkCreateTable.Size = new System.Drawing.Size(60, 16);
            this.chkCreateTable.TabIndex = 12;
            this.chkCreateTable.Text = "创建表";
            this.chkCreateTable.UseVisualStyleBackColor = true;
            // 
            // chkForn
            // 
            this.chkForn.AutoSize = true;
            this.chkForn.Checked = true;
            this.chkForn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForn.Location = new System.Drawing.Point(577, 12);
            this.chkForn.Name = "chkForn";
            this.chkForn.Size = new System.Drawing.Size(72, 16);
            this.chkForn.TabIndex = 11;
            this.chkForn.Text = "生成外键";
            this.chkForn.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(836, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 56);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkSuffix
            // 
            this.chkSuffix.AutoSize = true;
            this.chkSuffix.Checked = true;
            this.chkSuffix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuffix.Location = new System.Drawing.Point(230, 47);
            this.chkSuffix.Name = "chkSuffix";
            this.chkSuffix.Size = new System.Drawing.Size(60, 16);
            this.chkSuffix.TabIndex = 9;
            this.chkSuffix.Text = "加后缀";
            this.chkSuffix.UseVisualStyleBackColor = true;
            // 
            // chkPre
            // 
            this.chkPre.AutoSize = true;
            this.chkPre.Checked = true;
            this.chkPre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPre.Location = new System.Drawing.Point(230, 12);
            this.chkPre.Name = "chkPre";
            this.chkPre.Size = new System.Drawing.Size(60, 16);
            this.chkPre.TabIndex = 8;
            this.chkPre.Text = "加前缀";
            this.chkPre.UseVisualStyleBackColor = true;
            // 
            // txEngine
            // 
            this.txEngine.Location = new System.Drawing.Point(85, 42);
            this.txEngine.Name = "txEngine";
            this.txEngine.Size = new System.Drawing.Size(139, 21);
            this.txEngine.TabIndex = 7;
            this.txEngine.Text = "InnoDB";
            // 
            // chkEngine
            // 
            this.chkEngine.AutoSize = true;
            this.chkEngine.Checked = true;
            this.chkEngine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEngine.Location = new System.Drawing.Point(7, 47);
            this.chkEngine.Name = "chkEngine";
            this.chkEngine.Size = new System.Drawing.Size(60, 16);
            this.chkEngine.TabIndex = 6;
            this.chkEngine.Text = "加引擎";
            this.chkEngine.UseVisualStyleBackColor = true;
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Checked = true;
            this.chkComment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkComment.Location = new System.Drawing.Point(655, 47);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(60, 16);
            this.chkComment.TabIndex = 5;
            this.chkComment.Text = "加备注";
            this.chkComment.UseVisualStyleBackColor = true;
            // 
            // txEncode
            // 
            this.txEncode.Location = new System.Drawing.Point(85, 7);
            this.txEncode.Name = "txEncode";
            this.txEncode.Size = new System.Drawing.Size(139, 21);
            this.txEncode.TabIndex = 4;
            this.txEncode.Text = "utf8";
            // 
            // chkEncode
            // 
            this.chkEncode.AutoSize = true;
            this.chkEncode.Checked = true;
            this.chkEncode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEncode.Location = new System.Drawing.Point(7, 12);
            this.chkEncode.Name = "chkEncode";
            this.chkEncode.Size = new System.Drawing.Size(72, 16);
            this.chkEncode.TabIndex = 3;
            this.chkEncode.Text = "加字符集";
            this.chkEncode.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(296, 47);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(84, 16);
            this.chkDelete.TabIndex = 1;
            this.chkDelete.Text = "加删表语句";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(758, 7);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 56);
            this.btnPre.TabIndex = 0;
            this.btnPre.Text = "预览";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtxSQL);
            this.splitContainer2.Size = new System.Drawing.Size(1059, 555);
            this.splitContainer2.SplitterDistance = 165;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(165, 555);
            this.treeView1.TabIndex = 0;
            // 
            // rtxSQL
            // 
            this.rtxSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxSQL.Location = new System.Drawing.Point(0, 0);
            this.rtxSQL.Name = "rtxSQL";
            this.rtxSQL.Size = new System.Drawing.Size(890, 555);
            this.rtxSQL.TabIndex = 0;
            this.rtxSQL.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ui-check-box-uncheck.png");
            this.imageList1.Images.SetKeyName(1, "ui-check-box.png");
            this.imageList1.Images.SetKeyName(2, "ui-check-box-mix.png");
            // 
            // FMGenSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1059, 627);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMGenSQL";
            this.Text = "转换成SQL";
            this.Load += new System.EventHandler(this.FMGenSQL_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox rtxSQL;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkEncode;
        private System.Windows.Forms.TextBox txEncode;
        private System.Windows.Forms.CheckBox chkComment;
        private System.Windows.Forms.TextBox txEngine;
        private System.Windows.Forms.CheckBox chkEngine;
        private System.Windows.Forms.CheckBox chkPre;
        private System.Windows.Forms.CheckBox chkSuffix;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkForn;
        private System.Windows.Forms.CheckBox chkCreateTable;
        private System.Windows.Forms.CheckBox chkRemoveFor;
        private System.Windows.Forms.CheckBox chkFornAddPre;
        private System.Windows.Forms.CheckBox chkFPY;
        private System.Windows.Forms.CheckBox chkDeleteFPY;
        private System.Windows.Forms.CheckBox chkQiangFPY;
        private System.Windows.Forms.CheckBox chkQiangDeleteFPY;
        private System.Windows.Forms.Button btnClose;
    }
}