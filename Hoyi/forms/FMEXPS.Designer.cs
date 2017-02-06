namespace Hoyi.forms
{
    partial class FMEXPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMEXPS));
            this.label1 = new System.Windows.Forms.Label();
            this.lsPre = new System.Windows.Forms.ListBox();
            this.lsStarted = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检测到上次异常关闭，下面是可还原的文件，请选择双击打开.";
            // 
            // lsPre
            // 
            this.lsPre.FormattingEnabled = true;
            this.lsPre.ItemHeight = 12;
            this.lsPre.Location = new System.Drawing.Point(17, 103);
            this.lsPre.Name = "lsPre";
            this.lsPre.Size = new System.Drawing.Size(350, 268);
            this.lsPre.TabIndex = 1;
            this.lsPre.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsPre_MouseDoubleClick);
            // 
            // lsStarted
            // 
            this.lsStarted.FormattingEnabled = true;
            this.lsStarted.ItemHeight = 12;
            this.lsStarted.Location = new System.Drawing.Point(18, 395);
            this.lsStarted.Name = "lsStarted";
            this.lsStarted.Size = new System.Drawing.Size(350, 220);
            this.lsStarted.TabIndex = 2;
            this.lsStarted.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsPre_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "启动前";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "启动后";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(15, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "点此关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FMEXPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(391, 622);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsStarted);
            this.Controls.Add(this.lsPre);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMEXPS";
            this.Text = "异常关闭";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FMEXPS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsPre;
        private System.Windows.Forms.ListBox lsStarted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}