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
using Hoyi.forms;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
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

        public ModuleInfo CheckedModule;

        public EntityInfo Checkedentity;

        public void ReLoadTree()
        {
            cancheck = false;
            ProTree.Nodes.Clear();

            TreeNode root = new TreeNode();
            root.Text = AppConf.Ins.Application.AppName;
            root.Tag = AppConf.Ins.Application;
            ProTree.Nodes.Add(root);


            TreeNode moduleNode, entityNode;
            foreach (ModuleInfo module in AppConf.Ins.Application.Modules)
            {
                moduleNode = new TreeNode(module.ModuleName + "[" + module.Caption +"," + module.Prefix+ "]");
                moduleNode.Tag = module;

                root.Nodes.Add(moduleNode);

                foreach (EntityInfo entity in module.Entitys)
                {
                    entityNode = new TreeNode(entity.EntityName + "[" + entity.ClassName + ",ops:" + entity.operaters.Count + "]");
                    entityNode.Tag = entity;

                    moduleNode.Nodes.Add(entityNode);
                }
                CheckedModule = module;
            }
            if (AppConf.Ins.Application.Modules.Count > 0)
            {
                CheckedModule = AppConf.Ins.Application.Modules[0];
            }
            ProTree.ExpandAll();
            //ProTree.AfterSelect += ProTree_AfterSelect;
            cancheck = true;
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
        }

        public void ProTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (cancheck)
            {
                if (ProTree.SelectedNode.Tag is ModuleInfo)
                {
                    CheckedModule = ProTree.SelectedNode.Tag as ModuleInfo;
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
