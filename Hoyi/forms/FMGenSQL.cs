/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.ctrl;
using ModelCode.ModelInfo;
using ModelCode.Util;
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
    public partial class FMGenSQL : Form
    {
        public FMGenSQL()
        {
            InitializeComponent();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            List<ModuleInfo> modules = CheckTreeCTRL.Ins.getCheckedEntities();

            this.rtxSQL.Text = GeneralSQL.Ins.GenerSQL(
                chkQiangFPY.Checked, chkQiangDeleteFPY.Checked,
              chkFPY.Checked, chkDeleteFPY.Checked,  chkCreateTable.Checked, chkRemoveFor.Checked, chkFornAddPre.Checked,
            chkDelete.Checked, true, chkEncode.Checked, txEncode.Text, chkComment.Checked, chkEngine.Checked, txEngine.Text,
            chkPre.Checked, chkSuffix.Checked, chkForn.Checked, modules
                );
        }

        private void FMGenSQL_Load(object sender, EventArgs e)
        {
            CheckTreeCTRL.Ins.CHECKTree = this.treeView1;
            CheckTreeCTRL.Ins.ReLoadTree();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Text = "正在导出...";
            btnExport.Enabled = false;
            List<ModuleInfo> modules = CheckTreeCTRL.Ins.getCheckedEntities();

            string exSQL = GeneralSQL.Ins.GenerSQL(
                chkQiangFPY.Checked, chkQiangDeleteFPY.Checked,
            chkFPY.Checked, chkDeleteFPY.Checked, chkCreateTable.Checked, chkRemoveFor.Checked, chkFornAddPre.Checked,
            chkDelete.Checked, true, chkEncode.Checked, txEncode.Text, chkComment.Checked, chkEngine.Checked, txEngine.Text,
            chkPre.Checked, chkSuffix.Checked, chkForn.Checked, modules
                );


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SQL Document(*.sql)|*.sql|All Files|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                StreamWriter sw = new StreamWriter(path, false);
                sw.Write(exSQL);
                sw.Close();
                //XmlSerializer.SaveToXml(path, modules, modules.GetType(), null);
                MessageBox.Show("保存完成！路径:" + path);
            }
            btnExport.Text = "导出";
            btnExport.Enabled = true;
        }
    }
}
