package WebRoot.exuns.<%%# m.Caption #%%>;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import net.sf.json.JSONObject;

import org.hoyi.DB.ctrl.FILTER;
import org.hoyi.dishop.Hoyipage;
import org.hoyi.disptachs.model.JsonModel;
import org.hoyi.wb.comment.RequestMode;
import org.hoyi.wb.comment.RequestType;
import org.hoyi.web.ctrls.Repeater;

import <%%# a.NameSpace #%%>.model.<%%# m.Caption #%%>.<%%# e.unikey_out_tb_name()  #%%>;
import <%%# a.NameSpace #%%>.model.<%%# m.Caption #%%>.<%%# e.ClassName #%%>;

@RequestMode(MODE={RequestType.GET, RequestType.POST})
public class <%%# e.unikey_out_tb_name()  #%%>_<%%# e.ClassName #%%>manage extends Hoyipage{
	
	Repeater rep<%%# e.ClassName #%%> = new Repeater("rep<%%# e.ClassName #%%>", pageroot);
	Repeater rep<%%# e.unikey_out_tb_name()  #%%> = new Repeater("rep<%%# e.unikey_out_tb_name()  #%%>", pageroot);
	
	@Override
	@RequestMode(MODE={RequestType.POST})
	public void OnInit() throws IOException {
		if (this.Behaviored) 
			return;
		
		rep<%%# e.ClassName #%%>.FooterStyle = "A";
		rep<%%# e.unikey_out_tb_name()  #%%>.FooterStyle = "A";
		
		// 这里可以上来什么事情都不干，直接发送获取项目列表的请求就行了.
		Set<%%# e.ClassName.ToParscal() #%%>Source();
		Set<%%# e.unikey_out_tb_name().ToParscal()  #%%>Source();
		
		super.OnInit();
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void Add<%%# e.ClassName.ToParscal() #%%>()
	{
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = this.getModelFromReq(<%%# e.ClassName #%%>.class);
		int ret = _<%%# e.ClassName #%%>.Insert();
		this.HandlerEx("新增", ret);
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void DELETE()
	{
		String _<%%# e.getfirfieldName() #%%> = this.getParams("<%%# e.getfirfieldName() #%%>");
		int ret2 = <%%# e.ClassName #%%>.E().Where(<%%# e.ClassName #%%>.<%%# e.getfirfieldName() #%%>.Equals(_<%%# e.getfirfieldName() #%%>)).Delete();

		this.HandlerEx("删除", ret2);
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void UPDATEBYID()
	{
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = this.getModelFromReq(<%%# e.ClassName #%%>.class);
		int ret1 = _<%%# e.ClassName #%%>.Update();

		this.HandlerEx("更新", ret1);
	}

	@RequestMode(MODE={RequestType.POST})
	public void Set<%%# e.ClassName.ToParscal() #%%>Source() {
		String filter = this.getParams("filter");
		String <%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%> = this.getParams("<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>");
		if (<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%> != null && <%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>.length() > 0) {
			FILTER fil = null;
			if (filter != null && filter.length() > 0) {
				filter = "%" + filter + "%";
				
				fil = <%%# e.ClassName #%%>.<%%# e.getsecfieldName() #%%>.Like(filter)<%%# [Fields[Inner,2,Last(1)]={.OR(<%#= e.ClassName #%>.<%#= t.ColumnName #%>.Like(filter))}] #%%>;	
			}
			
			rep<%%# e.ClassName #%%>.DataCount = <%%# e.ClassName #%%>.E().Where(<%%# e.ClassName #%%>.<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>.Equals(<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>)).WhereAnd(fil).Count();
			rep<%%# e.ClassName #%%>.PageIndex = this.getpgindex();
			rep<%%# e.ClassName #%%>.PageSize = 10;
			rep<%%# e.ClassName #%%>.EntitySource = <%%# e.ClassName #%%>.E().Where(<%%# e.ClassName #%%>.<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>.Equals(<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>)).WhereAnd(fil).DataCount(rep<%%# e.ClassName #%%>.DataCount)
					.PgSize(rep<%%# e.ClassName #%%>.PageSize).Jump(rep<%%# e.ClassName #%%>.PageIndex).Select();
		}else{
			rep<%%# e.ClassName #%%>.rendedHTMLContent =  "<span>未设置 <%%# e.unikey_out_tb_name().toentity().EntityName  #%%>,请设置<%%# e.unikey_out_tb_name().toentity().EntityName  #%%>后再试.....</span>";
		}
	}
	
	@RequestMode(MODE={RequestType.POST})
	public String GetFirst<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>()
	{
		<%%# e.unikey_out_tb_name()  #%%> _<%%# e.unikey_out_tb_name()  #%%> = <%%# e.unikey_out_tb_name()  #%%>.E().Where(null).First();
		if (_<%%# e.unikey_out_tb_name()  #%%> != null) {
			return "current<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>='" + _<%%# e.unikey_out_tb_name()  #%%>.get<%%# e.unikey_out_tb_name().toentity().getfirfieldName().ToParscal()  #%%>()+ "'; current<%%# e.unikey_out_tb_name().toentity().getsecfieldName()  #%%> = '" + _<%%# e.unikey_out_tb_name()  #%%>.get<%%# e.unikey_out_tb_name().toentity().getsecfieldName().ToParscal()  #%%>() + "'";
		}
		return "";
	}

	@RequestMode(MODE={RequestType.POST})
	public void Get<%%# e.ClassName.ToParscal() #%%>() {
		Set<%%# e.ClassName.ToParscal() #%%>Source();
		String Template = this.RenderChild(rep<%%# e.ClassName #%%>, rep<%%# e.ClassName #%%>.DataCount);
		this.WriteUTF8HTML(Template);
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void Set<%%# e.unikey_out_tb_name().ToParscal()  #%%>Source()
	{
		String filter = this.getParams("filter");
		FILTER fil = null;
		if (filter != null && filter.length() > 0) {
			filter = "%" + filter + "%";

			fil = <%%# e.unikey_out_tb_name()  #%%>.<%%# e.unikey_out_tb_name().toentity().getsecfieldName()  #%%>.Like(filter);						
		}
		
		rep<%%# e.unikey_out_tb_name()  #%%>.DataCount = <%%# e.unikey_out_tb_name()  #%%>.E().Where(fil).Count();
		rep<%%# e.unikey_out_tb_name()  #%%>.PageIndex = this.getpgindex();
		rep<%%# e.unikey_out_tb_name()  #%%>.PageSize = 10;
		rep<%%# e.unikey_out_tb_name()  #%%>.EntitySource = <%%# e.unikey_out_tb_name()  #%%>.E().Where(fil).DataCount(rep<%%# e.unikey_out_tb_name()  #%%>.DataCount)
				.PgSize(rep<%%# e.unikey_out_tb_name()  #%%>.PageSize).Jump(rep<%%# e.unikey_out_tb_name()  #%%>.PageIndex).Select();
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void GetCurrent<%%# e.unikey_out_tb_name().toentity().getfirfieldName().ToParscal()  #%%>NAMES()
	{
		String filter = this.getParams("filter");
		FILTER fil = null;
		if (filter != null && filter.length() > 0) {
			filter = "%" + filter + "%";
			
			fil = <%%# e.unikey_out_tb_name()  #%%>.<%%# e.unikey_out_tb_name().toentity().getsecfieldName()  #%%>.Like(filter);	
		}
		
		rep<%%# e.unikey_out_tb_name()  #%%>.DataCount = <%%# e.unikey_out_tb_name()  #%%>.E().Where(fil).Count();
		rep<%%# e.unikey_out_tb_name()  #%%>.PageIndex = this.getpgindex();
		rep<%%# e.unikey_out_tb_name()  #%%>.PageSize = 10;
		<%%# e.unikey_out_tb_name()  #%%> _<%%# e.unikey_out_tb_name()  #%%> = <%%# e.unikey_out_tb_name()  #%%>.E().Where(fil).DataCount(rep<%%# e.unikey_out_tb_name()  #%%>.DataCount).PgSize(rep<%%# e.unikey_out_tb_name()  #%%>.PageSize).Jump(rep<%%# e.unikey_out_tb_name()  #%%>.PageIndex).First();
		if (_<%%# e.unikey_out_tb_name()  #%%> != null) {
			Map<String, String> <%%# e.unikey_out_tb_name()  #%%>map = new HashMap<String, String>();
			<%%# e.unikey_out_tb_name()  #%%>map.put("<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>", _<%%# e.unikey_out_tb_name()  #%%>.get<%%# e.unikey_out_tb_name().toentity().getfirfieldName().ToParscal()  #%%>());
			<%%# e.unikey_out_tb_name()  #%%>map.put("<%%# e.unikey_out_tb_name().toentity().getsecfieldName()  #%%>", _<%%# e.unikey_out_tb_name()  #%%>.get<%%# e.unikey_out_tb_name().toentity().getsecfieldName().ToParscal()  #%%>());
			this.WriteUTF8JSONDATAMSG(1, "", <%%# e.unikey_out_tb_name()  #%%>map);
		}else{
			this.WriteUTF8JSONDATAMSG(-1, "", null);
		}
	}
	
	@RequestMode(MODE={RequestType.POST})
	public String SETFIRST<%%# e.unikey_out_tb_name().ToParscal()  #%%>()
	{
		<%%# e.unikey_out_tb_name()  #%%> _<%%# e.unikey_out_tb_name()  #%%> = <%%# e.unikey_out_tb_name()  #%%>.E().First();
		if (_<%%# e.unikey_out_tb_name()  #%%> != null) {
			return " setcurrent<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>('#tr<%%# e.unikey_out_tb_name()  #%%>" + _<%%# e.unikey_out_tb_name()  #%%>.get<%%# e.unikey_out_tb_name().toentity().getfirfieldName().ToParscal()  #%%>() + "', '" + _<%%# e.unikey_out_tb_name()  #%%>.get<%%# e.unikey_out_tb_name().toentity().getfirfieldName().ToParscal()  #%%>() + "','" + _<%%# e.unikey_out_tb_name().toentity().ClassName  #%%>.get<%%# e.unikey_out_tb_name().toentity().getsecfieldName().ToParscal()  #%%>() + "');alert('baby');";
		}
		return " setcurrent<%%# e.unikey_out_tb_name().toentity().getfirfieldName()  #%%>('#tr<%%# e.unikey_out_tb_name()  #%%>', '','');";
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void Get<%%# e.unikey_out_tb_name().ToParscal()  #%%>() {
		Set<%%# e.unikey_out_tb_name().ToParscal()  #%%>Source();
		String Template = this.RenderChild(rep<%%# e.unikey_out_tb_name()  #%%>, rep<%%# e.unikey_out_tb_name()  #%%>.DataCount);
		this.WriteUTF8HTML(Template);
	}
}
