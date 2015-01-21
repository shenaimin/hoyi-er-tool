/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.conf;
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
    public class CheckTreeCTRL
    {
        private static CheckTreeCTRL _instance;

        public static CheckTreeCTRL Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CheckTreeCTRL();
                }
                return _instance;
            }
        }

        public TreeView CHECKTree;

        public ModuleInfo CheckedModule;

        public EntityInfo Checkedentity;

        TreeNode root;
        /// <summary>
        /// 获取已经选择的实体.
        /// </summary>
        /// <returns></returns>
        public List<ModuleInfo> getCheckedEntities()
        {
            List<ModuleInfo> mods = new List<ModuleInfo>();

            ModuleInfo chkmod ;
            EntityInfo chkeod;
            foreach (TreeNode nod in root.Nodes)
            {
                if (nod.Checked)
                {
                    chkmod = (nod.Tag as ModuleInfo).Clone();
                    foreach (TreeNode eod in nod.Nodes)
                    {
                        if (eod.Checked)
                        {
                            chkeod = eod.Tag as EntityInfo;
                            chkmod.Entitys.Add(chkeod);
                        }
                    }
                    mods.Add(chkmod);
                }
            }

            return mods;
        }
        public void ReLoadTree()
        {
            CHECKTree.Nodes.Clear();

            root = new TreeNode();
            root.Text = AppConf.Ins.Application.AppName;
            root.Tag = AppConf.Ins.Application;
            CHECKTree.Nodes.Add(root);


            TreeNode moduleNode, entityNode;
            foreach (ModuleInfo module in AppConf.Ins.Application.Modules)
            {
                moduleNode = new TreeNode(module.ModuleName + "[" + module.Caption + "," + module.Prefix + "]");
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
            CHECKTree.AfterCheck += CHECKTree_AfterCheck;
            CHECKTree.CheckBoxes = true;
            CHECKTree.ExpandAll();
        }
        void CHECKTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);
                //选中父节点 
                bool bol = true;
                if (e.Node.Parent != null)
                {
                    e.Node.Parent.Checked = brotherchecked(e.Node.Parent);
                }
            }
        }
        /// <summary>
        /// 判断兄弟节点是否有选中的
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public bool brotherchecked(TreeNode treeNode)
        {
            foreach (TreeNode no in treeNode.Nodes)
            {
                if (no.Checked)
                {
                    return no.Checked;
                }
            }
            return false;
        }
        #region  选中子节点
        public void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        #endregion
    }
}
