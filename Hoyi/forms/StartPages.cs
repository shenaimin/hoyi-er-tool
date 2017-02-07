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
    public partial class StartPages : Form
    {
        private static StartPages _instance;

        public static StartPages Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StartPages();
                }
                return _instance;
            }
        }

        public StartPages()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text + ".";
            if (label3.Text.Length > 30) {
                label3.Text = "启动中 ";
            }
        }

        private void StartPages_Load(object sender, EventArgs e)
        {
            lbversion.Text = "-Version：" + AppConf.Ins.Version;
            timer1.Interval = 300;
            timer1.Start();
        }
    }
}
