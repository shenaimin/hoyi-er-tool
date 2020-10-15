using HOYIENTITY.<%%# m.Caption #%%>;
using CTERP.Paging;
using Infrastructure.Baser;
using Infrastructure.Database;
using Infrastructure.Database.ctrl;
using Infrastructure.Database.Pager;
using Infrastructure.Database.Model;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTERP.page.mds.<%%# m.Caption #%%>.p<%%# e.ClassName #%%>
{
    public partial class simpg_<%%# e.ClassName  #%%> : ValidatedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 这里是标识当前页 分页用多少行.
            ViewState["XPG_SIZE"] = "10";
            if (!this.IsPostBack)
            {
                Reload();
            }
            BindPagingCtrl();
        }
		
        public void BindPagingCtrl() 
		{
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

        public void IntPageParam() {
            int recordCount = <%%# e.ClassName #%%>.E.Count();
            ViewState["DATACOUNT"] = recordCount;
            this.ctPaging2.InitParams(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.fieldname, "1", ViewState["XPG_SIZE"].ToString(), recordCount);
            this.ctPaging2.BindsEvent += ctPaging2_BindsEvent;
        }

        void ctPaging2_BindsEvent(IPagingDataInfo pgd)
        {
            //int recordCount = <%%# e.ClassName #%%>.E.Count();

            string recordcount = ViewState["DATACOUNT"].ToString();
            this.rep1.DataSource = <%%# e.ClassName #%%>.E.PgInfo(pgd, recordcount).Select();
            this.rep1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
			<%%# [Fields[Equals(1)]={if (!<%#= e.ClassName #%>.E.Where(<%#= e.ClassName #%>.<%#= t.ColumnName #%> == tx_<%#= t.ColumnName #%>.Text).Exists())		}] #%%>
			{
                <%%# e.ClassName #%%> _<%%# e.ClassName #%%> = new <%%# e.ClassName #%%>();
				<%%# [Fields[>1]={_<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%> = tx_<%#= t.ColumnName #%>.Text.To<%#= t.TypeName.ToParscal() #%>();
				}] #%%>
                string r_id = _<%%# e.ClassName #%%>.Insert_RETURN_STRID();
                <%%# if(e.needfpy()){
					e.calltemp_fpy_insert()
				}else{
				} #%%>
                JSController.Alert(this, true ? "添加成功!" : "添加失败");
				
				<%%# [Fields[>1]={ <%#= t.calltemp_AddCLEAR()#%>}] #%%> "";
				
                int recordCount = <%%# e.ClassName #%%>.E.Count();
                this.ctPaging2.InitParams(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.fieldname, recordCount.ToString(), ViewState["XPG_SIZE"].ToString(), recordCount);

                this.ctPaging2.Binds();
            }
            else
            {
                JSController.Alert(this, "已有 <%%# e.getsecfield().Comment #%%> 为:" + tx_<%%# e.getsecfieldname() #%%>.Text + " 的 <%%# e.EntityName #%%>. 请修改.");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.Search;
            int recordCount = <%%# e.ClassName #%%>.E.Where(
				<%%# [Fields[Equals(1)]={ <%#= e.ClassName #%>.<%#= t.ColumnName #%> / tx_<%#= t.ColumnName #%>.Text
				}] #%%><%%# [Fields[>2]={ & <%#= e.ClassName #%>.<%#= t.ColumnName #%> / tx_<%#= t.ColumnName #%>.Text
				}] #%%>).Count();
            this.ctPaging2.InitParams(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.fieldname, "1", ViewState["XPG_SIZE"].ToString(), recordCount);

            this.ctPaging2.BindsEvent += ctPaging2_search_BindsEvent;
            this.ctPaging2.Binds();
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.Search;
            Reload();
        }
		
        void ctPaging2_search_BindsEvent(IPagingDataInfo pgd)
        {
            this.rep1.DataSource = <%%# e.ClassName #%%>.E.Where(
				<%%# [Fields[Equals(1)]={ <%#= e.ClassName #%>.<%#= t.ColumnName #%> / tx_<%#= t.ColumnName #%>.Text
				}] #%%><%%# [Fields[>2]={ & <%#= e.ClassName #%>.<%#= t.ColumnName #%> / tx_<%#= t.ColumnName #%>.Text
				}] #%%>).Select();
			this.rep1.DataBind();
        }

        protected void rep1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string <%%# e.getfirfieldName() #%%> = e.CommandArgument.ToString();
            <%%# e.ClassName #%%> _<%%# e.ClassName #%%>;
            ViewState["XDD"] = <%%# e.getfirfieldName() #%%>;
            switch (e.CommandName)
            {
                case "Update":
                    _<%%# e.ClassName #%%> = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == <%%# e.getfirfieldName() #%%>).First<<%%# e.ClassName #%%>>();
					<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = _<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%>.ToString();
					}] #%%>
                    // 这里的意思是<%%# e.getsecfieldname() #%%>不能修改，如果<%%# e.getsecfieldname() #%%>可以修改，则注释下面这句.
                    //tx_<%%# e.getsecfieldname() #%%>.Enabled = false;
                    this.btnCancelUpdate.Visible = this.btnUpdated.Visible = true;
                    this.btnAdd.Visible = this.btnReload.Visible = this.btnSearch.Visible = false;
                    //Response.Write("<script >alert('update <%%# e.ClassName #%%>:" + <%%# e.getfirfieldName() #%%> + "');</script>");
                    break;
                case "Delete":
					<%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == <%%# e.getfirfieldName() #%%>).Delete();
					
                    <%%# if(e.needfpy()){
						e.calltemp_fpy_delete()
					}else{
					} #%%>
                    Reload();
                    break;
                default:
                    break;
            }
        }

        protected void btnUpdated_Click(object sender, EventArgs e)
        {
            // 假设可以修改<%%# e.getsecfieldname() #%%>，这里做判断是有已经有相同<%%# e.getsecfieldname() #%%>，如果有
            // <%%# e.getsecfieldname() #%%>和<%%# e.getfirfieldName() #%%>都一直，说名是自己.
			int simcount = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == ViewState["XDD"].ToString() & <%%# e.ClassName #%%>.<%%# e.getsecfieldname() #%%> == tx_<%%# e.getsecfieldname() #%%>.Text).Count();
            // 库内存有的<%%# e.getsecfieldname() #%%>集合，如果不允许重复，最多只有一条.
            int namecount = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getsecfieldname() #%%> == tx_<%%# e.getsecfieldname() #%%>.Text).Count();
			if ((namecount > 0 && simcount == 1) || namecount <= 0)
            {
                <%%# e.ClassName #%%> _<%%# e.ClassName #%%> = new <%%# e.ClassName #%%>();
                _<%%# e.ClassName #%%>.<%%# e.getfirfieldName().ToParscal() #%%> = ViewState["XDD"].ToString().To<%%# e.getfirfield().TypeName.ToParscal() #%%>();
				<%%# [Fields[>1]={_<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%> = tx_<%#= t.ColumnName #%>.Text.To<%#= t.TypeName.ToParscal() #%>();
				}] #%%>
				int ret = _<%%# e.ClassName #%%>.Update();
                if (ret > 0)
                {<%%# if(e.needfpy()){
						e.calltemp_fpy_update()
					}else{
					} #%%>
                    this.btnAdd.Visible = this.btnReload.Visible = this.btnSearch.Visible = true;
                    this.btnCancelUpdate.Visible = this.btnUpdated.Visible = false;
                    //tx_<%%# e.getsecfieldname() #%%>.Enabled = true;
						
					<%%# [Fields[>1]={ <%#= t.calltemp_AddCLEAR() #%>}] #%%> "";
                }
                JSController.Alert(this, ret > 0 ? "修改成功!" : "修改失败");
                this.ctPaging2.Binds();
            }
            else
            {
                JSController.Alert(this, "已有 <%%# e.getsecfieldname() #%%> 为:" + tx_<%%# e.getsecfieldname() #%%>.Text + " 的 <%%# e.ClassName #%%>. 请修改.");
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
            OrderCTRUtils.Create().btnOrder_Click(sender, e, ctPaging2, <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.fieldname);
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
        /// <summary>
        /// 设置OrderTag，设置排序的标识.↑↓ 
        /// </summary>
        /// <param name="showtext">显示的文本，区别与表的字段.</param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string OrderTag(string showtext, AttField field)
        {
            return OrderCTRUtils.Create().OrderTag(showtext, field.fieldname, ctPaging2);
        }
    }
}