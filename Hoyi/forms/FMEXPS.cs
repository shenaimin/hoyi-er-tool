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
    public partial class FMEXPS : Form
    {
        public FMEXPS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FMClass parent;


        private void FMEXPS_Load(object sender, EventArgs e)
        {
            EXPCTRL.Ins.GetAutoSaveFilesInfo();

            lsPre.DataSource = EXPCTRL.Ins.prestart;
            lsPre.DisplayMember = "Name";

            lsStarted.DataSource = EXPCTRL.Ins.started;
            lsStarted.DisplayMember = "Name";
        }

        private void lsPre_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox ls = sender as ListBox;
            FileInfo fl = ls.SelectedItem as FileInfo;
            string filePath = fl.Directory + "\\" + fl.Name;


            if (AppConf.Ins.Application.Modules.Count <= 1 && formConf.getConfEntity().Count == 0)
            {
                AppConf.Ins.DocSaved = true;
            }

            if (AppConf.Ins.DocSaved)
            {
                DialogResult result = MessageBox.Show("是否要打开上次异常关闭的文档.", "加载异常关闭信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //确定按钮的方法
                    parent.LoadFromPath(filePath);
                }
                else
                {
                    //取消按钮的方法
                }
            }else {
                MessageBox.Show("当前文档未保存，请按 CTRL+S 保存后再打开新的文档。");
            }
        }
    }
}
