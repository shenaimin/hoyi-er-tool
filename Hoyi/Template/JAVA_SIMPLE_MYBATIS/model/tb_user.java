package <%%# a.NameSpace #%%>.model;

/**
 * <%%# e.EntityName #%%>
 * @author ellen@kuaifish.com
 *
 */
public class <%%# e.ClassName #%%> {

	<%%# [Fields[x]={
	/**
	 * <%#= t.Comment #%>
	 */
	private String <%#= t.ColumnName.ToCamel() #%>;
	}] #%%>   


	<%%# [Fields[x]={
	public String get<%#= t.ColumnName.ToParscal() #%>() {
		return <%#= t.ColumnName.ToCamel() #%>;
	}

	public void set<%#= t.ColumnName.ToParscal() #%>(String <%#= t.ColumnName.ToCamel() #%>) {
		this.<%#= t.ColumnName.ToCamel() #%> = <%#= t.ColumnName.ToCamel() #%>;
	}
	}] #%%>   

}
