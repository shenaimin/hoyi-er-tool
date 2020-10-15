using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace <%%# a.NameSpace #%%>.<%%# m.Caption #%%>.Model
{
	///<summary>
	/// 实体类 <%%# e.ClassName #%%>Info 属性说明自动提取数据库字段的描述信息.
	///</summary>
	[Serializable]
	public class <%%# e.ClassName #%%>Info
	{
		#region <%%# e.ClassName #%%>InfoFields
		
<%%# [Fields[x]={		public static string F_<%#= t.ColumnName #%> = "<%#= t.ColumnName #%>";
}] #%%>   
		#endregion <%%# e.ClassName #%%>InfoFields
		
		#region <%%# e.ClassName #%%>Info
	<%%#!-- 这里生成所有字段 #%%>
<%%# [Fields[x]={		public string <%#= t.ColumnName #%>  { get; set; }
}] #%%> 
		#endregion <%%# e.ClassName #%%>Info  	
		public static <%%# e.ClassName #%%>Info Create(){
			return new <%%# e.ClassName #%%>Info();
		} 
		<%%#!-- 这里是无参和带参构造方法 #%%>
		public <%%# e.ClassName #%%>Info() {
		}
		
		public <%%# e.ClassName #%%>Info(<%%# e.Attributes.anddoustrparamcs() #%%>){
			<%%# e.Attributes.todengyu() #%%>
		}	
	
		/// <summary>
		/// 将DataTable转换成格式List<<%%# e.ClassName #%%>Info>
		/// </summary>
		public static List<<%%# e.ClassName #%%>Info> TransDataTable(DataTable dt)
		{
			List<<%%# e.ClassName #%%>Info> <%%# e.ClassName #%%>s = new List<<%%# e.ClassName #%%>Info>();
			foreach (DataRow dr in dt.Rows)
			{
				<%%# e.ClassName #%%>Info <%%# e.ClassName #%%> = new <%%# e.ClassName #%%>Info();
				
				<%%# [Fields[x]={<%#= e.ClassName #%>.<%#= t.ColumnName #%> = dr["<%#= t.ColumnName #%>"].ToString();
				}] #%%>
				<%%# e.ClassName #%%>s.Add(<%%# e.ClassName #%%>);

			}
			return <%%# e.ClassName #%%>s;
		}

        public string ToJson() 
        {
			return "{<%%# [Fields[Inner,0,Last(1)]={\"<%#= t.ColumnName #%>\":\"" + this.<%#= t.ColumnName #%> + "\", }] #%%><%%# [Fields[Last(1)]={\"<%#= t.ColumnName #%>\":\"" + this.<%#= t.ColumnName #%> + "\" }] #%%>}";
        }

        public static string ToJson(List<<%%# e.ClassName #%%>Info> _<%%# e.ClassName #%%>s)
        {
            string rows = "";
            foreach (<%%# e.ClassName #%%>Info <%%# e.ClassName #%%> in _<%%# e.ClassName #%%>s)
            {
                rows += <%%# e.ClassName #%%>.ToJson() + ",";
            }
            rows = rows.TrimEnd(',');

            string Result = "{\"total\":" + _<%%# e.ClassName #%%>s.Count + ", \"rows\":[" + rows + "]}";
            return Result;
        }
	}
}