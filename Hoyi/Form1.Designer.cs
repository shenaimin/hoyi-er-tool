namespace Hoyi
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.项目PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建项目NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开项目OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于HOYI设计AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnPhysical = new System.Windows.Forms.Button();
            this.btnLogical = new System.Windows.Forms.Button();
            this.btnusecase = new System.Windows.Forms.Button();
            this.btnAppInfo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目PToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1130, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 项目PToolStripMenuItem
            // 
            this.项目PToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建项目NToolStripMenuItem,
            this.打开项目OToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出EToolStripMenuItem});
            this.项目PToolStripMenuItem.Name = "项目PToolStripMenuItem";
            this.项目PToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.项目PToolStripMenuItem.Text = "项目(&P)";
            // 
            // 新建项目NToolStripMenuItem
            // 
            this.新建项目NToolStripMenuItem.Name = "新建项目NToolStripMenuItem";
            this.新建项目NToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.新建项目NToolStripMenuItem.Text = "新建项目(&N)";
            // 
            // 打开项目OToolStripMenuItem
            // 
            this.打开项目OToolStripMenuItem.Name = "打开项目OToolStripMenuItem";
            this.打开项目OToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.打开项目OToolStripMenuItem.Text = "打开项目(&O)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 6);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于HOYI设计AToolStripMenuItem});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // 关于HOYI设计AToolStripMenuItem
            // 
            this.关于HOYI设计AToolStripMenuItem.Name = "关于HOYI设计AToolStripMenuItem";
            this.关于HOYI设计AToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.关于HOYI设计AToolStripMenuItem.Text = "关于HOYI 设计(&A)";
            this.关于HOYI设计AToolStripMenuItem.Click += new System.EventHandler(this.关于HOYI设计AToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.btnExecute);
            this.splitContainer1.Panel1.Controls.Add(this.btnPhysical);
            this.splitContainer1.Panel1.Controls.Add(this.btnLogical);
            this.splitContainer1.Panel1.Controls.Add(this.btnusecase);
            this.splitContainer1.Panel1.Controls.Add(this.btnAppInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Size = new System.Drawing.Size(1130, 546);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExecute.Location = new System.Drawing.Point(0, 108);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(151, 27);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "生成代码";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // btnPhysical
            // 
            this.btnPhysical.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhysical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPhysical.Location = new System.Drawing.Point(0, 81);
            this.btnPhysical.Name = "btnPhysical";
            this.btnPhysical.Size = new System.Drawing.Size(151, 27);
            this.btnPhysical.TabIndex = 3;
            this.btnPhysical.Text = "物理图";
            this.btnPhysical.UseVisualStyleBackColor = true;
            // 
            // btnLogical
            // 
            this.btnLogical.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogical.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogical.Location = new System.Drawing.Point(0, 54);
            this.btnLogical.Name = "btnLogical";
            this.btnLogical.Size = new System.Drawing.Size(151, 27);
            this.btnLogical.TabIndex = 2;
            this.btnLogical.Text = "逻辑图";
            this.btnLogical.UseVisualStyleBackColor = true;
            // 
            // btnusecase
            // 
            this.btnusecase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnusecase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnusecase.Location = new System.Drawing.Point(0, 27);
            this.btnusecase.Name = "btnusecase";
            this.btnusecase.Size = new System.Drawing.Size(151, 27);
            this.btnusecase.TabIndex = 1;
            this.btnusecase.Text = "用例图";
            this.btnusecase.UseVisualStyleBackColor = true;
            // 
            // btnAppInfo
            // 
            this.btnAppInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAppInfo.Location = new System.Drawing.Point(0, 0);
            this.btnAppInfo.Name = "btnAppInfo";
            this.btnAppInfo.Size = new System.Drawing.Size(151, 27);
            this.btnAppInfo.TabIndex = 0;
            this.btnAppInfo.Text = "项目信息";
            this.btnAppInfo.UseVisualStyleBackColor = true;
            this.btnAppInfo.Click += new System.EventHandler(this.btnAppInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 571);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HOYI 设计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 项目PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建项目NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开项目OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于HOYI设计AToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAppInfo;
        private System.Windows.Forms.Button btnusecase;
        private System.Windows.Forms.Button btnLogical;
        private System.Windows.Forms.Button btnPhysical;
        private System.Windows.Forms.Button btnExecute;
    }
}

