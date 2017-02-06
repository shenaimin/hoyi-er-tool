namespace Hoyi.forms
{
    partial class FMImportFDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMImportFDB));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txRemoveEntityPre = new System.Windows.Forms.TextBox();
            this.chkRemoveEntityPre = new System.Windows.Forms.CheckBox();
            this.txRemovePre = new System.Windows.Forms.TextBox();
            this.chkRemovePre = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbImportModule = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txSearch_un = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.cmbDatabase = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lsbTmpTables = new System.Windows.Forms.ListBox();
            this.lsbCheckedTables = new System.Windows.Forms.ListBox();
            this.txSearch = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.txMYSQLPORT = new System.Windows.Forms.TextBox();
            this.lbMYSQLPORT = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txpassword = new System.Windows.Forms.TextBox();
            this.txusername = new System.Windows.Forms.TextBox();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.txserver = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txRemoveEntityPre);
            this.groupBox1.Controls.Add(this.chkRemoveEntityPre);
            this.groupBox1.Controls.Add(this.txRemovePre);
            this.groupBox1.Controls.Add(this.chkRemovePre);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbImportModule);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txSearch_un);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.cmbDatabase);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.lsbTmpTables);
            this.groupBox1.Controls.Add(this.lsbCheckedTables);
            this.groupBox1.Controls.Add(this.txSearch);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btnCheckAll);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(420, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 435);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择导入表";
            // 
            // txRemoveEntityPre
            // 
            this.txRemoveEntityPre.Location = new System.Drawing.Point(317, 297);
            this.txRemoveEntityPre.Name = "txRemoveEntityPre";
            this.txRemoveEntityPre.Size = new System.Drawing.Size(195, 21);
            this.txRemoveEntityPre.TabIndex = 49;
            // 
            // chkRemoveEntityPre
            // 
            this.chkRemoveEntityPre.AutoSize = true;
            this.chkRemoveEntityPre.Location = new System.Drawing.Point(167, 301);
            this.chkRemoveEntityPre.Name = "chkRemoveEntityPre";
            this.chkRemoveEntityPre.Size = new System.Drawing.Size(150, 16);
            this.chkRemoveEntityPre.TabIndex = 48;
            this.chkRemoveEntityPre.Text = "去掉EntityName前缀-->";
            this.chkRemoveEntityPre.UseVisualStyleBackColor = true;
            // 
            // txRemovePre
            // 
            this.txRemovePre.Location = new System.Drawing.Point(317, 324);
            this.txRemovePre.Name = "txRemovePre";
            this.txRemovePre.Size = new System.Drawing.Size(195, 21);
            this.txRemovePre.TabIndex = 47;
            // 
            // chkRemovePre
            // 
            this.chkRemovePre.AutoSize = true;
            this.chkRemovePre.Location = new System.Drawing.Point(167, 328);
            this.chkRemovePre.Name = "chkRemovePre";
            this.chkRemovePre.Size = new System.Drawing.Size(144, 16);
            this.chkRemovePre.TabIndex = 46;
            this.chkRemovePre.Text = "去掉ClassName前缀-->";
            this.chkRemovePre.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "导入模块:";
            // 
            // cmbImportModule
            // 
            this.cmbImportModule.FormattingEnabled = true;
            this.cmbImportModule.Location = new System.Drawing.Point(317, 351);
            this.cmbImportModule.Name = "cmbImportModule";
            this.cmbImportModule.Size = new System.Drawing.Size(195, 20);
            this.cmbImportModule.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "不包含:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "包含:";
            // 
            // txSearch_un
            // 
            this.txSearch_un.Location = new System.Drawing.Point(258, 59);
            this.txSearch_un.Name = "txSearch_un";
            this.txSearch_un.Size = new System.Drawing.Size(185, 21);
            this.txSearch_un.TabIndex = 41;
            this.txSearch_un.TextChanged += new System.EventHandler(this.txSearch_TextChanged);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(368, 377);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(144, 44);
            this.btnImport.TabIndex = 39;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.ItemHeight = 12;
            this.cmbDatabase.Location = new System.Drawing.Point(6, 41);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(183, 244);
            this.cmbDatabase.TabIndex = 37;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "选择数据库：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(197, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(161, 12);
            this.label17.TabIndex = 36;
            this.label17.Text = "供选择表[这里的表不生效]：";
            // 
            // lsbTmpTables
            // 
            this.lsbTmpTables.Enabled = false;
            this.lsbTmpTables.FormattingEnabled = true;
            this.lsbTmpTables.ItemHeight = 12;
            this.lsbTmpTables.Location = new System.Drawing.Point(198, 102);
            this.lsbTmpTables.Name = "lsbTmpTables";
            this.lsbTmpTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbTmpTables.Size = new System.Drawing.Size(161, 184);
            this.lsbTmpTables.TabIndex = 35;
            this.lsbTmpTables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbTmpTables_MouseDoubleClick);
            // 
            // lsbCheckedTables
            // 
            this.lsbCheckedTables.FormattingEnabled = true;
            this.lsbCheckedTables.ItemHeight = 12;
            this.lsbCheckedTables.Location = new System.Drawing.Point(360, 102);
            this.lsbCheckedTables.Name = "lsbCheckedTables";
            this.lsbCheckedTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbCheckedTables.Size = new System.Drawing.Size(163, 184);
            this.lsbCheckedTables.TabIndex = 32;
            this.lsbCheckedTables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbCheckedTables_MouseDoubleClick);
            // 
            // txSearch
            // 
            this.txSearch.Location = new System.Drawing.Point(258, 34);
            this.txSearch.Name = "txSearch";
            this.txSearch.Size = new System.Drawing.Size(184, 21);
            this.txSearch.TabIndex = 30;
            this.txSearch.TextChanged += new System.EventHandler(this.txSearch_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(199, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "搜索：";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(448, 34);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(74, 46);
            this.btnCheckAll.TabIndex = 33;
            this.btnCheckAll.Text = "全选(&A)";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "已选择数据表：";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(195, 328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(181, 44);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.txMYSQLPORT);
            this.groupBox2.Controls.Add(this.lbMYSQLPORT);
            this.groupBox2.Controls.Add(this.cmbDataType);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txpassword);
            this.groupBox2.Controls.Add(this.txusername);
            this.groupBox2.Controls.Add(this.cmbAuthor);
            this.groupBox2.Controls.Add(this.txserver);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbAuthor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 435);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库连接";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(195, 265);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(181, 44);
            this.btnNext.TabIndex = 40;
            this.btnNext.Text = "加载数据表";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // txMYSQLPORT
            // 
            this.txMYSQLPORT.Location = new System.Drawing.Point(175, 223);
            this.txMYSQLPORT.Name = "txMYSQLPORT";
            this.txMYSQLPORT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txMYSQLPORT.Size = new System.Drawing.Size(201, 21);
            this.txMYSQLPORT.TabIndex = 38;
            this.txMYSQLPORT.Text = "3306";
            this.txMYSQLPORT.Visible = false;
            this.txMYSQLPORT.WordWrap = false;
            // 
            // lbMYSQLPORT
            // 
            this.lbMYSQLPORT.AutoSize = true;
            this.lbMYSQLPORT.Location = new System.Drawing.Point(32, 226);
            this.lbMYSQLPORT.Name = "lbMYSQLPORT";
            this.lbMYSQLPORT.Size = new System.Drawing.Size(71, 12);
            this.lbMYSQLPORT.TabIndex = 39;
            this.lbMYSQLPORT.Text = "MYSQL PORT:";
            this.lbMYSQLPORT.Visible = false;
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Items.AddRange(new object[] {
            "SQL Server",
            "MySql/MariaDB",
            "ORACLE"});
            this.cmbDataType.Location = new System.Drawing.Point(126, 59);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(250, 20);
            this.cmbDataType.TabIndex = 29;
            this.cmbDataType.SelectedIndexChanged += new System.EventHandler(this.cmbDataType_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 12);
            this.label18.TabIndex = 36;
            this.label18.Text = "数据库类型:";
            // 
            // txpassword
            // 
            this.txpassword.Enabled = false;
            this.txpassword.Location = new System.Drawing.Point(175, 191);
            this.txpassword.Name = "txpassword";
            this.txpassword.PasswordChar = '*';
            this.txpassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txpassword.Size = new System.Drawing.Size(201, 21);
            this.txpassword.TabIndex = 37;
            this.txpassword.Text = "root";
            // 
            // txusername
            // 
            this.txusername.Enabled = false;
            this.txusername.Location = new System.Drawing.Point(175, 160);
            this.txusername.Name = "txusername";
            this.txusername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txusername.Size = new System.Drawing.Size(201, 21);
            this.txusername.TabIndex = 35;
            this.txusername.Text = "root";
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.FormattingEnabled = true;
            this.cmbAuthor.Items.AddRange(new object[] {
            "Windows身份验证",
            "SQL身份验证"});
            this.cmbAuthor.Location = new System.Drawing.Point(126, 127);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(250, 20);
            this.cmbAuthor.TabIndex = 33;
            this.cmbAuthor.Text = "Windows身份验证";
            this.cmbAuthor.SelectedIndexChanged += new System.EventHandler(this.cmbAuthor_SelectedIndexChanged);
            // 
            // txserver
            // 
            this.txserver.Location = new System.Drawing.Point(126, 92);
            this.txserver.Name = "txserver";
            this.txserver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txserver.Size = new System.Drawing.Size(250, 21);
            this.txserver.TabIndex = 31;
            this.txserver.Text = "localhost";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(32, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "密  码：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(32, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "用户名：";
            // 
            // lbAuthor
            // 
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Location = new System.Drawing.Point(32, 127);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(65, 12);
            this.lbAuthor.TabIndex = 30;
            this.lbAuthor.Text = "身份验证：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "服务器名称：";
            // 
            // FMImportFDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(965, 460);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMImportFDB";
            this.Text = "从数据库内导入";
            this.Load += new System.EventHandler(this.FMImportFDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ListBox cmbDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListBox lsbTmpTables;
        private System.Windows.Forms.ListBox lsbCheckedTables;
        private System.Windows.Forms.TextBox txSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txMYSQLPORT;
        private System.Windows.Forms.Label lbMYSQLPORT;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txpassword;
        private System.Windows.Forms.TextBox txusername;
        private System.Windows.Forms.ComboBox cmbAuthor;
        private System.Windows.Forms.TextBox txserver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txSearch_un;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbImportModule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkRemovePre;
        private System.Windows.Forms.TextBox txRemovePre;
        private System.Windows.Forms.TextBox txRemoveEntityPre;
        private System.Windows.Forms.CheckBox chkRemoveEntityPre;
    }
}