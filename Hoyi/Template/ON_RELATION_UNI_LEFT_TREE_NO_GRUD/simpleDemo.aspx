<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="r_lg_pg_<%%# e.ClassName #%%>.aspx.cs" Inherits="CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>.r_lg_pg_<%%# e.ClassName #%%>" %>

<%@ Register Src="~/Paging/ctPaging.ascx" TagPrefix="uc1" TagName="ctPaging" %>
<%@ Import Namespace="<%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="~/CSS/public/table/table.css" rel="stylesheet" />
    <link href="~/CSS/public/validate/validate.css" rel="stylesheet" />
    <link href="~/CSS/public/structs/structs.css" rel="stylesheet" />
    
    <script type="text/javascript" src='<%=ResolveClientUrl("~/JS/public/table.js") %>' ></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/JS/libs/jquery-1.11.1.min.js") %>' ></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/JS/libs/jquery-validate/jquery.validate.min.js") %>'  ></script>
	
    <script type="text/javascript">
	
<%%# [Fields[Equals(1)]={
        function NeedValidate() {
            $("#form1").validate({
                rules: {
                    tx_<%#= t.ColumnName #%>: { required: true }
                },
                messages: {
                    tx_<%#= t.ColumnName #%>: { required: "*必须填写" }
                }
            });
        }
        //取消表单验证
        function NoValidate() {
            $("#tx_<%#= t.ColumnName #%>").rules("remove");//如果有多个 依次取消            
        }
}] #%%>

    </script>

    <script type="text/javascript" src='<%=ResolveClientUrl("~/JS/public/validate_pub.js") %>'></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>	
			<div id="leftpanel">
				<div style="width: 100%; height: 500px;"  class="tree_contrainer">
					<table id="lefttable"  class="left_table">
						<caption class="uni_caption" style="display:none;"><%%# e.unself_out_tb().EntityName  #%%></caption>
						<tbody class="left_tbody">
							<asp:TreeView CssClass="left_tree" runat="server" ID="tree<%%# e.rela_uni_out_tb_name() #%%>" Font-Size="12px" OnSelectedNodeChanged="tree<%%# e.rela_uni_out_tb_name() #%%>_SelectedNodeChanged">
							</asp:TreeView>
						</tbody>
					</table>
				</div>
			</div>
			<div id="rightpanel">
				<div style="margin: 23px 0 0 5px; ">
                    <asp:Label runat="server" ID="lb_checked<%%# t.rela_uni_out_tb_name()  #%%>Name" CssClass="uni_caption_name"></asp:Label>    &nbsp;的 <%%# e.EntityName  #%%>
                </div>
                <div style="display:none;">
                    <asp:Label runat="server" ID="lb_checked<%%# t.rela_uni_out_tb_name()  #%%>"></asp:Label></div>
                <br />
				
				<div id="paneladd" style="text-align:left; display:none;">
				<%%#!-- 外键就无关乎增加修改的关联字段了. 这里放一个做备用. t.calltemp_Panel_ADD_TX_UNI() #%%>
			
	<%%# [Fields[>1]={	
		<%#= t.Comment #%>: <asp:TextBox runat="server" ID="tx_<%#= t.ColumnName #%>"></asp:TextBox>
	}] #%%>
				</div>
				<div id="panelfind" style="text-align:left; margin-top:20px;">
				
                    <asp:Button runat="server" ID="btnSearchALL" Text="全部<%%# e.rela_uni_out_tb().EntityName #%%>查找(L)" OnClick="btnSearch_Click" height="37px" width="106px" AccessKey="l" />
					<asp:Button runat="server" ID="btnSearchCurrent" Text="当前<%%# e.rela_uni_out_tb().EntityName #%%>查找(L)" OnClick="btnSearchCurrent_Click" height="37px" width="106px" AccessKey="l" />
					
				</div>
				<div id="panelshow">
                    <div style="margin:19px 0 0 6px;"></div>
					<table id="mytable" style="float:left; font-size:12px;">
						<caption> <%%# e.ClassName #%%> information.</caption>
						<tbody>
							<asp:Repeater runat="server" ID="rep1" >
								<HeaderTemplate>
									<tr>
										<th></th>
										
				<%%#!-- 外键就无关乎增加修改的关联字段了. 这里放一个做备用. t.calltemp_Repeat_HR_UNI() #%%>
										<%%# [Fields[Inner,0,Last(1)]={
										<th> <asp:LinkButton runat="server" CommandArgument="<%# <%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%> %>" OnClick="btnOrder_Click" ><%# OrderTag("<%#= t.Comment #%>", <%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></asp:LinkButton></th>
											}] #%%>
									<%%# [Fields[Last(1)]={<th> <asp:LinkButton runat="server" CommandArgument="<%# <%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%> %>" OnClick="btnOrder_Click" ><%# OrderTag("<%#= t.Comment #%>",<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></asp:LinkButton></th>
									}] #%%>
									</tr>
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
                                        <th>
                                            <asp:CheckBox ID="chk_RELATION" runat="server" AutoPostBack="true"  CommandArgument="<%# Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>) %>" Checked="<%# isRelationed(Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>).ToString())  %>"  OnCheckedChanged="chk_RELATION_CheckedChanged"  />
                                         </th>
										<%%# [Fields[Equals(0)]={<th class="specalt" ><%# Eval(<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></th> 		}] #%%>
										<%%# [Fields[Equals(1)]={<td>
											<a target="_blank" href="leftsw_<%#= e.ClassName #%>.aspx?op=show&paraid=<%# Eval(<%#= e.ClassName #%>Info.F_<%#= e.getfirfieldName() #%>)%>"><%# Eval(<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></a>
										</td>		}] #%%>
										
				<%%#!-- 外键就无关乎增加修改的关联字段了. 这里放一个做备用. t.calltemp_Repeat_IT_UNI() #%%>
										<%%# [Fields[>2]={
									<td><%# Eval(<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></td>
										}] #%%> 
									</tr>
								</ItemTemplate>
							</asp:Repeater>
							<tr>
								<td colspan="<%%# e.addonecols() #%%>">
									<uc1:ctPaging runat="server" ID="ctPaging2"  />
								</td>
							</tr>
						</tbody>
					</table>
				</div>
				<br />
				<div></div>
			</div>
        </div>
    </form>
</body>
</html>
