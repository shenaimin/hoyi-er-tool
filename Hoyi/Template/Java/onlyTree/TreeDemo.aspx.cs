using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Expert;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model;
using Infrastructure.Database.Pager;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// 树控件只对自循环对象有用.
namespace CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>
{
    public partial class pgtree_<%%# e.ClassName #%%> : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.InitTree();
            }
        }

        #region <%%# e.ClassName #%%>树控件

        public List<<%%# e.ClassName #%%>Info> getByParentId(string parentId)
        {
            int recordCount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.self_uni_in_name().ToParscal() #%%>Count(parentId);
            IPagingDataInfo pgInfo = new IPagingDataInfo(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldname() #%%>, recordCount.ToString(), "1");
            return <%%# e.ClassName #%%>Info.TransDataTable(<%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.self_uni_in_name().ToParscal() #%%>(pgInfo, parentId));
        }

        public void AddTrees(TreeNode parentNode, List<<%%# e.ClassName #%%>Info> <%%# e.ClassName #%%>s)
        {
            TreeNode tmpNode;

            foreach (<%%# e.ClassName #%%>Info <%%# e.ClassName #%%> in <%%# e.ClassName #%%>s)
            {
                tmpNode = new TreeNode(<%%# e.ClassName #%%>.<%%# e.getsecfieldname() #%%>);
                tmpNode.Value = TreeNodeOBj.setRTUNodeO(false, <%%# e.ClassName #%%>.<%%# e.getfirfieldname() #%%>);
                parentNode.ChildNodes.Add(tmpNode);
            }
        }

        public void InitTree()
        {
            TreeNode rootNode = new TreeNode("<%%# e.EntityName #%%>");
            tree<%%# e.ClassName #%%>.Nodes.Add(rootNode);

            string rootId = "0";
            List<<%%# e.ClassName #%%>Info> <%%# e.ClassName #%%>s = getByParentId(rootId);
            AddTrees(rootNode, <%%# e.ClassName #%%>s);
        }

        protected void tree<%%# e.ClassName #%%>_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNodeOBj obj = TreeNodeOBj.getDeliNodeO(tree<%%# e.ClassName #%%>.SelectedNode.Value);
            if (obj != null)
            {
                if (!obj.Loaded)
                {
                    string parentId = obj.obj as string;

                    List<<%%# e.ClassName #%%>Info> <%%# e.ClassName #%%>s = getByParentId(parentId);
                    AddTrees(tree<%%# e.ClassName #%%>.SelectedNode, <%%# e.ClassName #%%>s);
                    tree<%%# e.ClassName #%%>.SelectedNode.Value = TreeNodeOBj.setRTUNodeO(true, parentId);

                    tree<%%# e.ClassName #%%>.SelectedNode.ExpandAll();
                }
            }
        }

        #endregion <%%# e.ClassName #%%>树控件

    }
}