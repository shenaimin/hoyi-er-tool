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
    public partial class rt_lg_pg_<%%# e.ClassName  #%%> : ValidatedPage
    {
<%%# if(e.contain_uni()){
		e.calltemp_page_load_uni()
	}else{
		e.calltemp_page_load()
	}  #%%>

		public bool isRelationed(string <%%# e.rela_uni_in_field() #%%>)
		{
            if (ViewState["FIL_ID"] != null)
            {
                string <%%# e.rela_uni_out_tb_infield() #%%> = ViewState["FIL_ID"].ToString();
                return <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().ExistsBy<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>A<%%# e.rela_uni_in_field().ToParscal() #%%>(<%%# e.rela_uni_out_tb_infield() #%%>, <%%# e.rela_uni_in_field() #%%>);
            }
			return false;
		}		
	
<%%# if(e.contain_uni()){
		e.calltemp_pgload_event_uni()
	}else{
	} #%%>
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

        void ctPaging2_relation_BindsEvent(IPagingDataInfo pgd)
        {
            this.rep1.DataSource = <%%# e.ClassName #%%>Factory.Create().GetAll(pgd);
            this.rep1.DataBind();
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
                    // 删除关联表.
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
		
<%%# if(e.contain_uni()){
		e.calltemp_left_rep_item()
	}else{
	} #%%>

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
                    res = <%%# e.rela_uni_tb().ClassName #%%>Factory.Create().DeleteBy<%%# e.rela_uni_out_tb_infield().ToParscal() #%%>A<%%# e.rela_uni_in_field().ToParscal() #%%>(<%%# e.rela_uni_out_tb_infield() #%%>, <%%# e.rela_uni_in_field() #%%>);
                }
                JSController.Alert(res ? "操作关联成功!" : "操作关联失败!");
            }
            else
            {
                JSController.Alert("请选择 <%%# e.rela_uni_out_tb().EntityName #%%>，再添加关联.");
            }
        }

        protected void btnAddRelation_Click(object sender, EventArgs e)
        {
            ViewState["PG_CTRL"] = pagectrlType.RELATION;
            BindPagingCtrl();
            this.ctPaging2.Binds();
        }
    }
}