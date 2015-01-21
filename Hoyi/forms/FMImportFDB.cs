/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.appConf;
using Hoyi.conf;
using Hoyi.ctrl;
using ModelCode.Controll;
using ModelCode.Model;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.forms
{
    public partial class FMImportFDB : Form
    {
        public FMImportFDB()
        {
            InitializeComponent();
        }

        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMYSQLPORT.Visible = txMYSQLPORT.Visible = (cmbDataType.SelectedIndex == 1);
            lbAuthor.Visible = cmbAuthor.Visible = (cmbDataType.SelectedIndex == 0);
            cmbAuthor.SelectedIndex = (cmbDataType.SelectedIndex == 1) ? 1 : 0;
        }

        private void cmbAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txusername.Enabled = cmbAuthor.SelectedIndex == 1;
            txpassword.Enabled = cmbAuthor.SelectedIndex == 1;
            label7.Enabled = cmbAuthor.SelectedIndex == 1;
            label8.Enabled = cmbAuthor.SelectedIndex == 1;
        }

        public DBTYPE currentType = DBTYPE.UNKNOW;
        private void ConfigDataBase()
        {
            string server, intergrated, uid, connectstring;
            //AddLog("数据库连接中....");
            switch (cmbDataType.SelectedIndex)
            {
                case 0:

                    this.currentType = DBTYPE.SQLSERVER;

                    server = "Server=" + txserver.Text.Trim() + ";";
                    intergrated = "Integrated Security=" + (cmbAuthor.SelectedIndex == 0 ? "True" : "False") + ";";
                    uid = "";
                    if (!(cmbAuthor.SelectedIndex == 0))
                    {
                        uid = "uid=" + this.txusername.Text + ";pwd=" + this.txpassword.Text + ";";
                    }

                    connectstring = server + intergrated + uid;
                    formConf.connectionString = formConf.DefaultConnectionString = connectstring;

                    break;
                case 1:

                    this.currentType = DBTYPE.MYSQL_MARIADB;

                    server = "Host=" + txserver.Text.Trim() + ";";

                    uid = "UserName=" + this.txusername.Text + ";Password=" + this.txpassword.Text + ";Port=" + txMYSQLPORT.Text + ";";


                    connectstring = server + uid;
                    formConf.connectionString = formConf.DefaultConnectionString = connectstring;

                    break;
                case 2:
                    this.currentType = DBTYPE.ORACLE;
                    break;
                default:
                    this.currentType = DBTYPE.UNKNOW;
                    break;
            }

            this.ConfigDataTable();
        }

        private void ConfigDataTable()
        {
            List<string> Databases = ObjectFactory.Create().GetDataBaseName(this.currentType);
            cmbDatabase.DataSource = Databases;
            //AddLog("数据库连接成功，....");
            if (cmbDatabase.Items.Count > 2)
            {
                cmbDatabase.SelectedIndex = 2;
                formConf.connectionString = formConf.DefaultConnectionString + "Database=" + cmbDatabase.Items[2].ToString();

                //AddLog("选择数据库:" + cmbDatabase.Items[2].ToString());
            }
        }
        /// <summary>
        /// 数据库内表.
        /// </summary>
        private List<EntityInfo> needTable = new List<EntityInfo>();

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            this.lsbCheckedTables.DataSource = null;

            List<EntityInfo> tbs = new List<EntityInfo>();
            foreach (EntityInfo tb in this.needTable)
            {
                if (txSearch_un.Text.Trim().Length > 0)
                {
                    if (tb.ClassName.Contains(txSearch.Text) && !tb.ClassName.Contains(txSearch_un.Text))
                    {
                        tbs.Add(tb);
                    }
                }
                else
                {
                    if (tb.ClassName.Contains(txSearch.Text))
                    {
                        tbs.Add(tb);
                    }  
                }
            }
            this.lsbTmpTables.DataSource = tbs;
            this.lsbTmpTables.DisplayMember = "ClassName";

            //AddLog("表名搜索：" + txSearch.Text + ", 选中表为0");
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            ConfigDataBase();
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbCheckedTables.Enabled = lsbTmpTables.Enabled = false;

            formConf.CheckedDatabase = cmbDatabase.SelectedValue.ToString();
            //ConfigModel.connectionString = ConfigModel.getDefaultString() + "Database=" + cmbDatabase.SelectedValue;

            switch (currentType)
            {
                case DBTYPE.UNKNOW:
                    break;
                case DBTYPE.SQLSERVER:

                    if (cmbAuthor.SelectedIndex == 0)
                    {
                        formConf.connectionString = "Server=" + txserver.Text + ";Integrated Security=True;Database=" + cmbDatabase.SelectedValue;
                    }
                    else
                    {
                        formConf.connectionString = "Server=" + txserver.Text + ";uid=" + txusername.Text + ";pwd=" + txpassword.Text + ";Database=" + cmbDatabase.SelectedValue;
                    }

                    needTable = ObjectFactory.Create().GetTables(this.currentType, cmbDatabase.SelectedValue.ToString());

                    this.lsbTmpTables.DataSource = needTable;
                    this.lsbTmpTables.DisplayMember = "ClassName";

                    break;
                case DBTYPE.MYSQL_MARIADB:

                    formConf.connectionString = "Host=" + txserver.Text + ";UserName=" + txusername.Text + ";Password=" + txpassword.Text + ";Database=" + cmbDatabase.SelectedValue + ";Port=" + txMYSQLPORT.Text;


                    needTable = ObjectFactory.Create().GetTables(this.currentType, cmbDatabase.SelectedValue.ToString());

                    this.lsbTmpTables.DataSource = needTable;
                    this.lsbTmpTables.DisplayMember = "TABLE_NAME";

                    break;
                case DBTYPE.ORACLE:
                    break;
                default:
                    break;
            }
            txSearch_TextChanged(null, null);

            lsbCheckedTables.Items.Clear();
          
            lsbCheckedTables.Enabled = lsbTmpTables.Enabled = true;
        }

        private void lsbTmpTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            lsbCheckedTables.DisplayMember = "ClassName";
            foreach (object obj in lsbTmpTables.SelectedItems)
            {
                ADDTOCHECKEDTABLE(obj as EntityInfo);
            }
        }
        /// <summary>
        /// 添加到已选择的表内.
        /// </summary>
        /// <param name="tbinfo"></param>
        public void ADDTOCHECKEDTABLE(EntityInfo tbinfo)
        {
            lsbCheckedTables.DisplayMember = "ClassName";
            if (!lsbCheckedTables.Items.Contains(tbinfo))
            {
                lsbCheckedTables.Items.Add(tbinfo);
            }
        }

        private void lsbCheckedTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 双击就会移除已经被选择的表.
            lsbCheckedTables.Select();
            lsbCheckedTables.Focus();
            //AddLog("");
            //AddLog("");
            EntityInfo tbi;
            for (int i = 0; i < lsbCheckedTables.SelectedItems.Count; i++)
            {
                tbi = lsbCheckedTables.SelectedItems[i] as EntityInfo;
                lsbCheckedTables.Items.Remove(tbi);

                //AddLog("移除表: " + tbi.TabName + "        [" + DateTime.Now.ToString() + "]");
            }
        }

        /// <summary>
        /// 选择所有的表.
        /// </summary>
        bool CheckAll = false;

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll = !CheckAll;
            CheckAlls(CheckAll);
        }

        public void CheckAlls(bool checkeds)
        {
            if (checkeds)
            {
                for (int i = 0; i < this.lsbTmpTables.Items.Count; i++)
                {
                    ADDTOCHECKEDTABLE(this.lsbTmpTables.Items[i] as EntityInfo);
                }
            }
            else
            {
                lsbCheckedTables.Items.Clear();
            }
        }

        private void FMImportFDB_Load(object sender, EventArgs e)
        {
            cmbDataType.SelectedIndex = 1;
            cmbDataType.Focus();

            cmbImportModule.DataSource = AppConf.Ins.Application.Modules;
            cmbImportModule.DisplayMember = "ModuleName";

            if (AppConf.Ins.Application.Modules.Count > 0)
            {
                cmbImportModule.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 获取选择的表.
        /// </summary>
        public List<EntityInfo> GetCLBTableSelectedItem()
        {
            return GetCLBTableSelectedItem(false, null, false, null);
        }

        /// <summary>
        /// 获取选择的表.是否去除前缀.
        /// </summary>
        /// <param name="removePre"></param>
        /// <param name="pre"></param>
        /// <returns></returns>
        public List<EntityInfo> GetCLBTableSelectedItem(bool removePre, string pre, bool removeEntityNamePre, string entityPre)
        {
            List<EntityInfo> RETABLE = new List<EntityInfo>();
            EntityInfo tmpEnti;
            for (int i = 0; i < this.lsbCheckedTables.Items.Count; i++)
            {
                tmpEnti = this.lsbCheckedTables.Items[i] as EntityInfo;
                tmpEnti.Attributes = ObjectFactory.Create().GetTableFields(tmpEnti.ClassName, (DBTYPE)cmbDataType.SelectedIndex, cmbDatabase.SelectedValue.ToString());
                tmpEnti.constraints = ObjectFactory.Create().GetConstaint(tmpEnti.ClassName, (DBTYPE)cmbDataType.SelectedIndex, cmbDatabase.SelectedValue.ToString());
                if (removePre)
                {
                    tmpEnti.ClassName = tmpEnti.ClassName.Replace(pre, "");
                }
                if (removeEntityNamePre)
                {
                    tmpEnti.EntityName = tmpEnti.EntityName.Replace(entityPre, "");
                }
                RETABLE.Add(tmpEnti);
            }
            return RETABLE;
        }

        int preWidth, preHeight;
        private void btnImport_Click(object sender, EventArgs e)
        {
            preWidth = this.Width;
            preHeight = this.Height;
            this.ControlBox = false;
            this.Width = 500;
            this.Height = 0;
            this.Text = "正在导入,请不要关闭当前窗口.请稍等.......";
            btnImport.Text = "正在导入.....";
            btnNext.Enabled = btnCheckAll.Enabled = this.btnImport.Enabled = false;

            ImportCTRL.Ins.mainclassform.TipSave();
            List<EntityInfo> entities = GetCLBTableSelectedItem(chkRemovePre.Checked, txRemovePre.Text, chkRemoveEntityPre.Checked, txRemoveEntityPre.Text);
            ModuleInfo importedmodule = cmbImportModule.SelectedItem as ModuleInfo;
            ProTreeCtrl.Ins.CheckedModule = importedmodule;
            ProTreeCtrl.Ins.CheckModule(importedmodule);
            ClassDiagCtrl.Ins.LoadFromDatabase(entities, importedmodule);
            MessageBox.Show("导入完成!");
            btnImport.Text = "导入";
            btnNext.Enabled = btnCheckAll.Enabled = this.btnImport.Enabled = true;
            this.Text = "从数据库内导入";
            this.Width = preWidth;
            this.Height = preHeight;
            this.ControlBox = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
