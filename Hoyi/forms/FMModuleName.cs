/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.conf;
using Hoyi.ctrl;
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
    public partial class FMModuleName : Form
    {
        public FMModuleName()
        {
            InitializeComponent();
        }

        public ModuleInfo mods;

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            if (mods == null)
            {
                ModuleInfo module = new ModuleInfo();
                module.ModuleName = txModuleName.Text;
                module.Prefix = txPrefix.Text;
                module.Suffix = txSuffix.Text;
                module.Caption = txCaption.Text;
                module.ModuleType = txType.Text;
                AppConf.Ins.Application.Modules.Add(module);
            }
            else
            {
                mods.ModuleName = txModuleName.Text;
                mods.Prefix = txPrefix.Text;
                mods.Suffix = txSuffix.Text;
                mods.Caption = txCaption.Text;
                mods.ModuleType = txType.Text;
            }
            ProTreeCtrl.Ins.ReLoadTree();

            this.Close();
        }

        private void FMModuleName_Load(object sender, EventArgs e)
        {
            if (mods != null)
            {
                txModuleName.Text = mods.ModuleName;
                txPrefix.Text = mods.Prefix;
                txSuffix.Text = mods.Suffix;
                txCaption.Text = mods.Caption;
                txType.Text = mods.ModuleType;

                txModuleName.SelectAll();
            }
            txModuleName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
