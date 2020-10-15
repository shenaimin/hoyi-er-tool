using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Expert;
using <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model;
using Infrastructure.Baser;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>
{
    public partial class ltrsw_<%%# e.ClassName #%%> : System.Web.UI.Page
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
					
					<%%# [Fields[>1]={		  		
					<%#= if(t.isunikey()){
								t.calltemp_Show_Enable()
							}else{
							} #%>
					}] #%%>
                }
                else if (optype == "update")
                {
                    <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = <%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);
                    if (<%%# e.ClassName #%%> != null)
                    {
                        tx_<%%# e.getfirfieldName() #%%>.Text = <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>;
                        tx_<%%# e.getfirfieldName() #%%>.Enabled = false;
						<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = <%#= e.ClassName #%>.<%#= t.ColumnName #%>;
						}] #%%>
						
						<%%# [Fields[>1]={		  		
						<%#= if(t.isunikey()){
									t.calltemp_Update_Change()
								}else{
								} #%>
						}] #%%>

						<%%# [Fields[>1]={		  		
						<%#= if(t.isunikey()){
									t.calltemp_Show_Enable()
								}else{
								} #%>
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
                    <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = <%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);
                    if (<%%# e.ClassName #%%> != null)
                    {
                        tx_<%%# e.getfirfieldName() #%%>.Text = <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>;
                        tx_<%%# e.getfirfieldName() #%%>.Enabled = false;
						<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = <%#= e.ClassName #%>.<%#= t.ColumnName #%>;
						}] #%%>
						
						<%%# [Fields[>1]={		  		
						<%#= if(t.isunikey()){
									t.calltemp_Update_Change()
								}else{
								} #%>
						}] #%%>
						<%%# [Fields[>1]={		  		
						<%#= if(t.isunikey()){
									t.calltemp_Show_Disable()
								}else{
								} #%>
						}] #%%>
						<%%# [Fields[x]={tx_<%#= t.ColumnName #%>.Enabled = }] #%%> false;
                    }
                    else
                    {
                        JSController.Alert("can't find <%%# e.ClassName #%%>:" + <%%# e.getfirfieldName() #%%>);
                    }
                }
				
		<%%# [Fields[X]={	<%#= if(t.isunikey()){
									t.calltemp_ConstraintDEF()
								}else{
									
								} #%>}] #%%>
			}

		<%%# [Fields[X]={	<%#= if(t.isunikey()){
									t.calltemp_ConstraintJSCONS()
								}else{
									
								} #%>}] #%%>
        }
		<%%# [Fields[X]={	<%#= if(t.isunikey()){
									t.calltemp_ConstraintCS()
								}else{
									
								} #%>}] #%%>

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
                if (!<%%# e.ClassName #%%>Factory.Create().ExistsBy<%%# e.getsecfieldname().ToParscal() #%%>(tx_<%%# e.getsecfieldname() #%%>.Text))
                {
                    <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = new <%%# e.ClassName #%%>Info();
					
					<%%# [Fields[>1]={<%#= e.ClassName #%>.<%#= t.ColumnName #%> = tx_<%#= t.ColumnName #%>.Text ;
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
                int simcount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.getfirfieldName().ToParscal() #%%>A<%%# e.getsecfieldname().ToParscal() #%%>Count(<%%# e.getfirfieldName() #%%>, tx_<%%# e.getsecfieldname() #%%>.Text);
                // 库内存有的<%%# e.getsecfieldname() #%%>集合，如果不允许重复，最多只有一条.
                int namecount = <%%# e.ClassName #%%>Factory.Create().GetBy<%%# e.getsecfieldname().ToParscal() #%%>Count(tx_<%%# e.getsecfieldname() #%%>.Text);
                if ((namecount > 0 && simcount == 1) || namecount <= 0)
                {
                    <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = new <%%# e.ClassName #%%>Info();
                    <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%> = <%%# e.getfirfieldName() #%%>;
					<%%# [Fields[>1]={<%#= e.ClassName #%>.<%#= t.ColumnName #%> = tx_<%#= t.ColumnName #%>.Text;
					}] #%%> 

                    bool suc = <%%# e.ClassName #%%>Factory.Create().UpdateBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.ClassName #%%>);
                    if (suc)
                    {
						<%%# if(e.needfpy()){
							e.calltemp_fpy_update()
						}else{
						} #%%>
                        //tx_<%%# e.getsecfieldname() #%%>.Enabled = true;
						
				<%%# [Fields[>1]={ <%#= if(t.isunikey()){
								}else{
									t.calltemp_AddCLEAR()  } #%>}] #%%> "";
                    }
                    JSController.Alert(suc ? "修改成功!" : "修改失败");
                }
                else
                {
                    JSController.Alert("已有 <%%# e.getsecfieldname() #%%> 为:" + tx_<%%# e.getsecfieldname() #%%>.Text + " 的 <%%# e.ClassName #%%>. 请修改.");
                }
            }
            else if (optype == "show")
            {
                <%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = <%%# e.ClassName #%%>Factory.Create().GetSimpleBy<%%# e.getfirfieldName().ToParscal() #%%>(<%%# e.getfirfieldName() #%%>);
                if (<%%# e.ClassName #%%> != null)
                {
					<%%# [Fields[x]={tx_<%#= t.ColumnName #%>.Enabled = }] #%%> false;
                    tx_<%%# e.getfirfieldName() #%%>.Text = <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>;
                    tx_<%%# e.getfirfieldName() #%%>.Enabled = false;
					
					<%%# [Fields[>1]={tx_<%#= t.ColumnName #%>.Text = <%#= e.ClassName #%>.<%#= t.ColumnName #%>;
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