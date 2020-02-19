/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.conf;
using Hoyi.ctrl;
using ModelCode;
using ModelCode.Builder.Templates.Analysis;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.forms
{
    public partial class FMExecute : Form
    {
        public FMExecute()
        {
            InitializeComponent();
        }
        private void FMExecute_Load(object sender, EventArgs e)
        {
            txModuleNameSpace.Text = AppConf.Ins.Application.NameSpace;

            DirectoryInfo direct = new DirectoryInfo("Template");
            foreach (FileInfo fl in direct.GetFiles())
            {
                chkTemplate.Items.Add(fl.Name);
            }

            OperatorCtrl.Ins.lsOperate = this.lsOperate;
            OperatorCtrl.Ins.lsEntity = this.lsEntity;

            lsModules.DataSource = AppConf.Ins.Application.Modules;
            lsModules.DisplayMember = "ModuleName";

            foreach (ModuleInfo mo in AppConf.Ins.Application.Modules)
            {
                chkModules.Items.Add(mo.ModuleName);
            }
            if (AppConf.Ins.Application.Modules.Count > 0)
            {
                chkModules.SelectedIndex = 0;
            }
            txSaveFolder.Text = AppConf.Ins.Application.SavedPath;
        }
        private void txEntity_Filter_TextChanged(object sender, EventArgs e)
        {
            this.lsEntity.DataSource = null;

            List<EntityInfo> tbs = new List<EntityInfo>();
            ModuleInfo mods = lsModules.SelectedItem as ModuleInfo;
            foreach (EntityInfo tb in mods.Entitys)
            {
                if (tb.ClassName.Contains(txEntity_Filter.Text))
                {
                    tbs.Add(tb);
                }
            }
            this.lsClass.DataSource = this.lsEntity.DataSource = tbs;
            this.lsEntity.DisplayMember = "EntityName";
            this.lsClass.DisplayMember = "ClassName";

            OperatorCtrl.Ins.InitOpers();
        }
        private void lsModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModuleInfo mods = lsModules.SelectedItem as ModuleInfo;
            this.lsClass.DataSource = this.lsEntity.DataSource = mods.Entitys;
            this.lsEntity.DisplayMember = "EntityName";
            this.lsClass.DisplayMember = "ClassName";

            OperatorCtrl.Ins.InitOpers();
        }
        private void lsClass_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ConfigForm cf = new ConfigForm();
            cf.Table = lsClass.SelectedItem as EntityInfo;
            cf.ShowDialog();
            lsModules.DataSource = AppConf.Ins.Application.Modules;
            lsModules_SelectedIndexChanged(null, null);
            //MessageBox.Show((lsClass.SelectedItem as EntityInfo).EntityName);
        }
        private void lsClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsClass.SelectedIndex > 0 && lsOperate.Items.Count > lsClass.SelectedIndex)
            {
                lsOperate.SelectedIndex = lsClass.SelectedIndex;
            }
        }
        private void chkModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(chkModules.SelectedIndex.ToString());
            chkEntity.Items.Clear();
            ModuleInfo mod = AppConf.Ins.Application.Modules[chkModules.SelectedIndex];
            chkEntity.Items.Clear();
            foreach (EntityInfo ent in mod.Entitys)
            {
                chkEntity.Items.Add(ent.ClassName);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            int checkedModuels = chkModules.CheckedItems.Count;

            List<EntityInfo> entities = new List<EntityInfo>();
            if (checkedModuels == 1) // 等于1的时候才会考虑选中的实体,否则，全部取所有的实体生成.
            {
                ModuleInfo mod= AppConf.Ins.Application.Modules[chkModules.CheckedIndices[0]];
                foreach (int i in chkEntity.CheckedIndices)
                {
                    entities.Add(mod.Entitys[i]);
                    MessageBox.Show(mod.Entitys[i].ToString());
                }
            }
            //MessageBox.Show(checkedModuels.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void btnFolderChecker_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbp = new FolderBrowserDialog();
            if (fbp.ShowDialog() == DialogResult.OK)
            {
                this.txSaveFolder.Text = fbp.SelectedPath;
            }
        }

        List<string> checkedTemplate;
        private void btnExecute_Click_1(object sender, EventArgs e)
        {
            btnExecute.Enabled = false;
            checkedTemplate = new List<string>();
            checkedTemplate.Clear();
            for (int j = 0; j < this.chkTemplate.Items.Count; j++)
            {
                if (this.chkTemplate.GetItemChecked(j))
                {
                    checkedTemplate.Add(this.chkTemplate.Items[j].ToString());
                }
            }
            if (checkedTemplate.Count != 1)
            {
                this.tabControl1.SelectedIndex = 4;
                MessageBox.Show("请至少并且只选择一个模板进行生成.");
                this.tabControl1.SelectedIndex -= 1;
            }
            else
            {
                this.CreateByTemplate();
            }
            AppConf.Ins.Application.SavedPath = txSaveFolder.Text;
            AppConf.Ins.Application.NameSpace = txModuleNameSpace.Text;

            btnExecute.Enabled = true;
        }

        /// <summary>
        /// 根据模板创建文件.
        /// </summary>
        public void CreateByTemplate()
        {
            List<EntityInfo> modulestable = new List<EntityInfo>();
            ModuleInfo checkedModule;
            if (chkModules.CheckedItems.Count == 1) // 如果是1，则取当前一个，
            {
                checkedModule = AppConf.Ins.Application.Modules[chkModules.CheckedIndices[0]];

                foreach (int ind in chkEntity.CheckedIndices)
                {
                    modulestable.Add(checkedModule.Entitys[ind]);
                }
            }
            else if (chkModules.CheckedItems.Count > 1) //取全部的.
            {
                foreach (int mind in chkModules.CheckedIndices)
                {
                    checkedModule = AppConf.Ins.Application.Modules[mind] as ModuleInfo;

                    modulestable.AddRange(checkedModule.Entitys);
                }
            }
            TemplateURLControl control = new TemplateURLControl();
            // 否则就不取值.

            foreach (EntityInfo entity in modulestable)
            {
                AppConf.Ins.CurrentExeEntity = entity;
                control.LoadTemplateURL("Template/" + checkedTemplate[0]);
                control.Execute(entity, this.txSaveFolder.Text);
            }
            MessageBox.Show("文档生成成功! CheckedEntity:" + modulestable.Count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void txSaveFolder_TextChanged(object sender, EventArgs e)
        {
            AppConf.Ins.Application.SavedPath = txSaveFolder.Text;
        }

        private void txModuleNameSpace_TextChanged(object sender, EventArgs e)
        {
            AppConf.Ins.Application.NameSpace = txModuleNameSpace.Text;
        }
    }
}
