namespace Hoyi.forms
{
    partial class FMTB_MOVE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMTB_MOVE));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lsCurrentModule = new System.Windows.Forms.ListBox();
            this.lsCurrentEntity = new System.Windows.Forms.ListBox();
            this.lsTargetModule = new System.Windows.Forms.ListBox();
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
            this.button1.Size = new System.Drawing.Size(115, 71);
            this.button1.TabIndex = 6;
            this.button1.Text = "开始迁移";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(195, 625);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 71);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "将现有模块的表迁移到目标模块中。迁移完请注意保存.";
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
            // FMTB_MOVE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1274, 706);
            this.Controls.Add(this.lsTargetModule);
            this.Controls.Add(this.lsCurrentEntity);
            this.Controls.Add(this.lsCurrentModule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMTB_MOVE";
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lsCurrentModule;
        private System.Windows.Forms.ListBox lsCurrentEntity;
        private System.Windows.Forms.ListBox lsTargetModule;
    }
}