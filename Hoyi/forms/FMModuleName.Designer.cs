namespace Hoyi.forms
{
    partial class FMModuleName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMModuleName));
            this.label1 = new System.Windows.Forms.Label();
            this.txModuleName = new System.Windows.Forms.TextBox();
            this.btnAddModule = new System.Windows.Forms.Button();
            this.txCaption = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txSuffix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txPrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模块名:";
            // 
            // txModuleName
            // 
            this.txModuleName.Location = new System.Drawing.Point(141, 12);
            this.txModuleName.Name = "txModuleName";
            this.txModuleName.Size = new System.Drawing.Size(263, 21);
            this.txModuleName.TabIndex = 1;
            // 
            // btnAddModule
            // 
            this.btnAddModule.Location = new System.Drawing.Point(200, 155);
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.Size = new System.Drawing.Size(105, 32);
            this.btnAddModule.TabIndex = 2;
            this.btnAddModule.Text = "提交";
            this.btnAddModule.UseVisualStyleBackColor = true;
            this.btnAddModule.Click += new System.EventHandler(this.btnAddModule_Click);
            // 
            // txCaption
            // 
            this.txCaption.Location = new System.Drawing.Point(141, 93);
            this.txCaption.Name = "txCaption";
            this.txCaption.Size = new System.Drawing.Size(263, 21);
            this.txCaption.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "模块英文名:";
            // 
            // txSuffix
            // 
            this.txSuffix.Location = new System.Drawing.Point(141, 66);
            this.txSuffix.Name = "txSuffix";
            this.txSuffix.Size = new System.Drawing.Size(263, 21);
            this.txSuffix.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "后缀:";
            // 
            // txPrefix
            // 
            this.txPrefix.Location = new System.Drawing.Point(141, 39);
            this.txPrefix.Name = "txPrefix";
            this.txPrefix.Size = new System.Drawing.Size(263, 21);
            this.txPrefix.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "前缀:";
            // 
            // txType
            // 
            this.txType.Location = new System.Drawing.Point(141, 120);
            this.txType.Name = "txType";
            this.txType.Size = new System.Drawing.Size(263, 21);
            this.txType.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Type:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(89, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FMModuleName
            // 
            this.AcceptButton = this.btnAddModule;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(415, 196);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txPrefix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txSuffix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txCaption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddModule);
            this.Controls.Add(this.txModuleName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMModuleName";
            this.Text = "输入模块名";
            this.Load += new System.EventHandler(this.FMModuleName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txModuleName;
        private System.Windows.Forms.Button btnAddModule;
        private System.Windows.Forms.TextBox txCaption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txSuffix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
    }
}