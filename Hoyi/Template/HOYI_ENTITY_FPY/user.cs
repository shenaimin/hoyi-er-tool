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
	/// 实体类 <%%# e.ClassName #%%>_fpy 属性说明自动提取数据库字段的描述信息.
	///</summary>
	[Serializable]
	[EntityAttr("<%%# e.ClassName #%%>_fpy", "<%%# e.EntityName #%%>首字母表")]
	public class <%%# e.ClassName #%%>_fpy : Entity
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
			
		public static <%%# e.ClassName #%%>_fpy NEW(){
			return new <%%# e.ClassName #%%>_fpy();
		} 
		<%%#!-- 这里是无参和带参构造方法 #%%>
		public <%%# e.ClassName #%%>_fpy() {
		}
		
		public <%%# e.ClassName #%%>_fpy(<%%# [Fields[Inner,1,Last(1)]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> }] #%%>){
			<%%# [Fields[Fields[Inner,1,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
			}] #%%>
		}	
		
		public <%%# e.ClassName #%%>_fpy(<%%# [Fields[Inner,0,Last(1)]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> , }] #%%><%%# [Fields[Last,1]={ <%#= t.TypeName.tocstype() #%> _<%#= t.ColumnName #%> }] #%%>){
			<%%# [Fields[Fields[Inner,0,Last(0)]={ this.<%#= t.ColumnName.ToParscal() #%> =  _<%#= t.ColumnName #%>;
			}] #%%>
		}	
		
        #region 语法所迫, 初始化命令.

        public static HOYICMD E {
            get{
                return HOYI.E<<%%# e.ClassName #%%>_fpy>();
            }
        }

        #endregion 语法所迫, 初始化命令.
	}
}