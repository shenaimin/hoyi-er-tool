<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pg_<%%# e.ClassName #%%>.aspx.cs" Inherits="CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>.pg_<%%# e.ClassName #%%>" %>

<%@ Register Src="~/Paging/ctPaging.ascx" TagPrefix="uc1" TagName="ctPaging" %>
<%@ Import Namespace="<%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="~/CSS/public/table/table.css" rel="stylesheet" />
    <link href="~/CSS/public/validate/validate.css" rel="stylesheet" />
    
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

<%%# [Fields[X]={	<%#= if(t.isunikey()){
t.calltemp_ConstraintJSDEF()
				}else{
					
				} #%>}] #%%>
    </script>

    <script type="text/javascript" src='<%=ResolveClientUrl("~/JS/public/validate_pub.js") %>'></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<div style="margin-top:23px; font-weight: bold;"><%%# e.EntityName #%%></div>
            <br />
            <div id="paneladd" style="text-align:left">
<%%# [Fields[>1]={		  		
<%#= if(t.isunikey()){
			t.calltemp_Panel_ADD_Constraint()
		}else{
			t.calltemp_Panel_ADD_TX()
		} #%>
}] #%%>
            </div>
            <div id="panelfind" style="text-align:left; margin-top:20px;">
                
                <asp:Button ID="btnUpdated" runat="server" Height="37px" Text="确认修改(Q)"  Visible="False" Width="106px" OnClick="btnUpdated_Click" AccessKey="q" />
&nbsp;<asp:Button ID="btnCancelUpdate" runat="server" Height="37px" Text="取消修改(C)"  Visible="False" Width="106px" OnClick="btnCancelUpdate_Click" AccessKey="c" />
                &nbsp;
                <asp:Button runat="server" ID="btnAdd" Text="新增(A)" OnClick="btnAdd_Click" height="37px" width="106px" AccessKey="a" />
                 &nbsp;
                
                <asp:Button runat="server" ID="btnReload" Text="刷新(R)" height="37px" width="106px"  OnClick="btnReload_Click" AccessKey="r"/>

                &nbsp;

                <asp:Button runat="server" ID="btnSearch" Text="查找(L)" OnClick="btnSearch_Click" height="37px" width="106px" AccessKey="l" />

            </div>
            <div id="panelshow">
                <table id="mytable" style="float:left;font-size:12px;">
                    <caption><%%# e.ClassName #%%> information.</caption>
                    <tbody>
                        <asp:Repeater runat="server" ID="rep1" OnItemCommand="rep1_ItemCommand">
                            <HeaderTemplate>
                                <tr>
								<%%# [Fields[Inner,0,Last(1)]={
								<%#= if(t.isunikey()){
									t.calltemp_Repeat_HR_UNI()
								}else{
									t.calltemp_Repeat_HR()
								} #%>
								}] #%%>
								<%%# [Fields[Last(1)]={<th> <asp:LinkButton runat="server" CommandArgument="<%# <%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%> %>" OnClick="btnOrder_Click" ><%# OrderTag("<%#= t.Comment #%>",<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></asp:LinkButton></th>
								}] #%%>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
									<%%# [Fields[Equals(0)]={<th class="specalt"><%# Eval(<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></th> 		}] #%%>
									<%%# [Fields[Equals(1)]={<td>
                                        <a target="_blank" href="sw_<%#= e.ClassName #%>.aspx?op=show&paraid=<%# Eval(<%#= e.ClassName #%>Info.F_<%#= e.getfirfieldName() #%>)%>"><%# Eval(<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></a>
                                    </td>		}] #%%>
									<%%# [Fields[>2]={
										<%#= if(t.isunikey()){
											t.calltemp_Repeat_IT_UNI()
										}else{
											t.calltemp_Repeat_IT()
										} #%>
									}] #%%><td>
                                        <asp:LinkButton runat="server" Text="修改" CommandName="Update" CommandArgument="<%# Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>) %>"></asp:LinkButton></td>
                                    <td>
                                        <asp:LinkButton runat="server" Text="删除" CommandName="Delete" CommandArgument="<%# Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>) %>" OnClientClick="return confirm('你确定要删除吗?')"></asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="<%%# e.gettablecols() #%%>">
                                <uc1:ctPaging runat="server" ID="ctPaging2"  />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <br />
            <div></div>
        </div>
    </form>
</body>
</html>
