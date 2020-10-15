<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lstrsw_<%%# e.ClassName #%%>.aspx.cs" Inherits="CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>.lstrsw_<%%# e.ClassName #%%>" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="~/CSS/public/table/showtable.css" rel="stylesheet" />
    <script src='<%=ResolveClientUrl("~/JS/libs/jquery-1.11.1.min.js") %>'></script>
    <script src='<%=ResolveClientUrl("~/JS/libs/jquery-validate/jquery.validate.min.js") %>'></script>
    <link href="~/CSS/public/validate/validate.css" rel="stylesheet" />
    <script type="text/javascript">
        function NeedValidate() {
            $("#form1").validate({
                rules: {
                    tx_<%%# e.getsecfieldname() #%%>: { required: true }
                },
                messages: {
                    tx_<%%# e.getsecfieldname() #%%>: { required: "*必须填写" }
                }
            });
        }
        //取消表单验证
        function NoValidate() {
            $("#tx_<%%# e.getsecfieldname() #%%>").rules("remove");//如果有多个 依次取消            
        }
		
<%%# [Fields[X]={	<%#= if(t.isunikey()){
t.calltemp_ConstraintJSDEF()
				}else{
					
				} #%>}] #%%>
    </script>
    <script src='<%=ResolveClientUrl("~/JS/public/validate_pub.js") %>'></script>
</head>
<body style="background-color:#e6eae9;">
    <div>
        <!-- 这里只做展示，不做操作 -->
        <form runat="server" id="form1">
        <table class="showTable">
            <caption>
                <%%# e.EntityName #%%>
            </caption>
            <tbody>
			
			
				<%%# [Fields[x]={
				<%#= if(t.isunikey()){
t.calltemp_SW_FIELDS_UI()
				}else{
t.calltemp_SW_FIELDS()				
				} #%>}] #%%>
                <tr>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btn_Update" OnClick="btn_Update_Click" Text="确认更新" OnClientClick="<script type='text/javascript'>return confirm('确认提交？');</script>" height="34px" width="110px" Visible="false" />
                        <asp:Button runat="server" ID="btn_Cancel" OnClick="btn_Cancel_Click" Text="关闭" Height="34px" Width="110px"  />
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
    </div>
</body>
</html>
