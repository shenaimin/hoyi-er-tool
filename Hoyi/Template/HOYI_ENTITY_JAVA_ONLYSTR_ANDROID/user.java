package <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.model;

import org.hoyi.DB.comment.DbAttrANNO;
import org.hoyi.DB.comment.EntityAttrANNO;
import org.hoyi.DB.comment.datatype;
import org.hoyi.DB.ctrl.HOYI;
import org.hoyi.DB.ctrl.HOYICMD;
import org.hoyi.DB.ents.Entity;
import org.hoyi.DB.model.AttField;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

/**
*  实体类 <%%# e.ClassName #%%> 属性说明自动提取数据库字段的描述信息.
*/
@EntityAttrANNO(tablename="<%%# e.ClassName #%%>", comment="<%%# e.EntityName #%%>")
public class <%%# e.ClassName #%%> extends Entity{
	
	private static boolean TableCreated = false;
	
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
	public String <%#= t.ColumnName.ToParscal() #%> ;		

	}] #%%> 
	
	
	<%%# [Fields[x]={/// <summary>
	/// <%#= t.Comment #%>
	/// </summary>	
	
	public String get<%#= t.ColumnName.ToParscal() #%>(){
		if(this.<%#= t.ColumnName.ToParscal() #%> == null)
			return "";
		return this.<%#= t.ColumnName.ToParscal() #%>;
	}
	
	public void set<%#= t.ColumnName.ToParscal() #%>(String _<%#= t.ColumnName.ToCamel() #%>)
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
	
	public <%%# e.ClassName #%%>(<%%# [Fields[Inner,1,Last(1)]={ String _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ String _<%#= t.ColumnName #%> }] #%%>){
		<%%# [Fields[Fields[Inner,1,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
		}] #%%>
	}	
	
	public <%%# e.ClassName #%%>(<%%# [Fields[Inner,0,Last(1)]={ String _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ String _<%#= t.ColumnName #%> }] #%%>){
		<%%# [Fields[Fields[Inner,0,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
		}] #%%>
	}	
	
	
	public  static boolean CREATETABLE(){
		
		if(!TableCreated){
			String cmd =
				"CREATE TABLE IF NOT EXISTS `<%%# e.ClassName #%%>` (\n" +
				<%%# [Fields[Fields[Inner,0,0]={ "     `<%#= t.ColumnName #%>` INTEGER PRIMARY KEY AUTOINCREMENT   ,\n" +
				}] #%%>
				<%%# [Fields[Fields[Inner,1,Last(1)]={ "     `<%#= t.ColumnName #%>` varchar   ,\n" +
				}] #%%>
				<%%# [Fields[Fields[Last,1]={ "     `<%#= t.ColumnName #%>` varchar  \n" +
				}] #%%>
						") \n" ;
		 
			TableCreated = <%%# e.ClassName #%%>.STA_ExecuteNounery(cmd) == 1;
			return  TableCreated;
		}else{
			return true;
		}
	}
	
	public  static <%%# e.ClassName #%%> TransJSONOBJ(JSONObject <%%# e.ClassName #%%>obj){
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = new <%%# e.ClassName #%%>();
		<%%# [Fields[Fields[Inner,0,Last(0)]={ _<%#= e.ClassName #%>.set<%#= t.ColumnName.ToParscal() #%>(<%#= e.ClassName #%>obj.optString("<%#= t.ColumnName #%>"));
				}] #%%>
		
		return  _<%%# e.ClassName #%%>;
	}
	
	
	public static List<<%%# e.ClassName #%%>> TransJsonList(JSONArray <%%# e.ClassName #%%>array){
		List<<%%# e.ClassName #%%>> <%%# e.ClassName #%%>s = new ArrayList<>();
		<%%# e.ClassName #%%> tmp<%%# e.ClassName #%%>;
		for (int i = 0; i < <%%# e.ClassName #%%>array.length(); i ++) {
			try {
				tmp<%%# e.ClassName #%%> = <%%# e.ClassName #%%>.TransJSONOBJ(<%%# e.ClassName #%%>array.getJSONObject(i));
				<%%# e.ClassName #%%>s.add(tmp<%%# e.ClassName #%%>);
			} catch (JSONException e) {
				e.printStackTrace();
				return  null;
			}
		}
		return <%%# e.ClassName #%%>s;
	}


	public <%%# e.ClassName #%%>  TRANSSIMPLEJSON(JSONObject <%%# e.ClassName #%%>obj){
		return <%%# e.ClassName #%%>.TransJSONOBJ(<%%# e.ClassName #%%>obj);
	}
	
	//#region 语法所迫, 初始化命令.
	
	public static HOYICMD E() {
		// 这里可以执行创建表语句.
		CREATETABLE();
		return HOYI.E(<%%# e.ClassName #%%>.class);
	}
	
	@Override
	public String getFirstfield() {
		// TODO Auto-generated method stub
		return "<%%# t.getfirfieldname() #%%>";
	}
	
	@Override
	public String getSecondfield() {
		// TODO Auto-generated method stub
		return "<%%# t.getsecfieldname() #%%>";
	}

	//#endregion 语法所迫, 初始化命令.
}
