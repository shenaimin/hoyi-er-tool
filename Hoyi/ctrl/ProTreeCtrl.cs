/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.appConf;
using Hoyi.conf;
using Hoyi.forms;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.ctrl
{
    public class ProTreeCtrl
    {
        private static ProTreeCtrl _instance;

        public static ProTreeCtrl Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProTreeCtrl();
                }
                return _instance;
            }
        }

        public TreeView ProTree;
        /// <summary>
        /// 选中模型的节点.
        /// </summary>
        public TreeNode CheckedModuleNode;
        /// <summary>
        /// 选中的模型
        /// </summary>
        public ModuleInfo CheckedModule;
        /// <summary>
        /// 选中的实体.
        /// </summary>
        public EntityInfo Checkedentity;

        /// <summary>
        /// 重新加载当前树.
        /// </summary>
        public void ReLoadTree()
        {
            //LoadingPageCtrls.ShowLoading();
            cancheck = false;
            ProTree.Nodes.Clear();

            TreeNode root = new TreeNode();
            root.Text = AppConf.Ins.Application.AppName;
            root.Tag = AppConf.Ins.Application;
            ProTree.Nodes.Add(root);


            TreeNode moduleNode, entityNode;
            foreach (ModuleInfo module in AppConf.Ins.Application.Modules)
            {
                moduleNode = new TreeNode(module.ModuleName + "[" + module.Caption + "," + module.Prefix + ",ent:" + module.Entitys.Count + "]");
                moduleNode.Tag = module;

                root.Nodes.Add(moduleNode);

                foreach (EntityInfo entity in module.Entitys)
                {
                    entityNode = new TreeNode(entity.EntityName + "[" + entity.ClassName + "]");
                    //entityNode = new TreeNode(entity.EntityName + "[" + entity.ClassName + ",ops:" + entity.operaters.Count + "]");
                    entityNode.Tag = entity;

                    moduleNode.Nodes.Add(entityNode);
                }
                CheckedModuleNode = moduleNode;
                CheckedModule = module;
            }
            if (AppConf.Ins.Application.Modules.Count > 0)
            {
                CheckedModule = AppConf.Ins.Application.Modules[0];
                if (ProTree.Nodes != null)
                {
                    if (ProTree.Nodes[0].Nodes != null)
                    {
                        CheckedModuleNode = ProTree.Nodes[0].Nodes[0];
                    }
                }
            }
            if (AppConf.Ins.Application.Modules.Count < 3)
            {
                ProTree.ExpandAll();
            }
            else
            {
                FMClass.Ins.toolStripButton2_Click_1(null, null);
            }
            //ProTree.AfterSelect += ProTree_AfterSelect;
            cancheck = true;


            AppConf.Ins.DocSaved = false;

            if (CheckedModule != null)
            {
                if (AppConf.Ins.Application.Modules != null)
                {
                    FMClass.Ins.tslbtatus.Text = "状态：模型加载完成.共加载 " + AppConf.Ins.Application.Modules.Count + "个模块";
                }
                else
                {
                    FMClass.Ins.tslbtatus.Text = "状态：模型加载完成.共加载0个模块";
                }
                FMClass.Ins.tslbcheckedmodule.Text = "选中模块:" + CheckedModule.ModuleName;
            }
            else
            {
                FMClass.Ins.tslbcheckedmodule.Text = "选中模块: 无";
            }

            //LoadingPageCtrls.ShowLoading();
        }
        /// <summary>
        /// 重新加载当前Module的节点.
        /// </summary>
        public void ReLoadTreeModule()
        {
            cancheck = false;
            TreeNode entityNode;
            CheckedModuleNode.Nodes.Clear();
            foreach (EntityInfo entity in CheckedModule.Entitys)
            {
                entityNode = new TreeNode(entity.EntityName + "[" + entity.ClassName + ",ops:" + entity.operaters.Count + "]");
                entityNode.Tag = entity;

                CheckedModuleNode.Nodes.Add(entityNode);
            }
            //ProTree.AfterSelect += ProTree_AfterSelect;
            cancheck = true;

            AppConf.Ins.DocSaved = false;

            if (CheckedModule != null)
            {
                if (AppConf.Ins.Application.Modules != null)
                {
                    FMClass.Ins.tslbtatus.Text = "状态：添加一个实体";
                }
                else
                {
                    FMClass.Ins.tslbtatus.Text = "状态：添加一个实体";
                }
                FMClass.Ins.tslbcheckedmodule.Text = "选中模块:" + CheckedModule.ModuleName;
            }
            else
            {
                FMClass.Ins.tslbcheckedmodule.Text = "选中模块: 无";
            }

            //LoadingPageCtrls.ShowLoading();
        }
        /// <summary>
        /// 重新加载模型.
        /// </summary>
        public void ReloadModule()
        {
            AppConf.Ins.views_enkey.Clear();
            AppConf.Ins.views_tbkey.Clear();

            //CheckedModule = _module;
            //MessageBox.Show(CheckedModule.ModuleName);
            ClassDiagCtrl.Ins.ClearModel();
            ClassDiagCtrl.Ins.LoadFromModuleInfo(CheckedModule);
            ConnCtrl.Ins.LoadConnects(ClassDiagCtrl.Ins.currentModel, AppConf.Ins.Application.Conns);

            AppConf.Ins.DocSaved = false;
        }


        /**
        树的右键选中.
        */    
        public void ProTree_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = ProTree.GetNodeAt(ClickPoint);
                if (CurrentNode != null) {
                    FMClass.Ins.ShowHideContextItem(CurrentNode.Tag);
                    ProTree.SelectedNode = CurrentNode;
                }
            }
        }

        public void ProTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FMClass.Ins.tslbtatus.Text = "状态：模块加载中...";
            //ProTree.ExpandAll();
            if (cancheck)
            {
                if (ProTree.SelectedNode != null)
                {
                    if (ProTree.SelectedNode.Tag is ModuleInfo)
                    {
                        CheckedModule = ProTree.SelectedNode.Tag as ModuleInfo;
                        CheckedModuleNode = ProTree.SelectedNode;
                        ReloadModule();
                    }
                    if (ProTree.SelectedNode.Tag is EntityInfo)
                    {
                        Checkedentity = ProTree.SelectedNode.Tag as EntityInfo;
                        //formConf.Editedtable = Checkedentity;

                        FMEntityEditor editor = new FMEntityEditor();
                        editor.entity = Checkedentity;
                        editor.WindowState = FormWindowState.Maximized;
                        editor.RefreshModeltable += ClassDiagCtrl.Ins.editor_RefreshModeltable;
                        editor.ShowDialog();

                        //MessageBox.Show(Checkedentity.EntityName);
                    }
                }
            }
            FMClass.Ins.tslbtatus.Text = "状态：模块加载完成.";
            if(CheckedModule != null)
            {
                FMClass.Ins.tslbtatus.Text = "状态：模块[ " + CheckedModule.ModuleName +" ]加载完成.共加载 " + CheckedModule.Entitys.Count + "个实体";
                FMClass.Ins.tslbcheckedmodule.Text = "选中模块:" + CheckedModule.ModuleName;
            }
            else
            {
                FMClass.Ins.tslbcheckedmodule.Text = "选中模块: 无";
            }
            //ProTree.ExpandAll();
        }
        /// <summary>
        /// 模拟选中当前模型.
        /// </summary>
        /// <param name="module"></param>
        public void CheckModule(ModuleInfo module)
        {
            foreach (TreeNode tr in ProTree.Nodes[0].Nodes)
            {
                if (tr.Tag.Equals(module))
                {
                    ProTree.SelectedNode = tr;
                }
            }
            ProTree_AfterSelect(null, null);
        }
        public bool cancheck = false;

        void ProTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
    }
}
