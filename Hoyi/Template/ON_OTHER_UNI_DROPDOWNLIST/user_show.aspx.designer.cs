﻿//------------------------------------------------------------------------------
// <自动生成>
//     此代码由工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。 
// </自动生成>
//------------------------------------------------------------------------------

namespace CTERP.page.mds.<%%# m.Caption #%%>.<%%# e.ClassName #%%> {
    
    
    public partial class sw_<%%# e.ClassName #%%> {
        
        /// <summary>
        /// form1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.HtmlControls.HtmlForm form1;
        
		<%%# [Fields[x]={
        /// <summary>
        /// tx_<%#= t.ColumnName #%> 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox tx_<%#= t.ColumnName #%>;
		}] #%%>
		
		
<%%# [Fields[X]={<%#= if(t.isunikey()){
t.calltemp_ConstraintDESDEF()
						}else{
							
						} #%>}] #%%>
        
        /// <summary>
        /// btn_Update 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button btn_Update;
        
        /// <summary>
        /// btn_Cancel 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.Button btn_Cancel;
    }
}
