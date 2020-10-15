package WebRoot.exmds.<%%# m.Caption #%%>;

import java.util.ArrayList;
import java.util.List;

import org.hoyi.DB.ctrl.FILTER;
import org.hoyi.dishop.HoyiVuePage;
import org.hoyi.disptachs.model.fieldstr;
import org.hoyi.util.DateTimeUtil;
import org.hoyi.wb.comment.RequestMode;
import org.hoyi.wb.comment.RequestType;

import model.<%%# m.Caption #%%>.<%%# e.ClassName #%%>;

@RequestMode(MODE = { RequestType.GET, RequestType.POST })
public class <%%# e.ClassName #%%>manage extends HoyiVuePage {

	@RequestMode(MODE={RequestType.POST})
	public void Add<%%# e.ClassName.ToParscal() #%%>()
	{
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = this.getModelFromReq(<%%# e.ClassName #%%>.class);
		int ret = _<%%# e.ClassName #%%>.Insert();
		
		if (ret > 0) {
			RE<%%# e.ClassName.ToParscal() #%%>();
		} else {
			this.WriteUTF8JSONDATAMSG(-1, "添加失败!~", "");
		}
	}
	
	@RequestMode(MODE = { RequestType.POST })
	public void DELETE() {
		String _<%%# e.getfirfieldName() #%%> = this.getParams("<%%# e.getfirfieldName() #%%>");
		int ret2 = <%%# e.ClassName #%%>.E().Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.Equals(_<%%# e.getfirfieldName() #%%>)).Delete();

		if (ret2 > 0) {
			RE<%%# e.ClassName.ToParscal() #%%>();
		} else {
			this.WriteUTF8JSONDATAMSG(-1, "删除失败!~", "");
		}
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void UPDATEBYID()
	{
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = this.getModelFromReq(<%%# e.ClassName #%%>.class);
		int ret1 = _<%%# e.ClassName #%%>.Update();
		
		if (ret1 > 0) {
			RE<%%# e.ClassName.ToParscal() #%%>();
		} else {
			this.WriteUTF8JSONDATAMSG(-1, "更新失败!~", "");
		}
	}

	public String Tr<%%# e.ClassName.ToParscal() #%%>() {
		String filter = this.getParams("filter");
		FILTER fil = null;
		if (filter != null && filter.length() > 0) {
			filter = "%" + filter + "%";
			
			fil = <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.Like(filter)<%%# [Fields[Inner,0,Last(1)]={.OR(<%#= e.ClassName #%>.<%#= t.ColumnName #%>.Like(filter))}] #%%>;	
		}

		DataCount = <%%# e.ClassName #%%>.E().Where(fil).Count();

		this.setDataCount(DataCount);
		this.SetParamPageIndex();

		List<<%%# e.ClassName #%%>> _<%%# e.ClassName #%%>s = <%%# e.ClassName #%%>.E().Where(fil).DataCount(DataCount).PgSize(getPageSize()).Jump(getPageIndex()).Select();

		return RetJson( _<%%# e.ClassName #%%>s).toString();
	}

	@RequestMode(MODE = { RequestType.POST })
	public void RE<%%# e.ClassName.ToParscal() #%%>() {
		String retobj = this.Tr<%%# e.ClassName.ToParscal() #%%>();
		this.WriteUTF8JSONDATA(retobj);
	}

	@Override
	public List<fieldstr> GetFields() {
		if( fieldstrs == null || fieldstrs.size() < 1) {
			fieldstrs = new ArrayList<>();
			<%%# [Fields[Equals(0)]={fieldstrs.add(new fieldstr("<%#= t.Comment #%>", "<%#= t.ColumnName #%>", false, false, true)); // 不显示，提交 }] #%%>
			<%%# [Fields[Equals(1)]={fieldstrs.add(new fieldstr("<%#= t.Comment #%>", "<%#= t.ColumnName #%>", true, true, false));  // 显示，提交 }] #%%>
			<%%# [Fields[Equals(2)]={fieldstrs.add(new fieldstr("<%#= t.Comment #%>", "<%#= t.ColumnName #%>",false, false, false,false));  // 不显示，不提交 }] #%%>
			<%%# [Fields[>3]={fieldstrs.add(new fieldstr("<%#= t.Comment #%>", "<%#= t.ColumnName #%>", true, true, false));  // 显示，提交
			}] #%%>
		}
		return fieldstrs;
	}
}
