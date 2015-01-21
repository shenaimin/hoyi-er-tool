namespace Hoyi.forms
{
    partial class FMExeCute2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMExeCute2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeEnts = new System.Windows.Forms.TreeView();
            this.btnExec = new System.Windows.Forms.Button();
            this.txModuleNameSpace = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnFolderChecker = new System.Windows.Forms.Button();
            this.txSaveFolder = new System.Windows.Forms.TextBox();
            this.txDatabaseOperateClass = new System.Windows.Forms.TextBox();
            this.txWebNameSpace = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkTemplate = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
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
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(753, 637);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeEnts);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnExec);
            this.splitContainer2.Panel2.Controls.Add(this.txModuleNameSpace);
            this.splitContainer2.Panel2.Controls.Add(this.label12);
            this.splitContainer2.Panel2.Controls.Add(this.btnFolderChecker);
            this.splitContainer2.Panel2.Controls.Add(this.txSaveFolder);
            this.splitContainer2.Panel2.Controls.Add(this.txDatabaseOperateClass);
            this.splitContainer2.Panel2.Controls.Add(this.txWebNameSpace);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.chkTemplate);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Size = new System.Drawing.Size(753, 587);
            this.splitContainer2.SplitterDistance = 193;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeEnts
            // 
            this.treeEnts.CheckBoxes = true;
            this.treeEnts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeEnts.Location = new System.Drawing.Point(0, 0);
            this.treeEnts.Name = "treeEnts";
            this.treeEnts.Size = new System.Drawing.Size(193, 587);
            this.treeEnts.TabIndex = 0;
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(135, 536);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(105, 39);
            this.btnExec.TabIndex = 0;
            this.btnExec.Text = "生成";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // txModuleNameSpace
            // 
            this.txModuleNameSpace.Location = new System.Drawing.Point(135, 17);
            this.txModuleNameSpace.Name = "txModuleNameSpace";
            this.txModuleNameSpace.Size = new System.Drawing.Size(260, 21);
            this.txModuleNameSpace.TabIndex = 23;
            this.txModuleNameSpace.Text = "HSAManager";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "应用程序命名空间：";
            // 
            // btnFolderChecker
            // 
            this.btnFolderChecker.Location = new System.Drawing.Point(135, 170);
            this.btnFolderChecker.Name = "btnFolderChecker";
            this.btnFolderChecker.Size = new System.Drawing.Size(71, 41);
            this.btnFolderChecker.TabIndex = 30;
            this.btnFolderChecker.Text = "选择";
            this.btnFolderChecker.UseVisualStyleBackColor = true;
            this.btnFolderChecker.Click += new System.EventHandler(this.btnFolderChecker_Click);
            // 
            // txSaveFolder
            // 
            this.txSaveFolder.Location = new System.Drawing.Point(135, 128);
            this.txSaveFolder.Multiline = true;
            this.txSaveFolder.Name = "txSaveFolder";
            this.txSaveFolder.Size = new System.Drawing.Size(359, 36);
            this.txSaveFolder.TabIndex = 29;
            // 
            // txDatabaseOperateClass
            // 
            this.txDatabaseOperateClass.Location = new System.Drawing.Point(135, 90);
            this.txDatabaseOperateClass.Name = "txDatabaseOperateClass";
            this.txDatabaseOperateClass.Size = new System.Drawing.Size(260, 21);
            this.txDatabaseOperateClass.TabIndex = 27;
            this.txDatabaseOperateClass.Text = "DatabaseHelper";
            // 
            // txWebNameSpace
            // 
            this.txWebNameSpace.Location = new System.Drawing.Point(135, 54);
            this.txWebNameSpace.Name = "txWebNameSpace";
            this.txWebNameSpace.Size = new System.Drawing.Size(260, 21);
            this.txWebNameSpace.TabIndex = 25;
            this.txWebNameSpace.Text = "Module_HSAManager";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "保存目录：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "数据访问类：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "网页命名空间：";
            // 
            // chkTemplate
            // 
            this.chkTemplate.CheckOnClick = true;
            this.chkTemplate.FormattingEnabled = true;
            this.chkTemplate.Location = new System.Drawing.Point(135, 217);
            this.chkTemplate.Name = "chkTemplate";
            this.chkTemplate.Size = new System.Drawing.Size(372, 308);
            this.chkTemplate.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "模板:";
            // 
            // FMExeCute2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 637);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMExeCute2";
            this.Text = "生成代码";
            this.Load += new System.EventHandler(this.FMExeCute2_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeEnts;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.CheckedListBox chkTemplate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txModuleNameSpace;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFolderChecker;
        private System.Windows.Forms.TextBox txSaveFolder;
        private System.Windows.Forms.TextBox txDatabaseOperateClass;
        private System.Windows.Forms.TextBox txWebNameSpace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}