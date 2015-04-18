using HOYIENTITY.<%%# m.Caption #%%>;
using Infrastructure.Baser;
using Infrastructure.Database;
using Infrastructure.Database.ctrl;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTERP.page.mds.<%%# m.Caption #%%>.p<%%# e.ClassName #%%>
{
    public partial class simsw_<%%# e.ClassName #%%> : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string <%%# e.getfirfieldName() #%%> = Request.QueryString["paraid"];//这里不用默认字段，尽可能的防止内部字段外显.
                string optype = Request.QueryString["op"];
                if (optype == null)
                {
                    btn_Update.Text = "确认添加";
                    btn_Update.Visible = true;
                }
                else if (optype == "add")
                {
                    tx_<%%# e.getfirfieldName() #%%> .Enabled = false;
                    btn_Update.Visible = true;
                    btn_Update.Text = "确认添加";
                    // <%%# [Fields[>1]={ex_<%#= t.ColumnName #%>.Text = }] #%%> "";
					
                }
                else if (optype == "update")
                {
                    <%%# e.ClassName #%%> _<%%# e.ClassName #%%> = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == <%%# e.getfirfieldName() #%%>).First<<%%# e.ClassName #%%>>();
					if (_<%%# e.ClassName #%%> != null)
                    {
                        tx_<%%# e.getfirfieldName() #%%>.Text = _<%%# e.ClassName #%%>.<%%# e.getfirfieldName().ToParscal() #%%>.ToString();
                        tx_<%%# e.getfirfieldName() #%%>.Enabled = false;
						<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = _<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%>.ToString();
						}] #%%>
						
                        btn_Update.Visible = true;
                        btn_Update.Text = "确认修改";
                    }
                    else
                    {
                        JSController.Alert("can't find <%%# e.ClassName #%%>:" + <%%# e.getfirfieldName() #%%>);
                    }
                }
                else if (optype=="show")
                {
                    <%%# e.ClassName #%%> _<%%# e.ClassName #%%> = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == <%%# e.getfirfieldName() #%%>).First<<%%# e.ClassName #%%>>();
                    if (_<%%# e.ClassName #%%> != null)
                    {
                        tx_<%%# e.getfirfieldName() #%%>.Text = _<%%# e.ClassName #%%>.<%%# e.getfirfieldName().ToParscal() #%%>.ToString();
                        tx_<%%# e.getfirfieldName() #%%>.Enabled = false;
						<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = _<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%>.ToString();
						}] #%%>
						
						<%%# [Fields[x]={tx_<%#= t.ColumnName #%>.Enabled = }] #%%> false;
                    }
                    else
                    {
                        JSController.Alert("can't find <%%# e.ClassName #%%>:" + <%%# e.getfirfieldName() #%%>);
                    }
                }
			}
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string <%%# e.getfirfieldName() #%%> = Request.QueryString["paraid"];
            string optype = Request.QueryString["op"];
            if (optype == null)
            {
                JSController.Alert("没内容，你可以关闭当前窗口了。");
            }
            else if (optype == "add")
            {
                tx_<%%# e.getfirfieldName() #%%>.Enabled = false;
				if(!<%%# e.ClassName #%%>.E.Exists(<%%# e.ClassName #%%>.<%%# e.getsecfieldname() #%%>))
                {
                    <%%# e.ClassName #%%> _<%%# e.ClassName #%%> = new <%%# e.ClassName #%%>();
					
					<%%# [Fields[>1]={_<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%> = tx_<%#= t.ColumnName #%>.Text.To<%#= t.TypeName.ToParscal() #%>();
					}] #%%>

                    Int64 r_id = _<%%# e.ClassName #%%>.Insert_RETURN_64ID();
					
					<%%# if(e.needfpy()){
						e.calltemp_fpy_insert()
					}else{
					} #%%>
                    JSController.Alert(true ? "添加成功!" : "添加失败");
					<%%# [Fields[>1]={<%#= t.calltemp_AddCLEAR() #%>}] #%%> "";
                }
                else
                {
                    JSController.Alert("已有 <%%# e.getsecfieldname() #%%> 为:" + tx_<%%# e.getsecfieldname() #%%>.Text + " 的 <%%# e.ClassName #%%>. 请修改.");
                }
            }
            else if (optype == "update")
            {
                //<%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getsecfieldname().ToParscal() #%%>()
                // 假设可以修改<%%# e.getfirfieldName() #%%>，这里做判断是有已经有相同<%%# e.getsecfieldname() #%%>，如果有
                // <%%# e.getsecfieldname() #%%>和<%%# e.getfirfieldName() #%%>都一直，说名是自己.
                //int simcount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.getfirfieldName().ToParscal() #%%>A<%%# e.getsecfieldname().ToParscal() #%%>Count(<%%# e.getfirfieldName() #%%>, tx_<%%# e.getsecfieldname() #%%>.Text);
				
				
                int simcount = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == <%%# e.getfirfieldName() #%%> & <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == tx_<%%# e.getfirfieldName() #%%>.Text).Count();
                // 库内存有的<%%# e.getsecfieldname() #%%>集合，如果不允许重复，最多只有一条.
                //int namecount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.getsecfieldname().ToParscal() #%%>Count(tx_<%%# e.getsecfieldname() #%%>.Text);
                int namecount = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getsecfieldname() #%%> == tx_<%%# e.getsecfieldname() #%%>.Text).Count();
                if ((namecount > 0 && simcount == 1) || namecount <= 0)
                {
                    <%%# e.ClassName #%%> _<%%# e.ClassName #%%> = new <%%# e.ClassName #%%>();
                    _<%%# e.ClassName #%%>.<%%# e.getfirfieldName().ToParscal() #%%> = <%%# e.getfirfieldName() #%%>.To<%%# e.getfirfield().TypeName.ToParscal() #%%>();
					<%%# [Fields[>1]={_<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%> = tx_<%#= t.ColumnName #%>.Text.To<%#= t.TypeName.ToParscal() #%>();
					}] #%%> 

					
                    int suc = _<%%# e.ClassName #%%>.Update();
                    if (suc > 0)
                    {
						<%%# if(e.needfpy()){
							e.calltemp_fpy_update()
						}else{
						} #%%>

                        //tx_<%%# e.getsecfieldname() #%%>.Enabled = true;
						
						<%%# [Fields[>1]={<%#=  t.calltemp_AddCLEAR() #%>}] #%%> "";
                    }
                    JSController.Alert(suc > 0 ? "修改成功!" : "修改失败");
                }
                else
                {
                    JSController.Alert("已有 <%%# e.getsecfieldname() #%%> 为:" + tx_<%%# e.getsecfieldname() #%%>.Text + " 的 <%%# e.ClassName #%%>. 请修改.");
                }
            }
            else if (optype == "show")
            {
				
                <%%# e.ClassName #%%> _<%%# e.ClassName #%%> = <%%# e.ClassName #%%>.E.Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> == <%%# e.getfirfieldName() #%%>).First<<%%# e.ClassName #%%>>();
                if (_<%%# e.ClassName #%%> != null)
                {
					<%%# [Fields[x]={tx_<%#= t.ColumnName #%>.Enabled = }] #%%> false;
                    tx_<%%# e.getfirfieldName() #%%>.Text = _<%%# e.ClassName #%%>.<%%# e.getfirfieldName().ToParscal() #%%>.ToString();
                    tx_<%%# e.getfirfieldName() #%%>.Enabled = false;
					
					<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = _<%#= e.ClassName #%>.<%#= t.ColumnName.ToParscal() #%>.ToString();
					}] #%%> 
                }
                else
                {
                    JSController.Alert("can't find <%%# e.ClassName #%%>:" + <%%# e.getfirfieldName() #%%>);
                }
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            JSController.Close();
        }
    }
}