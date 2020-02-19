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
    public partial class LoadingPage : Form
    {
        private static LoadingPage _instance;

        public static LoadingPage Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoadingPage();
                }
                return _instance;
            }
        }
        public LoadingPage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text + ".";
            if (label3.Text.Length > 35)
            {
                label3.Text = "内容加载中，请稍候 ";
            }
        }

        private void LoadingPage_Load(object sender, EventArgs e)
        {
            //timer1.Interval = 300;
            //timer1.Start();
        }
    }
}
