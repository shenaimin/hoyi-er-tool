
/**
    <%%# m.ModuleName #%%>.
*/
var menus<%%# m.Caption #%%> = [{
    "name": "<%%# m.ModuleName #%%>", icon: "glyphicon glyphicon-cog", "childmenu": [

	<%%# [Tables[>0]={
		{ "id": "<%#= t.EntityName #%>", "url": "exmds/<%#= m.Caption #%>/<%#= t.ClassName #%>manage.hoyip" , icon: "glyphicon glyphicon-credit-card" }, }] #%%>
    ]
}];


