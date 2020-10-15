package WebRoot.exmds.<%%# m.Caption #%%>;

import java.io.IOException;

import org.hoyi.DB.ctrl.FILTER;
import org.hoyi.dishop.Hoyipage;
import org.hoyi.wb.comment.PostParam;
import org.hoyi.wb.comment.RequestMode;
import org.hoyi.wb.comment.RequestType;
import org.hoyi.web.ctrls.Repeater;

import model.<%%# m.Caption #%%>.<%%# e.ClassName #%%>;

@RequestMode(MODE={RequestType.GET, RequestType.POST})
public class <%%# e.ClassName #%%>manage extends Hoyipage{
	
	Repeater rep<%%# e.ClassName #%%> = new Repeater("rep<%%# e.ClassName #%%>", pageroot);
	
	@Override
	@RequestMode(MODE={RequestType.POST})
	public void OnInit() throws IOException {
		if (this.Behaviored) 
			return;
		rep<%%# e.ClassName #%%>.FooterStyle = "A";
		// 这里可以上来什么事情都不干，直接发送获取项目列表的请求就行了.
		Set<%%# e.ClassName.ToParscal() #%%>Source();
		
		super.OnInit();
	}
	
	@PostParam(ENTITY=<%%# e.ClassName #%%>.class)
	@RequestMode(MODE={RequestType.POST})
	public void Add<%%# e.ClassName.ToParscal() #%%>()
	{
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = this.getModelFromReq(<%%# e.ClassName #%%>.class);
		int ret = _<%%# e.ClassName #%%>.Insert();
		
		if(ret == 1){
			this.WriteUTF8HTML("pgc(curindex); $('#modiModal').modal(\"hide\");");
		}else{
			this.WriteUTF8HTML("alert('新增失败');");
		}
	}
	
	@PostParam(PARMS={"<%%# e.ClassName #%%>id"})
	@RequestMode(MODE={RequestType.POST})
	public void DELETE()
	{
		String _<%%# e.ClassName #%%>id = this.getParams("<%%# e.ClassName #%%>id");
		int ret2 = <%%# e.ClassName #%%>.E().Where(<%%# e.ClassName #%%>.<%%# e.ClassName #%%>id.Equals(_<%%# e.ClassName #%%>id)).Delete();

		if(ret2 > 0){
			this.WriteUTF8HTML("$('#myModal').modal('hide');$('#tr" + _<%%# e.ClassName #%%>id + "').empty();pgc(curindex);");
		}else{
			this.WriteUTF8HTML("alert('删除失败');");
		}
	}
	
	@PostParam(ENTITY=<%%# e.ClassName #%%>.class)
	@RequestMode(MODE={RequestType.POST})
	public void UPDATEBYID()
	{
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = this.getModelFromReq(<%%# e.ClassName #%%>.class);
		int ret1 = _<%%# e.ClassName #%%>.Update();
		
		if(ret1 > 0){
			this.WriteUTF8HTML("pgc(curindex);$('#modiModal').modal('hide');");
		}else{
			this.WriteUTF8HTML("alert('更新失败');");
		}
	}

	@RequestMode(MODE={RequestType.POST})
	public void Set<%%# e.ClassName.ToParscal() #%%>Source() {
		String filter = this.getParams("filter");
		FILTER fil = null;
		if (filter != null && filter.length() > 0) {
			filter = "%" + filter + "%";
			
			fil = <%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.Like(filter)<%%# [Fields[Inner,0,Last(1)]={.OR(<%#= e.ClassName #%>.<%#= t.ColumnName #%>.Like(filter))}] #%%>;	
		}
		
		rep<%%# e.ClassName #%%>.DataCount = <%%# e.ClassName #%%>.E().Where(fil).Count();
		rep<%%# e.ClassName #%%>.PageIndex = this.getpgindex();
		rep<%%# e.ClassName #%%>.PageSize = 10;
		rep<%%# e.ClassName #%%>.EntitySource = <%%# e.ClassName #%%>.E().Where(fil).DataCount(rep<%%# e.ClassName #%%>.DataCount)
				.PgSize(rep<%%# e.ClassName #%%>.PageSize).Jump(rep<%%# e.ClassName #%%>.PageIndex).Select();
	}

	@RequestMode(MODE={RequestType.POST})
	public void Get<%%# e.ClassName.ToParscal() #%%>() {
		Set<%%# e.ClassName.ToParscal() #%%>Source();
		String Template = this.RenderChild(rep<%%# e.ClassName #%%>, rep<%%# e.ClassName #%%>.DataCount);
		this.WriteUTF8HTML(Template);
	}

}
