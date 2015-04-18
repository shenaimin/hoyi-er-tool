package <%%# modelInfo.NameSpace #%%>;

public class <%%# this.EntityName #%%> {

	<!-- 这里生成所有字段 -->
<%%# [Fields[x]={	private <%#= this.TypeName.tojavapackclass() #%> <%#= this.ColumnName #%>;  
}] #%%>   

	<!-- 这里是无参和带参构造方法 -->
	public <%%# this.EntityName #%%>() {
		super();
	}
	
	
	public <%%# this.EntityName #%%>(	<%%# [Fields[Inner,0,Last(1)]={<%#= this.TypeName.tojavapackclass() #%> <%#= this.ColumnName #%>,	}] #%%>
	<%%# [Fields[Last,1]={    <%#= this.TypeName.tojavapackclass() #%> <%#= this.ColumnName #%>}] #%%>) {
		super();
		
		<%%# [Fields[x]={this.<%#= this.ColumnName #%> = <%#= this.ColumnName #%>;
		}] #%%>
	}
	
	<!-- 这里生成字段的get, set方法. -->
<%%# [Fields[x]={	private <%#= this.TypeName.tojavapackclass() #%> get<%#= this.ColumnName #%>(){
		return <%#= if(this.ColumnName == "userid"){
						"AAA"
					}else{
						this.ColumnName
					} #%>;
	}
	
	private void set<%#= this.ColumnName #%>(<%#= this.TypeName.tojavapackclass() #%> <%#= this.ColumnName #%>){
		this.<%#= this.ColumnName #%> = <%#= this.ColumnName #%>;
	}		
}] #%%>   
	
	
}
