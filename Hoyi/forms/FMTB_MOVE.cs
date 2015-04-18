/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.appConf;
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
    public partial class FMTB_MOVE : Form
    {
        public FMTB_MOVE()
        {
            InitializeComponent();
        }

        private void FMTB_MOVE_Load(object sender, EventArgs e)
        {
            bindDataCurrent();
        }

        public void bindDataCurrent()
        {
            lsCurrentModule.Items.Clear();
            lsTargetModule.Items.Clear();
            foreach (ModuleInfo mod in AppConf.Ins.Application.Modules)
            {
                lsCurrentModule.Items.Add(mod);
                lsTargetModule.Items.Add(mod);
            }
            if (AppConf.Ins.Application.Modules.Count > 0)
            {
                lsCurrentModule.SelectedIndex = 0;
            }
            //lsCurrentModule.DataSource = AppConf.Ins.Application.Modules;
            //lsTargetModule.DataSource = AppConf.Ins.Application.Modules;
            //lsCurrentModule.datasource
        }

        private void lsCurrentModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsCurrentEntity.DataSource = (lsCurrentModule.SelectedItem as ModuleInfo).Entitys;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lsCurrentEntity.SelectedItem != null && lsTargetModule.SelectedItem != null)
            {
                foreach (var item in lsCurrentEntity.SelectedItems)
                {
                    (lsTargetModule.SelectedItem as ModuleInfo).Entitys.Add(item as EntityInfo);
                    (lsCurrentModule.SelectedItem as ModuleInfo).Entitys.Remove(item as EntityInfo);
                }
                bindDataCurrent();

                lsCurrentEntity.DataSource = null;
                lsCurrentEntity.DataSource = (lsCurrentModule.SelectedItem as ModuleInfo).Entitys;
                ProTreeCtrl.Ins.ReLoadTree();
                ProTreeCtrl.Ins.ReloadModule();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
