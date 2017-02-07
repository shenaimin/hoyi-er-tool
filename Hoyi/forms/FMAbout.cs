/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */

using Hoyi.conf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hoyi.forms
{
    public partial class FMAbout : Form
    {
        public FMAbout()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FMAbout_Load(object sender, EventArgs e)
        {
            lbversion.Text = "-Version：" + AppConf.Ins.Version;
            rtxversion.Text = Version.GetVersion();
        }

        private void FMAbout_MouseUp(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FMAbout_MouseDown(object sender, MouseEventArgs e)
        {
            //this.Close();
        }
    }
}
