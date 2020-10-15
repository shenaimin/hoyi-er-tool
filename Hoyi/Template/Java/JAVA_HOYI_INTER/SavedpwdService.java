package WebRoot.aide.inter;

import java.util.List;

import org.hoyi.dishop.Hoyipage;
import org.hoyi.wb.comment.RequestMode;
import org.hoyi.wb.comment.RequestType;

import com.meetdragon.aide.model.<%%# e.ClassName #%%>;


@RequestMode(MODE={RequestType.POST})
public class <%%# e.ClassName.ToParscal() #%%>Service extends Hoyipage {

	@RequestMode(MODE={RequestType.POST})
	public void Add()
	{
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = this.getModelFromReq(<%%# e.ClassName #%%>.class);
		
		int ret = _<%%# e.ClassName #%%>.Insert();
		this.HandlerEx("添加账务信息", ret);
	}

	@RequestMode(MODE={RequestType.POST})
	public void GetAll()
	{
		int offset = (this.getpgindex() - 1) * this.getpagesize();
//		List<account> datas = (List<account>) account.E().Limit(this.getoffset(),this.getpagesize()).Where(account.accountid.Greater(this.getStartid())).Select();
		List<<%%# e.ClassName #%%>> datas = (List<<%%# e.ClassName #%%>>) <%%# e.ClassName #%%>.E().Limit(offset, this.getpagesize()).Select();
		
		this.WriteUTF8JSONDATA(datas);
	}
	
	@RequestMode(MODE={RequestType.POST})
	public void GetAllCount()
	{
		int count = <%%# e.ClassName #%%>.E().Count();
		this.WriteUTF8JSONDATA(count);
	}
}
