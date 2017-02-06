/*
 *          Author:Ellen
 *          Email:ellen@kuaifish.com   专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.forms
{
    public partial class FMClass : Form
    {
        public static FMClass Ins;


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

        delegate void CloseStartPagedelegate();

        private void FMClass_Load(object sender, EventArgs e)
        {
            this.Hide();
            AttTempConf.Ins.InitTemps();
            ProTreeCtrl.Ins.ProTree = this.treeProject;
            formConf.CurrentModel = this.model1;

            treeProject.NodeMouseDoubleClick += ProTreeCtrl.Ins.ProTree_NodeMouseDoubleClick;
            treeProject.MouseDown += ProTreeCtrl.Ins.ProTree_MouseDown;

            formConf.StartTime = DateTime.Now;
            if (EXPCTRL.Ins.AreExClosed())
            {
                CloseStartPagedelegate closepg1 = new CloseStartPagedelegate(Program.CloseStartPg);
                this.Invoke(closepg1);
                this.WindowState = FormWindowState.Maximized;
                FMClass.Ins.Activate();
                this.Show();
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
                this.Text = "HOYI ER、类图设计        " + AppConf.LoadAndSavedPath + "   [hoyi.org][kuaifish.com 快鱼技术 快人一步]" ;
                //MessageBox.Show("加载完成.");
            }

            this.WindowState = FormWindowState.Maximized;
            CloseStartPagedelegate closepg = new CloseStartPagedelegate(Program.CloseStartPg);
            this.Invoke(closepg);
            this.Focus();
            FMClass.Ins.Activate();
            this.Show();
        }

        public void ShowHideContextItem(object obj) {
            修改系统信息ToolStripMenuItem.Visible = false;
            //添加模块ToolStripMenuItem.Visible = false;  //添加模块一直都显示.
            修改模块名ToolStripMenuItem.Visible = false;
            删除模块ToolStripMenuItem.Visible = false;
            修改实体ToolStripMenuItem.Visible = false;
            删除实体ToolStripMenuItem.Visible = false;
            if (obj is ModuleInfo)
            {
                //添加模块ToolStripMenuItem.Visible = true;
                修改模块名ToolStripMenuItem.Visible = true;
                删除模块ToolStripMenuItem.Visible = true;
            }
            else if (obj is EntityInfo)
            {
                修改实体ToolStripMenuItem.Visible = true;
                删除实体ToolStripMenuItem.Visible = true;
            }
            else if (obj is ApplicationInfo)
            {

                修改系统信息ToolStripMenuItem.Visible = true;
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
            FMAbout abs = new FMAbout();
            abs.ShowDialog();
            //MessageBox.Show("hoyi.org@2015 All rights reserved.   [专业的App外包提供商，广州快鱼信息技术有限公司   www.kuaifish.com   ellen@kuaifish.com] ");
        }

        private void 属性视图AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            /* 创建表.立即打开编辑表的窗口.  */
           Table tbs = ClassDiagCtrl.Ins.NewEntity(this.model1);
            ClassDiagCtrl.Ins.model1_ElementDoubleClick(tbs, e);
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

                this.Text = "HOYI ER、类图设计 " + path + "      已保存.                    [hoyi.org][kuaifish.com 快鱼技术 快人一步]" ;
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

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "HOYI Document(*.hoyi)|*.hoyi|XML Document(*.xml)|*.xml|All Files|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Program.RunLoadingPage();

                string path = dialog.FileName;
                LoadFromPath(path);
                AppConf.LoadAndSavedPath = path;
                this.Text = "HOYI ER、类图设计 " + AppConf.LoadAndSavedPath + "      [hoyi.org][kuaifish.com 快鱼技术 快人一步]";
                //Thread.Sleep(20000);
                //MessageBox.Show("加载完成.");
                ProTreeCtrl.Ins.ReLoadTree();

                CloseStartPagedelegate closepg = new CloseStartPagedelegate(Program.CloseLoadingPage);
                this.Invoke(closepg);
                this.Activate();

                // 模拟鼠标右击一下，有一个打开文档选中几个实体的BUG.
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            }
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
                //else if (treeProject.SelectedNode.Tag is ApplicationInfo)
                //{
                //    FMApp ap = new FMApp();
                //    ap.ShowDialog();
                //}
                else
                {
                    MessageBox.Show("选中对象不是模块.");
                }
            }
            else
            {
                MessageBox.Show("未选中节点.");
            }
        }
        private void 删除模块ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeProject.SelectedNode != null)
            {
                if (treeProject.SelectedNode.Tag is ModuleInfo)
                {
                    DialogResult dr = MessageBox.Show("无法撤销警告!\r\n删除模块会将相关联的实体全部删除,而且无法撤销.\r\n确认删除吗？", "无法撤销警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.OK)
                    {
                        ModuleInfo targetmodlue = (treeProject.SelectedNode.Tag as ModuleInfo);
                        AppConf.Ins.Application.Modules.Remove(targetmodlue);

                        ProTreeCtrl.Ins.ReLoadTree();
                        ProTreeCtrl.Ins.ReloadModule();
                    }
                }
                else
                {
                    MessageBox.Show("选中对象不是模块.");
                }
            }
            else
            {
                MessageBox.Show("未选中节点.");
            }
        }

        private void 删除实体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeProject.SelectedNode != null)
            {
                if (treeProject.SelectedNode.Tag is EntityInfo)
                {
                    DialogResult dr = MessageBox.Show("无法撤销警告!\r\n删除实体会将相关联的实体全部删除,而且无法撤销.\r\n确认删除吗？", "无法撤销警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.OK)
                    {
                        ModuleInfo targetmodlue = (treeProject.SelectedNode.Parent.Tag as ModuleInfo);
                        EntityInfo entityinfo = (treeProject.SelectedNode.Tag as EntityInfo);
                        AppConf.Ins.Application.Modules.Single(s=>s==targetmodlue).Entitys.Remove(entityinfo);

                        ProTreeCtrl.Ins.ReLoadTree();
                        ProTreeCtrl.Ins.ReloadModule();
                    }
                }
                else
                {
                    MessageBox.Show("选中对象不是实体.");
                }
            }
            else
            {
                MessageBox.Show("未选中节点.");
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
            if (e.Alt == true) {
                if (e.KeyCode == Keys.A) {// 新建一个表，
                    toolStripButton1_Click(null, null);
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
            this.Text = "HOYI ER、类图设计 " + AppConf.LoadAndSavedPath + "        [hoyi.org][kuaifish.com 快鱼技术 快人一步]";
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
            toolStripButton1_Click(sender, e);
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


        private Point Position = new Point(0, 0);

        private void treeProject_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // 开始进行拖放操作，并将拖放的效果设置成移动。
            this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeProject_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void treeProject_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode myNode = null;
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            }
            else
            {
                MessageBox.Show("error");
            }
            Position.X = e.X;
            Position.Y = e.Y;
            Position = treeProject.PointToClient(Position);
            TreeNode DropNode = this.treeProject.GetNodeAt(Position);
            // 1.目标节点不是空。2.目标节点不是被拖拽接点的子节点。3.目标节点不是被拖拽节点本身
            if (myNode.Tag is EntityInfo)
            {
                if (DropNode != null && DropNode.Parent != myNode && DropNode != myNode)
                {
                    TreeNode DragNode = myNode;
                    // 将被拖拽节点从原来位置删除。
                    //myNode.Remove();
                    // 在目标节点下增加被拖拽节点
                    //DropNode.Nodes.Add(DragNode);

                    if (DropNode.Tag is ModuleInfo)
                    {
                        //MessageBox.Show("拖动到ModuleInfo    ->DragNode:" + myNode + ",DropNode:" + DropNode);

                        AppConf.Ins.Application.Modules.Single(s=>s== (DropNode.Tag as ModuleInfo)).Entitys.Add((DragNode.Tag as EntityInfo).Clone());
                        AppConf.Ins.Application.Modules.Single(s => s == (DragNode.Parent.Tag as ModuleInfo)).Entitys.Remove(DragNode.Tag as EntityInfo);

                        ProTreeCtrl.Ins.ReLoadTree();
                        ProTreeCtrl.Ins.ReloadModule();
                    }
                    else if (DropNode.Tag is EntityInfo){
                        //MessageBox.Show("拖动到EntityInfo  ->DragNode:" + myNode + ",DropNode:" + DropNode);

                        AppConf.Ins.Application.Modules.Single(s => s == (DropNode.Parent.Tag as ModuleInfo)).Entitys.Add((DragNode.Tag as EntityInfo).Clone());
                        AppConf.Ins.Application.Modules.Single(s => s == (DragNode.Parent.Tag as ModuleInfo)).Entitys.Remove(DragNode.Tag as EntityInfo);

                        ProTreeCtrl.Ins.ReLoadTree();
                        ProTreeCtrl.Ins.ReloadModule();
                    }
                }
            }
            else {
                MessageBox.Show("只允许拖动实体.");
            }
            //treeProject.ExpandAll();
           
            // 如果目标节点不存在，即拖拽的位置不存在节点，那么就将被拖拽节点放在根节点之下
            //if (DropNode == null)
            //{
            //    TreeNode DragNode = myNode;
            //    myNode.Remove();
            //    treeProject.Nodes.Add(DragNode);
            //}
        }

        private void 修改系统信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMApp ap = new FMApp();
            ap.ShowDialog();
        }

        private void 修改实体ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (treeProject.SelectedNode.Tag is EntityInfo)
            {
                 EntityInfo Checkedentity = treeProject.SelectedNode.Tag as EntityInfo;
                //formConf.Editedtable = Checkedentity;

                FMEntityEditor editor = new FMEntityEditor();
                editor.entity = Checkedentity;
                editor.WindowState = FormWindowState.Maximized;
                editor.RefreshModeltable += ClassDiagCtrl.Ins.editor_RefreshModeltable;
                editor.ShowDialog();

                //MessageBox.Show(Checkedentity.EntityName);
            }

        }

        private void 生成数据字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM_EXPORTDataDIC fM_EXPORTDataDIC = new FM_EXPORTDataDIC();
            fM_EXPORTDataDIC.Show();
        }
    }
}
