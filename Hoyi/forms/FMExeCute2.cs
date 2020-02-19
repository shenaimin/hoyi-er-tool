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
    public partial class FMExeCute2 : Form
    {
        public FMExeCute2()
        {
            InitializeComponent();
        }

        private void FMExeCute2_Load(object sender, EventArgs e)
        {
            txModuleNameSpace.Text = AppConf.Ins.Application.NameSpace;

            DirectoryInfo direct = new DirectoryInfo(Application.StartupPath + "\\Template");
            foreach (FileInfo fl in direct.GetFiles())
            {
                chkTemplate.Items.Add(fl.Name);
            }

            txSaveFolder.Text = AppConf.Ins.Application.SavedPath;

            ExCodeTreeCtrl.Ins.CHECKTree = this.treeEnts;
            ExCodeTreeCtrl.Ins.ReLoadTree();

            txModuleNameSpace.Focus();
        }

        public void InitSavedPath()
        {
            AppConf.Ins.Application.SavedPath = txSaveFolder.Text;
            AppConf.Ins.Application.NameSpace = txModuleNameSpace.Text;
        }

        List<string> checkedTemplate;
        private void btnExec_Click(object sender, EventArgs e)
        {
            btnExec.Text = "正在生成....";
            btnExec.Enabled = false;
            btnFolderChecker.Enabled = false;
            InitSavedPath();

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
                MessageBox.Show("请至少并且只选择一个模板进行生成.");
            }
            else
            {
                this.CreateByTemplate();
            }
            btnExec.Text = "生成";
            btnExec.Enabled = true;
            btnFolderChecker.Enabled = true;
        }

        /// <summary>
        /// 根据模板创建文件.
        /// </summary>
        public void CreateByTemplate()
        {
            List<ModuleInfo> mods = ExCodeTreeCtrl.Ins.getCheckedEntities();
            AppConf.Ins.CurrentExeModules = mods;
            TemplateURLControl control = new TemplateURLControl();
            // 否则就不取值.

            // 设置全局模板名称.
            AppConf.ExeTemplatename = checkedTemplate[0];
            foreach (ModuleInfo mo in mods)
            {
                foreach (EntityInfo entity in mo.Entitys)
                {
                    if (entity.operaters == null || entity.operaters.Count <= 0)
                    {
                        DEFAULT_OPERATE_READER.Instance.INIT_DEFAULT_OPERA();
                        entity.operaters = DEFAULT_OPERATE_READER.Instance.DEFAULT_OPERATE;
                    }
                    AppConf.Ins.CurrentExeEntity = entity;
                    control.LoadTemplateURL("Template/" + checkedTemplate[0]);
                    control.Execute(entity, this.txSaveFolder.Text);
                }
            }
            MessageBox.Show("文档生成成功! CheckedEntity.ModulesCount:" + mods.Count);
        }

        private void btnFolderChecker_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbp = new FolderBrowserDialog();
            if (fbp.ShowDialog() == DialogResult.OK)
            {
                this.txSaveFolder.Text = fbp.SelectedPath;
                InitSavedPath();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
