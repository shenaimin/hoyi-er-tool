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
							<asp:TreeView CssClass="left_tree" runat="server" ID="tree<%%# e.rela_uni_out_tb_name() #%%>" font-size="12px" OnSelectedNodeChanged="tree<%%# e.rela_uni_out_tb_name() #%%>_SelectedNodeChanged">
							</asp:TreeView>
						</tbody>
					</table>
				</div>
			</div>
			<div id="rightpanel">
			<%%# if(e.contain_uni()){
						t.calltemp_right_panel_title_uni()
					}else{
						t.calltemp_right_panel_title()
					} #%%>	
				
				<div id="paneladd" style="text-align:left">
				<%%#!-- 外键就无关乎增加修改的关联字段了. 这里放一个做备用. t.calltemp_Panel_ADD_TX_UNI() #%%>
			
	<%%# [Fields[>1]={	
		<%#= if(t.isunikey()){
			t.calltemp_Panel_ADD_TX()
		}else{
			t.calltemp_Panel_ADD_TX()
		} #%>	
	}] #%%>
				</div>
				<div id="panelfind" style="text-align:left; margin-top:20px;">
					<asp:Button ID="btnUpdated" runat="server" Height="37px" Text="确认修改<%%# e.EntityName #%%>(Q)"  Visible="False" Width="106px" OnClick="btnUpdated_Click" AccessKey="q" />
	&nbsp;<asp:Button ID="btnCancelUpdate" runat="server" Height="37px" Text="取消修改<%%# e.EntityName #%%>(C)"  Visible="False" Width="106px" OnClick="btnCancelUpdate_Click" AccessKey="c" />
					&nbsp;
					<asp:Button runat="server" ID="btnAdd" Text="新增<%%# e.EntityName #%%>(A)" OnClick="btnAdd_Click" height="37px" width="106px" AccessKey="a" />
					&nbsp;
					<asp:Button runat="server" ID="btnAddRelation" Text="关联<%%# e.EntityName #%%>" height="37px" width="106px" OnClick="btnAddRelation_Click" />
					&nbsp;
					<asp:Button runat="server" ID="btnSearch" Text="查找<%%# e.EntityName #%%>(L)" OnClick="btnSearch_Click" height="37px" width="106px" AccessKey="l" />
					&nbsp;					
					<asp:Button runat="server" ID="btnReload" Text="所有<%%# e.EntityName #%%>(R)" height="37px" width="106px"  OnClick="btnReload_Click" AccessKey="r"/>
				</div>
				<div id="panelshow">
                    <div style="margin:19px 0 0 6px;"></div>
					<table id="mytable" style="float:left; font-size:12px;">
						<caption> <%%# e.ClassName #%%> information.</caption>
						<tbody>
							<asp:Repeater runat="server" ID="rep1" OnItemCommand="rep1_ItemCommand">
								<HeaderTemplate>
									<tr>
										<th></th>
										
				<%%#!-- 外键就无关乎增加修改的关联字段了. 这里放一个做备用. t.calltemp_Repeat_HR_UNI() #%%>
										<%%# [Fields[Inner,0,Last(1)]={
											<%#= if(t.isunikey()){
												t.calltemp_Repeat_HR()
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
                                        <th>
                                            <asp:CheckBox ID="chk_RELATION" runat="server" AutoPostBack="true"  CommandArgument="<%# Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>) %>" Checked="<%# isRelationed(Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>).ToString())  %>"  OnCheckedChanged="chk_RELATION_CheckedChanged"  />
                                         </th>
										<%%# [Fields[Equals(0)]={<th class="specalt" ><%# Eval(<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></th> 		}] #%%>
										<%%# [Fields[Equals(1)]={<td>
											<a target="_blank" href="leftsw_<%#= e.ClassName #%>.aspx?op=show&paraid=<%# Eval(<%#= e.ClassName #%>Info.F_<%#= e.getfirfieldName() #%>)%>"><%# Eval(<%#= e.ClassName #%>Info.F_<%#= t.ColumnName #%>) %></a>
										</td>		}] #%%>
										
				<%%#!-- 外键就无关乎增加修改的关联字段了. 这里放一个做备用. t.calltemp_Repeat_IT_UNI() #%%>
										<%%# [Fields[>2]={
										<%#= if(t.isunikey()){
											t.calltemp_Repeat_IT()
										}else{
											t.calltemp_Repeat_IT()
										} #%>
										}] #%%> <td>
											<asp:LinkButton runat="server" Text="修改" CommandName="Update" CommandArgument="<%# Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>) %>"></asp:LinkButton></td>
										<td>
											<asp:LinkButton runat="server" Text="删除" CommandName="Delete" CommandArgument="<%# Eval(<%%# e.ClassName #%%>Info.F_<%%# e.getfirfieldName() #%%>) %>" OnClientClick="return confirm('你确定要删除吗?')"></asp:LinkButton></td>
									</tr>
								</ItemTemplate>
							</asp:Repeater>
							<tr>
								<td colspan="<%%# e.add3cols() #%%>">
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
