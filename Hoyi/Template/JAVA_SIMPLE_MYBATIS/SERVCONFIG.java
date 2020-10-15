package <%%# a.NameSpace #%%>.conf;

import java.util.HashMap;
import java.util.Map;

<%%# [Tables[X]={
import <%#= a.NameSpace #%>.mds.<%#= t.ClassName #%>Servlet;  }] #%%>

public class SERVCONFIG {

	private static SERVCONFIG _instance;
	
	public static SERVCONFIG getInstance(){
		
		if (_instance == null) {
			_instance = new SERVCONFIG();
		}
		return _instance;
		
	}
	
	public String rootpath = "/shibufangcao";

	public Map<String, Class<?>> servletMaps = new HashMap<String, Class<?>>();
	
	
	//  这里配置每个路径跳转到的调用类.
	public SERVCONFIG() {
		
//		servletMaps.put("/servlet/pro_projectServlet.hoyi", pro_projectServlet.class);
		
		<%%# [Tables[X]={
		servletMaps.put("/servlet/<%#= t.ClassName #%>Servlet.hoyi", <%#= t.ClassName #%>Servlet.class); }] #%%>

	}
	
}
