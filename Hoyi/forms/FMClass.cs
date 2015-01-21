/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Crainiate.ERM4;
using Hoyi.appConf;
using Hoyi.conf;
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
    public partial class FMClass : Form
    {
        public string[] loadargs;
        public FMClass(string[] args)
        {
            InitializeComponent();
            loadargs = args;
        }
        public FMClass()
        {
            InitializeComponent();
        }


        private void FMClass_Load(object sender, EventArgs e)
        {
            ProTreeCtrl.Ins.ProTree = this.treeProject;
            formConf.CurrentModel = this.model1;

            treeProject.NodeMouseDoubleClick += ProTreeCtrl.Ins.ProTree_NodeMouseDoubleClick;

            formConf.StartTime = DateTime.Now;
            if (EXPCTRL.Ins.AreExClosed())
            {
                异常关闭选择ToolStripMenuItem_Click(null, null);
            }
            属性视图AToolStripMenuItem_Click(null, null);

            ClassDiagCtrl.Ins.currentModel = this.model1;

            ProTreeCtrl.Ins.ReLoadTree();

            LoadModel();

            properGridCtrl.propertyGrid1 = this.propertyGrid1;

            this.propertyGrid1.SelectedObject = model1;
            this.model1.MouseWheel += model1_MouseWheel;
            if (loadargs.Count() > 0)
            {
                string path = loadargs[0];
                LoadFromPath(path);
                AppConf.LoadAndSavedPath = path;
                this.Text = "HOYI ER、类图设计 " + AppConf.LoadAndSavedPath + "";
                MessageBox.Show("加载完成.");
            }
        }

        void model1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                toolStripButton3_Click(sender, null);
            }
            else
            {
                toolStripButton6_Click(sender, null);
            }
        }

        private void LoadModel()
        {
            ClassDiagCtrl.Ins.InitModelEvent(this.model1, this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            model1.Zoom = model1.Zoom + 10f;
            model1.Refresh();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            model1.Zoom = model1.Zoom - 10f;
            model1.Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            model1.Zoom = 100f;
            model1.Refresh();
        }

        private void 项目结构图PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void 关于HOYI设计HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("shenaimin [Ellen@hoyi.org] [www.hoyi.org] @2015 All rights reserved.");
        }

        private void 属性视图AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           ClassDiagCtrl.Ins.NewEntity(this.model1);
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AppConf.LoadAndSavedPath) || AppConf.LoadAndSavedPath.Length <= 0)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                string saveName = AppConf.Ins.Application.AppName + "[MO" + AppConf.Ins.Application.Modules.Count.ToString() + ".Entity]" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".hoyi";
                dialog.FileName = saveName;
                dialog.Title = "请保存.";
                dialog.Filter = "HOYI Document(*.hoyi)|*.hoyi|XML Document(*.xml)|*.xml|All Files|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = dialog.FileName;
                    XmlSerializer.SaveToXml(path, AppConf.Ins.Application, AppConf.Ins.Application.GetType(), null);
                    AppConf.LoadAndSavedPath = path;
                    MessageBox.Show("保存完成！路径:" + path);
                }
            }
            else
            {
                string path = AppConf.LoadAndSavedPath;
                XmlSerializer.SaveToXml(path, AppConf.Ins.Application, AppConf.Ins.Application.GetType(), null);

                this.Text = "HOYI ER、类图设计 " + path + "      已保存.";
            }
        }

        public void LoadFromPath(string path)
        {
            model1.Clear();
            AppConf.Ins.Application = XmlSerializer.LoadFromXml(path, typeof(ApplicationInfo)) as ApplicationInfo;
            ClassDiagCtrl.Ins.LoadAndRefreshModel(model1);
            ConnCtrl.Ins.LoadConnects(model1, AppConf.Ins.Application.Conns);
            ProTreeCtrl.Ins.ReLoadTree();
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "HOYI Document(*.hoyi)|*.hoyi|XML Document(*.xml)|*.xml|All Files|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                LoadFromPath(path);
                AppConf.LoadAndSavedPath = path;
                this.Text = "HOYI ER、类图设计 " + AppConf.LoadAndSavedPath + "";
                MessageBox.Show("加载完成.");
            }
            ProTreeCtrl.Ins.ReLoadTree();
        }

        private void 添加模块ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMModuleName fms = new FMModuleName();
            fms.ShowDialog();
        }

        private void 修改模块名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeProject.SelectedNode != null)
            {
                if (treeProject.SelectedNode.Tag is ModuleInfo)
                {
                    FMModuleName fs = new FMModuleName();
                    fs.mods = treeProject.SelectedNode.Tag as ModuleInfo;
                    fs.ShowDialog();
                }
                else if (treeProject.SelectedNode.Tag is ApplicationInfo)
                {
                    FMApp ap = new FMApp();
                    ap.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Checked is Not A ModuleInfo.");
                }
            }
            else
            {
                MessageBox.Show("Please check a node.");
            }
        }

        private void FMClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.S)
                {
                    保存SToolStripMenuItem_Click(null, null);
                }
                else if (e.KeyCode == Keys.O)
                {
                    打开OToolStripMenuItem_Click(null, null);
                }
                else if (e.KeyCode == Keys.I)
                {
                    导入IToolStripMenuItem_Click(null, null);
                }
            }
            if (e.KeyCode == Keys.V)
            {
                toolStripButton7_Click(tsb_select, null);
            }
            else if (e.KeyCode == Keys.L)
            {
                toolStripButton2_Click(tsb_line, null);
            }
            else if (e.KeyCode == Keys.C)
            {
                tsbConnector_Click(tsbConnector, null);
            }
            else if (e.KeyCode == Keys.U)
            {
                tsb_cir_Click(tsb_cir, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                生成EToolStripMenuItem1_Click(null, null);
            }
            else if (e.KeyCode == Keys.F9)
            {
                导出SQL语句ToolStripMenuItem_Click(null, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                打开OToolStripMenuItem_Click(null, null);
            }
        }

        private void 生成EToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FMExecute ex = new FMExecute();
            //ex.ShowDialog();
            FMExeCute2 fm = new FMExeCute2();
            fm.WindowState = FormWindowState.Maximized;
            fm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (ModuleInfo mods  in AppConf.Ins.Application.Modules)
            {
                i += mods.Entitys.Count;
            }
            string path = Application.StartupPath + "/autosave/" + AppConf.Ins.Application.AppName + "[" + i.ToString() + ".Entity]" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".hoyi";
            FileStream fs1 = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine("");//开始写入值
            sw.Close();
            fs1.Close();
            XmlSerializer.SaveToXml(path, AppConf.Ins.Application, AppConf.Ins.Application.GetType(), null);
        }

        private void 导出SQL语句ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMGenSQL gsql = new FMGenSQL();
            gsql.WindowState = FormWindowState.Maximized;
            gsql.Show();
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmSet st = new FmSet();
            st.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            TipSave();
            if (formConf.AreExitRemoveAutoSave) // 如果退出前删除.
            {
                directCtrl dir = new directCtrl();
                dir.DeleteDir(Application.StartupPath + "/autosave/");
            }
            base.OnClosed(e);
        }

        public void TipSave()
        {
            if (formConf.getConfEntity().Count > 0)
            {
                DialogResult result = MessageBox.Show("当前有操作项目未保存,是否保存！", "确认保存", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    保存SToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void 导入IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportCTRL.Ins.mainclassform = this;
            FMImportFDB imdb = new FMImportFDB();
            imdb.ShowDialog();
        }

        private void 异常关闭选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMEXPS exps = new FMEXPS();
            exps.parent = this;
            exps.ShowDialog();
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            string saveName = AppConf.Ins.Application.AppName + "[MO" + AppConf.Ins.Application.Modules.Count.ToString() + ".Entity]" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".hoyi";
            dialog.FileName = saveName;
            dialog.Title = "请保存.";
            dialog.Filter = "HOYI Document(*.hoyi)|*.hoyi|XML Document(*.xml)|*.xml|All Files|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                XmlSerializer.SaveToXml(path, AppConf.Ins.Application, AppConf.Ins.Application.GetType(), null);
                MessageBox.Show("保存完成！路径:" + path);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = "HOYI ER、类图设计 " + AppConf.LoadAndSavedPath + "";
        }

        public void UnCheckExT(ToolStripButton tsb)
        {
            tsb_select.Checked = tsb_line.Checked = tsbConnector.Checked = tsb_ComplexLine.Checked = tsb_cir.Checked = false;
            tsb.Checked = true;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            model1.Runtime.InteractiveMode = InteractiveMode.Normal;
            UnCheckExT(sender as ToolStripButton);
        }

        private void toolStripButton2_Click(object sender, EventArgs e){
            model1.Runtime.InteractiveMode = InteractiveMode.AddLine;
            UnCheckExT(sender as ToolStripButton);
            formConf.linetype = ModelCode.ModelInfo.ENTITYS.LineType.Line;
        }

        private void tsbConnector_Click(object sender, EventArgs e)
        {
            model1.Runtime.InteractiveMode = InteractiveMode.AddConnector;
            UnCheckExT(sender as ToolStripButton);
            formConf.linetype = ModelCode.ModelInfo.ENTITYS.LineType.Connector;
        }

        private void tsb_ComplexLine_Click(object sender, EventArgs e)
        {
            model1.Runtime.InteractiveMode = InteractiveMode.AddComplexLine;
            UnCheckExT(sender as ToolStripButton);
            formConf.linetype = ModelCode.ModelInfo.ENTITYS.LineType.ComplexLine;
        }

        private void tsb_cir_Click(object sender, EventArgs e)
        {
            model1.Runtime.InteractiveMode = InteractiveMode.AddCurve;
            UnCheckExT(sender as ToolStripButton);
            formConf.linetype = ModelCode.ModelInfo.ENTITYS.LineType.Circle;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            ClassDiagCtrl.Ins.NewEntity(this.model1);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            model1.DragScroll = true;
        }

        private void 实体迁移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMTB_MOVE move = new FMTB_MOVE();
            move.Show();
        }

        private void 从外部HOYI文件迁移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMTB_OUT_MOVE move = new FMTB_OUT_MOVE();
            move.Show();
        }
    }
}
