using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Expert;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model;
using Infrastructure.Baser;
using Infrastructure.Database;
using Infrastructure.Database.Pager;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>
{
    public partial class ltrpg_<%%# e.ClassName  #%%> : ValidatedPage
    {        
		protected void Page_Load(object sender, EventArgs e)
        {
            // 这里是标识当前页 分页用多少行.
            ViewState["XPG_SIZE"] = "10";
            if (!this.IsPostBack)
            {
                Reload();
                this.InitTree();
            }
            BindPagingCtrl();
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
            tree<%%# e.ClassName #%%>.Nodes.Clear();
            TreeNode rootNode = new TreeNode("<%%# e.EntityName #%%>");
            rootNode.Value = TreeNodeOBj.setRTUNodeO(true, "0");
            tree<%%# e.ClassName #%%>.Nodes.Add(rootNode);

            string rootId = "0";
            List<<%%# e.ClassName #%%>Info> <%%# e.ClassName #%%>s = getByParentId(rootId);
            AddTrees(rootNode, <%%# e.ClassName #%%>s);
            rootNode.ExpandAll();
        }

        public void RefreshNode()
        {
			TreeNode tr = tree<%%# e.ClassName #%%>.SelectedNode;
			if(tr != null){				
				TreeNodeOBj obj = TreeNodeOBj.getDeliNodeO(tree<%%# e.ClassName #%%>.SelectedNode.Value);
				tr.ChildNodes.Clear();
				List<<%%# e.ClassName #%%>Info> <%%# e.ClassName #%%>s = getByParentId(obj.obj.ToString());
				AddTrees(tr, <%%# e.ClassName #%%>s);
			}else{
                InitTree();
            }
        }

        protected void tree<%%# e.ClassName #%%>_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNodeOBj obj = TreeNodeOBj.getDeliNodeO(tree<%%# e.ClassName #%%>.SelectedNode.Value);
            if (obj != null)
            {
				string parentId = obj.obj as string;
				ViewState["FIL_ID"] = parentId;
				setFilterByID();
				
                if (!obj.Loaded)
                {
                    List<<%%# e.ClassName #%%>Info> <%%# e.ClassName #%%>s = getByParentId(parentId);
                    AddTrees(tree<%%# e.ClassName #%%>.SelectedNode, <%%# e.ClassName #%%>s);
                    tree<%%# e.ClassName #%%>.SelectedNode.Value = TreeNodeOBj.setRTUNodeO(true, parentId);

                    tree<%%# e.ClassName #%%>.SelectedNode.ExpandAll();
                }
            }
        }

        #endregion <%%# e.ClassName #%%>树控件
	
        public void BindPagingCtrl() {
            if (ViewState["PG_CTRL"] == null || (pagectrlType)ViewState["PG_CTRL"] == pagectrlType.Default)
            {
                this.ctPaging2.BindsEvent += ctPaging2_BindsEvent;
            }
            else if ((pagectrlType)ViewState["PG_CTRL"] == pagectrlType.Search)
            {
                this.ctPaging2.BindsEvent += ctPaging2_search_BindsEvent;
            }
        }
        public void Reload()
        {
            ViewState["PG_CTRL"] = pagectrlType.Default;
            this.IntPageParam();
            this.ctPaging2.Binds();
        }				

	<%%# if(e.contain_uni()){
		e.calltemp_init_param_uni()
	}else{
		e.calltemp_init_param()
	} #%%>

        protected void btnAdd_Click(object sender, EventArgs e)
        {
<%%# if(e.contain_uni()){
		e.calltemp_add_check_uni()
		}else{
			e.calltemp_add_check()
		} #%%>
			{
                <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = new <%%# e.ClassName #%%>Info();
				
				<%%# [Fields[>1]={<%#= e.ClassName #%>.<%#= t.ColumnName #%> = tx_<%#= t.ColumnName #%>.Text;
				}] #%%>

                string r_id = <%%# e.ClassName #%%>Factory.Create().AddRETUnId(<%%# e.ClassName #%%>);
				
				<%%# if(e.needfpy()){
					e.calltemp_fpy_insert()
				}else{
				} #%%>
                JSController.Alert(true ? "添加成功!" : "添加失败");
				
					<%%# [Fields[>1]={ <%#= if(t.isunikey()){
									}else{
										t.calltemp_AddCLEAR()
									} #%>}] #%%> "";
				
                int recordCount = 0;
				
				RefreshNode();

		<%%# if(e.contain_uni()){
				e.calltemp_added_bind_uni()
			}else{
				e.calltemp_added_bind()
			} #%%>

                this.ctPaging2.InitParams(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>, recordCount.ToString(), ViewState["XPG_SIZE"].ToString(), recordCount);
				this.ctPaging2.Binds();
            }
            else
            {
                JSController.Alert("已有 <%%# e.getsecfield().Comment #%%> 为:" + tx_<%%# e.getsecfieldname() #%%>.Text + " 的 <%%# e.EntityName #%%>. 请修改.");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.Search;
            int recordCount =0;
		<%%# if(e.contain_uni()){
				e.calltemp_search_click_uni()
			}else{
				e.calltemp_search_click()
			} #%%>
            this.ctPaging2.InitParams(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>, "1", ViewState["XPG_SIZE"].ToString(), recordCount);
            this.ctPaging2.BindsEvent += ctPaging2_search_BindsEvent;
            this.ctPaging2.Binds();
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.Search;
            ViewState["FIL_ID"] = null;
            Reload();
        }
		
        void ctPaging2_search_BindsEvent(IPagingDataInfo pgd)
        {
		<%%# if(e.contain_uni()){
				e.calltemp_search_bindsevent_uni()
			}else{
				e.calltemp_search_bindsevent()
			} #%%>
            this.rep1.DataBind();
        }

        protected void rep1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string <%%# e.getfirfieldName() #%%> = e.CommandArgument.ToString();
            <%%# e.ClassName #%%>Info <%%# e.ClassName #%%>;
            ViewState["XDD"] = <%%# e.getfirfieldName() #%%>;
            switch (e.CommandName)
            {
                case "Update":
                    <%%# e.ClassName #%%> = <%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);
					<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = <%#= e.ClassName #%>.<%#= t.ColumnName #%>;
					}] #%%>

                    // 这里的意思是<%%# e.getsecfieldname() #%%>不能修改，如果<%%# e.getsecfieldname() #%%>可以修改，则注释下面这句.
                    //tx_<%%# e.getsecfieldname() #%%>.Enabled = false;
                    this.btnCancelUpdate.Visible = this.btnUpdated.Visible = true;
                    this.btnAdd.Visible = this.btnReload.Visible = this.btnSearch.Visible = false;
                    //Response.Write("<script >alert('update <%%# e.ClassName #%%>:" + <%%# e.getfirfieldName() #%%> + "');</script>");
                    break;
                case "Delete":
                    <%%# e.ClassName #%%> = <%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);
                    <%%# e.ClassName #%%>Factory.Create().DeleteBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);
					
					<%%# if(e.needfpy()){
						e.calltemp_fpy_delete()
					}else{
					} #%%>
					
                    Reload();
					
					RefreshNode();
                    break;
                default:
                    break;
            }
        }

        protected void btnUpdated_Click(object sender, EventArgs e)
        {
            //<%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getsecfieldname().ToParscal() #%%>()
            // 假设可以修改<%%# e.getsecfieldname() #%%>，这里做判断是有已经有相同<%%# e.getsecfieldname() #%%>，如果有
            // <%%# e.getsecfieldname() #%%>和<%%# e.getfirfieldName() #%%>都一直，说名是自己.
            int simcount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.getfirfieldName().ToParscal() #%%>A<%%# e.getsecfieldname().ToParscal() #%%>Count(ViewState["XDD"].ToString(), tx_<%%# e.getsecfieldname() #%%>.Text);
            // 库内存有的<%%# e.getsecfieldname() #%%>集合，如果不允许重复，最多只有一条.
            int namecount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.getsecfieldname().ToParscal() #%%>Count(tx_<%%# e.getsecfieldname() #%%>.Text);
            if ((namecount > 0 && simcount == 1) || namecount <= 0)
            {
                <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = new <%%# e.ClassName #%%>Info();
                <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> = ViewState["XDD"].ToString();
				<%%# [Fields[>1]={<%#= e.ClassName #%>.<%#= t.ColumnName #%> = tx_<%#= t.ColumnName #%>.Text;
				}] #%%>

                bool suc = <%%# e.ClassName #%%>Factory.Create().UpdateBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.ClassName #%%>);
                if (suc)
                {
					<%%# if(e.needfpy()){
						e.calltemp_fpy_update()
					}else{
					} #%%>

                    this.btnAdd.Visible = this.btnReload.Visible = this.btnSearch.Visible = true;
                    this.btnCancelUpdate.Visible = this.btnUpdated.Visible = false;
                    //tx_<%%# e.getsecfieldname() #%%>.Enabled = true;
						
					
					<%%# [Fields[>1]={ <%#= if(t.isunikey()){
									}else{
										t.calltemp_AddCLEAR()
									} #%>}] #%%> "";
                }
                JSController.Alert(suc ? "修改成功!" : "修改失败");
                this.ctPaging2.Binds();
				
				RefreshNode();
            }
            else
            {
                JSController.Alert("已有 <%%# e.getsecfieldname() #%%> 为:" + tx_<%%# e.getsecfieldname() #%%>.Text + " 的 <%%# e.ClassName #%%>. 请修改.");
            }
        }

        protected void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            this.btnAdd.Visible = this.btnReload.Visible = this.btnSearch.Visible = true;
            this.btnCancelUpdate.Visible = this.btnUpdated.Visible = false;
            //tx_<%%# e.getsecfieldname() #%%>.Enabled = true;
			<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = }] #%%> "";
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            OrderCTRUtils.Create().btnOrder_Click(sender, e, ctPaging2, <%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>);
        }
        /// <summary>
        /// 设置OrderTag，设置排序的标识.↑↓ 
        /// </summary>
        /// <param name="showtext">显示的文本，区别与表的字段.</param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string OrderTag(string showtext, string field)
        {
            return OrderCTRUtils.Create().OrderTag(showtext, field, ctPaging2);
        }
		
<%%# if(e.contain_uni()){
		e.calltemp_left_rep_item()
	}else{
	} #%%>
    }
}