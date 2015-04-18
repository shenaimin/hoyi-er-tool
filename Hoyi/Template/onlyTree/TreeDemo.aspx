<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgtree_<%%# e.ClassName #%%>.aspx.cs" Inherits="CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%>.pgtree_<%%# e.ClassName #%%>" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/CSS/public/structs/treev.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView runat="server" ID="tree<%%# e.ClassName #%%>" OnSelectedNodeChanged="tree<%%# e.ClassName #%%>_SelectedNodeChanged">
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
