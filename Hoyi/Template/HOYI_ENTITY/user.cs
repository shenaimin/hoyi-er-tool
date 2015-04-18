using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Infrastructure.Database.Att;
using Infrastructure.Database.ctrl;
using Infrastructure.Database.ents;
using Infrastructure.Database.Model;

namespace HOYIENTITY.<%%# m.Caption #%%>
{
	///<summary>
	/// 实体类 <%%# e.ClassName #%%> 属性说明自动提取数据库字段的描述信息.
	///</summary>
	[Serializable]
	[EntityAttr("<%%# e.ClassName #%%>", "<%%# e.EntityName #%%>")]
	public class <%%# e.ClassName #%%> : Entity
	{
		#region 静态字段
		<%%# [Fields[x]={/// <summary>
		/// <%#= t.Comment #%>
		/// </summary>
        public static AttField <%#= t.ColumnName.ToCamel() #%> = new AttField("<%#= t.ColumnName #%>");		
		}] #%%>   
		#endregion 静态字段
		
		#region 字段
		<%%# [Fields[x]={/// <summary>
		/// <%#= t.Comment #%>
		/// </summary>	
        <%#= t.dbattr() #%>
        public <%#= t.TypeName.tocstype() #%> <%#= t.ColumnName.ToParscal() #%> { get; set; }		
		}] #%%> 
		#endregion 字段
			
		public static <%%# e.ClassName #%%> NEW(){
			return new <%%# e.ClassName #%%>();
		} 
		<%%#!-- 这里是无参和带参构造方法 #%%>
		public <%%# e.ClassName #%%>() {
		}
		
		public <%%# e.ClassName #%%>(<%%# [Fields[Inner,1,Last(1)]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> }] #%%>){
			<%%# [Fields[Fields[Inner,1,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
			}] #%%>
		}	
		
		public <%%# e.ClassName #%%>(<%%# [Fields[Inner,0,Last(1)]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> }] #%%>){
			<%%# [Fields[Fields[Inner,0,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
			}] #%%>
		}	
		
        #region 语法所迫, 初始化命令.

        public static HOYICMD E {
            get{
                return HOYI.E<<%%# e.ClassName #%%>>();
            }
        }

        #endregion 语法所迫, 初始化命令.
	}
}