package <%%# a.NameSpace #%%>;

import hoyi.DB.comment.DbAttrANNO;
import hoyi.DB.comment.EntityAttrANNO;
import hoyi.DB.comment.datatype;
import hoyi.DB.ents.Entity;
import hoyi.DB.model.AttField;


/**
*  实体类 <%%# e.ClassName #%%> 属性说明自动提取数据库字段的描述信息.
*/
@EntityAttrANNO(tablename="<%%# e.ClassName #%%>", comment="<%%# e.EntityName #%%>")
public class <%%# e.ClassName #%%> extends Entity{
	//#region 静态字段
	<%%# [Fields[x]={/// <summary>
	/// <%#= t.Comment #%>
	/// </summary>
	public static AttField <%#= t.ColumnName.ToCamel() #%> = new AttField("<%#= t.ColumnName #%>");		
	}] #%%>   
	//#endregion 静态字段
	
	
	//#region 字段
	<%%# [Fields[x]={/// <summary>
	/// <%#= t.Comment #%>
	/// </summary>	
	<%#= t.dbjavaattr() #%>
	public <%#= t.TypeName.tojavapackclass() #%> <%#= t.ColumnName.ToParscal() #%> ;		

	}] #%%> 
	
	
	<%%# [Fields[x]={/// <summary>
	/// <%#= t.Comment #%>
	/// </summary>	
	
	public <%#= t.TypeName.tojavapackclass() #%> get<%#= t.ColumnName.ToParscal() #%>(){
		return this.<%#= t.ColumnName.ToParscal() #%>;
	}
	
	public void set<%#= t.ColumnName.ToParscal() #%>(<%#= t.TypeName.tojavapackclass() #%> _<%#= t.ColumnName.ToCamel() #%>)
	{
		this.<%#= t.ColumnName.ToParscal() #%> = _<%#= t.ColumnName.ToCamel() #%>;
		
	}
	}] #%%> 
	//#endregion 字段
	
				
	public static <%%# e.ClassName #%%> NEW(){
		return new <%%# e.ClassName #%%>();
	} 
	<%%#!-- 这里是无参和带参构造方法 #%%>
	public <%%# e.ClassName #%%>() {
	}
	
	public <%%# e.ClassName #%%>(<%%# [Fields[Inner,1,Last(1)]={ <%#= t.TypeName.tojavapackclass() #%> _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ <%#= t.TypeName.tojavapackclass() #%> _<%#= t.ColumnName #%> }] #%%>){
		<%%# [Fields[Fields[Inner,1,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
		}] #%%>
	}	
	
	public <%%# e.ClassName #%%>(<%%# [Fields[Inner,0,Last(1)]={ <%#= t.TypeName.tojavapackclass() #%> _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ <%#= t.TypeName.tojavapackclass() #%> _<%#= t.ColumnName #%> }] #%%>){
		<%%# [Fields[Fields[Inner,0,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
		}] #%%>
	}	
	
	//#region 语法所迫, 初始化命令.

	//public static HOYICMD E {
	//	get{
	//		return HOYI.E<<%%# e.ClassName #%%>>();
	//	}
	//}

	//#endregion 语法所迫, 初始化命令.
}
