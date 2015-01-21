namespace Hoyi.forms
{
    partial class FMTB_OUT_MOVE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMTB_OUT_MOVE));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lsCurrentModule = new System.Windows.Forms.ListBox();
            this.lsCurrentEntity = new System.Windows.Forms.ListBox();
            this.lsTargetModule = new System.Windows.Forms.ListBox();
            this.tx_url = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "现模块:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "现表:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(787, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "目标模块:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 625);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "开始迁移";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 625);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "从外部HOYI文件导入目标模块中。迁移前请注意备份。";
            // 
            // lsCurrentModule
            // 
            this.lsCurrentModule.FormattingEnabled = true;
            this.lsCurrentModule.ItemHeight = 12;
            this.lsCurrentModule.Location = new System.Drawing.Point(32, 51);
            this.lsCurrentModule.Name = "lsCurrentModule";
            this.lsCurrentModule.Size = new System.Drawing.Size(360, 568);
            this.lsCurrentModule.TabIndex = 9;
            this.lsCurrentModule.SelectedIndexChanged += new System.EventHandler(this.lsCurrentModule_SelectedIndexChanged);
            // 
            // lsCurrentEntity
            // 
            this.lsCurrentEntity.FormattingEnabled = true;
            this.lsCurrentEntity.ItemHeight = 12;
            this.lsCurrentEntity.Location = new System.Drawing.Point(398, 51);
            this.lsCurrentEntity.Name = "lsCurrentEntity";
            this.lsCurrentEntity.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsCurrentEntity.Size = new System.Drawing.Size(385, 568);
            this.lsCurrentEntity.TabIndex = 10;
            // 
            // lsTargetModule
            // 
            this.lsTargetModule.FormattingEnabled = true;
            this.lsTargetModule.ItemHeight = 12;
            this.lsTargetModule.Location = new System.Drawing.Point(789, 51);
            this.lsTargetModule.Name = "lsTargetModule";
            this.lsTargetModule.Size = new System.Drawing.Size(426, 568);
            this.lsTargetModule.TabIndex = 11;
            // 
            // tx_url
            // 
            this.tx_url.Location = new System.Drawing.Point(398, 4);
            this.tx_url.Name = "tx_url";
            this.tx_url.Size = new System.Drawing.Size(804, 21);
            this.tx_url.TabIndex = 12;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(318, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FMTB_OUT_MOVE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 660);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.tx_url);
            this.Controls.Add(this.lsTargetModule);
            this.Controls.Add(this.lsCurrentEntity);
            this.Controls.Add(this.lsCurrentModule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMTB_OUT_MOVE";
            this.Text = "迁移表";
            this.Load += new System.EventHandler(this.FMTB_MOVE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lsCurrentModule;
        private System.Windows.Forms.ListBox lsCurrentEntity;
        private System.Windows.Forms.ListBox lsTargetModule;
        private System.Windows.Forms.TextBox tx_url;
        private System.Windows.Forms.Button btnImport;
    }
}