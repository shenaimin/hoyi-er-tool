using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Expert;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Extend;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.IExpert;
using Infrastructure.Database.Cluster;
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
    public partial class r_lg_pg_<%%# e.ClassName  #%%> : ValidatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 这里是标识当前页 分页用多少行.
            ViewState["XPG_SIZE"] = "10";
            // Filter 的分页条数.
            ViewState["FLT_SIZE"] = "10";
            if (!this.IsPostBack)
            {
                Reload();
				InitTree();
            }
            BindPagingCtrl();
        }
	
        #region <%%# e.rela_uni_out_tb_name() #%%>树控件

        public List<<%%# e.rela_uni_out_tb_name() #%%>Info> getBy<%%# e.rela_uni_out_tb_name().ToParscal() #%%><%%# e.rela_uni_out_tb().self_uni_in_name().ToParscal() #%%>(string <%%# e.rela_uni_out_tb().self_uni_in_name() #%%>)
        {
            int recordCount = <%%# e.rela_uni_out_tb_name() #%%>Factory.Create().GetBy<%%# e.rela_uni_out_tb().self_uni_in_name().ToParscal() #%%>Count(<%%# e.rela_uni_out_tb().self_uni_in_name() #%%>);
            IPagingDataInfo pgInfo = new IPagingDataInfo(<%%# e.rela_uni_out_tb_name() #%%>Info.F_<%%# e.rela_uni_out_tb().getfirfieldname() #%%>, recordCount.ToString(), "1");
            return <%%# e.rela_uni_out_tb_name() #%%>Info.TransDataTable(<%%# e.rela_uni_out_tb_name() #%%>Factory.Create().GetBy<%%# e.rela_uni_out_tb().self_uni_in_name().ToParscal() #%%>(pgInfo, <%%# e.rela_uni_out_tb().self_uni_in_name() #%%>));
        }

        public void AddTrees(TreeNode parentNode, List<<%%# e.rela_uni_out_tb_name() #%%>Info> <%%# e.rela_uni_out_tb_name() #%%>s)
        {
            TreeNode tmpNode;

            foreach (<%%# e.rela_uni_out_tb_name() #%%>Info <%%# e.rela_uni_out_tb_name() #%%> in <%%# e.rela_uni_out_tb_name() #%%>s)
            {
                tmpNode = new TreeNode(<%%# e.rela_uni_out_tb_name() #%%>.<%%# e.rela_uni_out_tb().getsecfieldname() #%%>);
                tmpNode.Value = TreeNodeOBj.setRTUNodeO(false, <%%# e.rela_uni_out_tb_name() #%%>.<%%# e.rela_uni_out_tb().getfirfieldname() #%%>);
                parentNode.ChildNodes.Add(tmpNode);
            }
        }

        public void InitTree()
        {
            tree<%%# e.rela_uni_out_tb_name() #%%>.Nodes.Clear();
            TreeNode rootNode = new TreeNode("<%%# e.rela_uni_out_tb().EntityName #%%>");
            rootNode.Value = TreeNodeOBj.setRTUNodeO(true, "0");
            tree<%%# e.rela_uni_out_tb_name() #%%>.Nodes.Add(rootNode);

            string rootId = "0";
            List<<%%# e.rela_uni_out_tb_name() #%%>Info> <%%# e.rela_uni_out_tb_name() #%%>s = getBy<%%# e.rela_uni_out_tb_name().ToParscal() #%%><%%# e.rela_uni_out_tb().self_uni_in_name().ToParscal() #%%>(rootId);
            AddTrees(rootNode, <%%# e.rela_uni_out_tb_name() #%%>s);
            rootNode.ExpandAll();
        }

        public void RefreshNode()
        {
			TreeNode tr = tree<%%# e.rela_uni_out_tb_name() #%%>.SelectedNode;
			if(tr != null){				
				TreeNodeOBj obj = TreeNodeOBj.getDeliNodeO(tree<%%# e.rela_uni_out_tb_name() #%%>.SelectedNode.Value);
				tr.ChildNodes.Clear();
				List<<%%# e.rela_uni_out_tb_name() #%%>Info> <%%# e.rela_uni_out_tb_name() #%%>s = getBy<%%# e.rela_uni_out_tb_name().ToParscal() #%%><%%# e.rela_uni_out_tb().self_uni_in_name().ToParscal() #%%>(obj.obj.ToString());
				AddTrees(tr, <%%# e.rela_uni_out_tb_name() #%%>s);
			}else{
                InitTree();
            }
        }

        protected void tree<%%# e.rela_uni_out_tb_name() #%%>_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNodeOBj obj = TreeNodeOBj.getDeliNodeO(tree<%%# e.rela_uni_out_tb_name() #%%>.SelectedNode.Value);
            if (obj != null)
            {
				string <%%# e.unself_out_field_name() #%%> = obj.obj as string;
				ViewState["FIL_ID"] = <%%# e.unself_out_field_name() #%%>;
				setFilterByID();
				
                if (!obj.Loaded)
                {
                    List<<%%# e.rela_uni_out_tb_name() #%%>Info> <%%# e.rela_uni_out_tb_name() #%%>s = getBy<%%# e.rela_uni_out_tb_name().ToParscal() #%%><%%# e.rela_uni_out_tb().self_uni_in_name().ToParscal() #%%>(<%%# e.unself_out_field_name() #%%>);
                    AddTrees(tree<%%# e.rela_uni_out_tb_name() #%%>.SelectedNode, <%%# e.rela_uni_out_tb_name() #%%>s);
                    tree<%%# e.rela_uni_out_tb_name() #%%>.SelectedNode.Value = TreeNodeOBj.setRTUNodeO(true, <%%# e.unself_out_field_name() #%%>);

                    tree<%%# e.rela_uni_out_tb_name() #%%>.SelectedNode.ExpandAll();
                }
            }
        }

        #endregion <%%# e.rela_uni_out_tb_name() #%%>树控件
	
		public bool isRelationed(string <%%# e.rela_uni_in_field() #%%>)
		{
            if (ViewState["FIL_ID"] != null)
            {
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                return <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().ExistsBy<%%# e.rela_uni_in_field().ToParscal() #%%>A<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>(<%%# e.rela_uni_in_field() #%%>, <%%# e.rela_uni_out_tb_infield() #%%>);
            }
			return false;
		}	
		
        public void BindPagingCtrl() {
            if (ViewState["PG_CTRL"] == null || (pagectrlType)ViewState["PG_CTRL"] == pagectrlType.Default)
            {
                this.ctPaging2.BindsEvent += ctPaging2_BindsEvent;
            }
            else if ((pagectrlType)ViewState["PG_CTRL"] == pagectrlType.Search)
            {
                this.ctPaging2.BindsEvent += ctPaging2_search_BindsEvent;
            }else if ((pagectrlType)ViewState["PG_CTRL"] == pagectrlType.RELATION)
            {
                this.ctPaging2.BindsEvent += ctPaging2_relation_BindsEvent;
            }
        }
        public void Reload()
        {
            //ViewState["PG_CTRL"] = pagectrlType.Default;
            this.IntPageParam();
            this.ctPaging2.Binds();
        }
								

        public void IntPageParam() {
            int recordCount = 0;
            if (ViewState["FIL_ID"] == null)
            {
                recordCount = <%%# e.ClassName #%%>Factory.Create().GetAllCount();
            }
            else
            {
                // 这里是根据relationship 关联表来查询
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                recordCount = <%%# e.ClassName #%%>Extend.Create().Get<%%# e.ClassName #%%>By<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>Count(<%%# e.rela_uni_out_tb_infield() #%%>);
            }
            this.ctPaging2.InitParams(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>, "1", ViewState["XPG_SIZE"].ToString(), recordCount);
            this.ctPaging2.BindsEvent += ctPaging2_BindsEvent;
        }

        void ctPaging2_BindsEvent(IPagingDataInfo pgd)
        {
            if (ViewState["FIL_ID"] == null)
            {
				this.rep1.DataSource = <%%# e.ClassName #%%>Factory.Create().GetAll(pgd);
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>Name.Text = "未选择<%%# e.rela_uni_out_tb().EntityName  #%%>，这里显示所有<%%# e.rela_uni_out_tb().EntityName  #%%>";

                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
				this.rep1.DataSource = <%%# e.ClassName #%%>Extend.Create().Get<%%# e.ClassName #%%>By<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>(pgd, <%%# e.rela_uni_out_tb_infield() #%%>);
                //this.rep1.DataSource = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.unikey_in_fieldname().ToParscal() #%%>(pgd, <%%# e.unikey_in_fieldname() #%%>);
            }
            this.rep1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // 如果只能存续一个名字.
            if (ViewState["FIL_ID"] == null)
            {
                JSController.Alert("添加前，请先选择<%%# e.unienti().EntityName  #%%>.");
            }
            string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
            //if (!<%%# e.rela_uni_tb() #%%>Factory.Create().ExistsBy<%%# e.rela_uni_in_field().ToParscal() #%%>A<%%# e.rela_uni_out_tb_infield().ToParscal()  #%%>(tx_<%%# e.rela_uni_in_field() #%%>.Text, <%%# e.rela_uni_out_tb_infield()  #%%>))
			//if(true)
			if (!<%%# e.ClassName #%%>Factory.Create().ExistsBy<%%# e.getsecfield().ColumnName.ToParscal() #%%>(tx_<%%# e.getsecfield().ColumnName #%%>.Text)) 
			{
                <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = new <%%# e.ClassName #%%>Info();
				
				<%%# [Fields[>1]={<%#= e.ClassName #%>.<%#= t.ColumnName #%> = tx_<%#= t.ColumnName #%>.Text;
				}] #%%>

                string <%%# e.rela_uni_in_field() #%%> = <%%# e.ClassName #%%>Factory.Create().AddRETUnId(<%%# e.ClassName #%%>);
				
                // 插入关联表.

                <%%# e.rela_uni_tb().ClassName #%%>Info relation = new <%%# e.rela_uni_tb().ClassName #%%>Info();
                relation.<%%# e.rela_uni_in_field() #%%> = <%%# e.rela_uni_in_field() #%%>;
                relation.<%%# e.rela_uni_out_tb_infield() #%%> = <%%# e.rela_uni_out_tb_infield() #%%>;
                <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().Add(relation);
				
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

                if (ViewState["FIL_ID"] == null)
                {
                    recordCount = <%%# e.ClassName #%%>Factory.Create().GetAllCount();
                }
                else
                {
					recordCount = <%%# e.ClassName #%%>Extend.Create().Get<%%# e.ClassName #%%>By<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>Count(<%%# e.rela_uni_out_tb_infield() #%%>);
                    //recordCount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.unikey_in_fieldname().ToParscal() #%%>Count(<%%# e.unikey_out_fieldname() #%%>);
                }

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

            if (ViewState["FIL_ID"] == null)
            {
				 recordCount = <%%# e.ClassName #%%>Factory.Create().LikeBy<%%# e.getsecfieldname().ToParscal() #%%>Count(tx_<%%# e.getsecfieldname() #%%>.Text);
            }
            else
            {
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                recordCount = <%%# e.ClassName #%%>Extend.Create().LikeBy<%%# e.getsecfieldname().ToParscal() #%%>A<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>Count(<%%# e.rela_uni_out_tb_infield() #%%>, tx_<%%# e.getsecfieldname() #%%>.Text);
            }

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

        void ctPaging2_relation_BindsEvent(IPagingDataInfo pgd)
        {
            this.rep1.DataSource = <%%# e.ClassName #%%>Factory.Create().GetAll(pgd);
            this.rep1.DataBind();
        }
		
        void ctPaging2_search_BindsEvent(IPagingDataInfo pgd)
        {
			if (ViewState["FIL_ID"] ==null)
            {
				this.rep1.DataSource = <%%# e.ClassName #%%>Factory.Create().LikeBy<%%# e.getsecfieldname().ToParscal() #%%>(pgd, tx_<%%# e.getsecfieldname() #%%>.Text);        
            }
            else
            {
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();            
                this.rep1.DataSource = <%%# e.ClassName #%%>Extend.Create().LikeBy<%%# e.getsecfieldname().ToParscal() #%%>A<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>(pgd, tx_<%%# e.getsecfieldname() #%%>.Text, <%%# e.rela_uni_out_tb_infield() #%%>);
            }
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
                    // 插入关联表.
                    if (ViewState["FIL_ID"] != null)
                    {
                        string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                        <%%# e.ClassName #%%> = <%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);

                        <%%# e.rela_uni_tb().ClassName #%%>Info relation = new <%%# e.rela_uni_tb().ClassName #%%>Info();
                        relation.<%%# e.rela_uni_in_field() #%%> = <%%# e.ClassName #%%>.<%%# e.rela_uni_in_field() #%%>;
                        relation.<%%# e.rela_uni_out_tb_infield() #%%> = <%%# e.rela_uni_out_tb_infield() #%%>;
                        <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().DeleteBy<%%# e.rela_uni_in_field().ToParscal() #%%>A<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>(relation.<%%# e.rela_uni_in_field() #%%>, relation.<%%# e.rela_uni_out_tb_infield() #%%>);
                        <%%# e.ClassName #%%>Factory.Create().DeleteBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);
<%%# if(e.needfpy()){
							e.calltemp_fpy_delete()
						}else{
						} #%%>
                        Reload();
                    }
                    else
                    {
                        JSController.Alert("找不到对应的 岗位 信息，请先选择岗位.");
                    }
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

        protected void chk_RELATION_CheckedChanged(object sender, EventArgs e)
        {
            if (ViewState["FIL_ID"] != null)
            {
                CheckBox chk = sender as CheckBox;
                string <%%# e.rela_uni_in_field() #%%> = chk.Attributes["CommandArgument"];
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                // 插入关联表.

                <%%# e.rela_uni_tb().ClassName #%%>Info relation = new <%%# e.rela_uni_tb().ClassName #%%>Info();
                relation.<%%# e.rela_uni_in_field() #%%> = <%%# e.rela_uni_in_field() #%%>;
                relation.<%%# e.rela_uni_out_tb_infield() #%%> = <%%# e.rela_uni_out_tb_infield() #%%>;
                
                bool res;
                if (chk.Checked)
                {
                    res = <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().Add(relation);
                }
                else
                {
                    res = <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().DeleteBy<%%# e.rela_uni_in_field().ToParscal() #%%>A<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>(<%%# e.rela_uni_in_field() #%%>, <%%# e.rela_uni_out_tb_infield() #%%>);
                }
                JSController.Alert(res ? "操作关联成功!" : "操作关联失败!");
            }
            else
            {
                JSController.Alert("请选择 <%%# e.rela_uni_out_tb().EntityName #%%>，再添加关联.");
            }
        }
		
        public void setFilterByID()
        {
            if (ViewState["FIL_ID"] == null)
            {
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>Name.Text = "未选择<%%# e.rela_uni_out_tb().EntityName #%%>，这里显示所有<%%# e.rela_uni_out_tb().EntityName #%%>";
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>.Text = "";
            }
            else
            {
                string <%%# e.rela_uni_out_tb().getfirfieldname() #%%> = ViewState["FIL_ID"].ToString();
                //tx_<%%# e.rela_uni_const().Column_Name #%%>.Text = <%%# e.rela_uni_out_tb().getfirfieldname() #%%>;
                <%%# e.rela_uni_out_tb_name() #%%>Info <%%# e.rela_uni_out_tb_name() #%%> = <%%# e.rela_uni_out_tb_name() #%%>Factory.Create().GetSimpleBy<%%# e.rela_uni_out_tb().getfirfieldname().ToParscal() #%%>(<%%# e.rela_uni_out_tb().getfirfieldname() #%%>);
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>Name.Text = <%%# e.rela_uni_out_tb_name() #%%>.<%%# e.rela_uni_out_tb().getsecfieldname() #%%>;
                lb_checked<%%# e.rela_uni_out_tb_name()  #%%>.Text = <%%# e.rela_uni_out_tb_name() #%%>.ToJson();
            }

            Reload();
        }

        protected void btnAddRelation_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.RELATION;
            BindPagingCtrl();
            this.ctPaging2.Binds();
        }
    }
}