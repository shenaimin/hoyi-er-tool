package <%%# a.NameSpace #%%>.mds.<%%# e.ClassName #%%>;

import java.io.IOException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.net.URLDecoder;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.ibatis.session.SqlSession;

import <%%# a.NameSpace #%%>.dao.I<%%# e.ClassName #%%>Dao;
import <%%# a.NameSpace #%%>.model.<%%# e.ClassName #%%>;
import <%%# a.NameSpace #%%>.util.MYBATISUTIL;
import <%%# a.NameSpace #%%>.util.PGUTIL;
import <%%# a.NameSpace #%%>.util.RESPONSEUTIL;

public class <%%# e.ClassName #%%>Servlet extends HttpServlet {

	public SqlSession opensssion() {
		return new MYBATISUTIL().openSession();
	}
	
	public I<%%# e.ClassName #%%>Dao createdaoDao(SqlSession session) {
		return session.getMapper(I<%%# e.ClassName #%%>Dao.class);
	}
	
	int pagesize = 2;
	int pagecount = 0;
	int datacount = 0;
	int pgindex = 0;
	
	/**
	 * Constructor of the object.
	 */
	public <%%# e.ClassName #%%>Servlet() {
		super();
	}

	/**
	 * Destruction of the servlet. <br>
	 */
	public void destroy() {
		super.destroy(); // Just puts "destroy" string in log
		// Put your code here
	}
	
	public String ContactList<%%# e.ClassName #%%>(List<<%%# e.ClassName #%%>> <%%# e.ClassName #%%>s) {
		String result = "";
		for (<%%# e.ClassName #%%> _<%%# e.ClassName #%%> : <%%# e.ClassName #%%>s) {
			result += contact<%%# e.ClassName #%%>(_<%%# e.ClassName #%%>);
		}
		return result;
	}
	/**
	 * 返回表头.
	 * @return
	 */
	public  String contactTBHEAD() {
		String head = "<thead> " + 
		              "       <tr> " + 
		              "          <th>用户姓名</th> " +
		              "          <th>用户类型</th> " + 
		              "          <th>电话</th> 	" + 
		              "          <th>注册时间</th> " + 
		              "          <th>密码</th>	" + 
		              "          <th>昵称</th> 	" + 
		              "          <th>签名</th>	" + 
		              "          <th>区划编号</th> " + 
		              "          <th>备注</th> 	" + 
		              "          <th></th> 		" + 
		              "      </tr> 				" + 
		              "  </thead>";
		return head;
	}
	/**
	 * 返回单个用户实体
	 * @param <%%# e.ClassName #%%>
	 * @return
	 */
	public String contact<%%# e.ClassName #%%>(<%%# e.ClassName #%%> _<%%# e.ClassName #%%>) {
		if (_<%%# e.ClassName #%%> != null) {
			return "<tr id=\"tr"+ _<%%# e.ClassName #%%>.get<%%# e.getfirfieldName().ToParscal() #%%>()+ "\">"
					
//					+ "<th scope=\"row\">" + _<%%# e.ClassName #%%>.get<%%# e.getfirfieldName().ToParscal() #%%>() + "</th>"
					
						<%%# [Fields[>1]={
						+ "<td>" + _<%#= e.ClassName #%>.get<%#= t.ColumnName.ToParscal() #%>() +"</td>"}] #%%>	
					+"<td>"
					+" <a class=\"label label-success\" style=\"padding:4px;\"  onclick=\"MODI("
					
					
						<%%# [Fields[Inner,0,Last(1)]={
						+ "'" + _<%#= e.ClassName #%>.get<%#= t.ColumnName.ToParscal() #%>()  + "',"   }] #%%>	
						<%%# [Fields[Last(1)]={
						+ "'" + _<%#= e.ClassName #%>.get<%#= t.ColumnName.ToParscal() #%>()  + "'"    }] #%%>
					+ ");\"><span class=\"glyphicon glyphicon-pencil\" style=\"color:white;\" aria-hidden=\"true\" "
					
					+ "></span>  </a>"
					+"&nbsp;<a class=\"label label-danger\" style=\"padding:4px 5px 4px 5px;\"  onclick=\"DEL('" + _<%%# e.ClassName #%%>.get<%%# e.getfirfieldName().ToParscal() #%%>() + "','" + _<%%# e.ClassName #%%>.get<%%# e.getsecfieldname().ToParscal() #%%>() + "');\" >"
					+ "<span class=\"glyphicon glyphicon-trash\" style=\"color:white;\" aria-hidden=\"true\" ></span></a></td>"
					
//					+"<td><button type=\"button\" class=\"btn btn-primary btn-lg\" data-toggle=\"modal\" onclick=\"DEL('" + _<%%# e.ClassName #%%>.get<%%# e.getfirfieldName().ToParscal() #%%>() + "','" + _<%%# e.ClassName #%%>.get<%%# e.getsecfieldname().ToParscal() #%%>() + "');\" data-target=\"#myModal\"> 删除</button></td>"

					+ "</tr>";
		}
		return "";
	}
	/**
	 * 计算分页信息.
	 * @param request
	 * @param response
	 * @throws UnsupportedEncodingException 
	 */
	public void CalcPageInfos(HttpServletRequest request, HttpServletResponse response) throws UnsupportedEncodingException {
		String filters = request.getParameter("FILTER");
		if (filters != null) {
			System.out.println("UNDECODED filter:" + filters);
			filters = URLDecoder.decode(filters, "UTF-8").replace(" ", "%");
			System.out.println("DECODED filter:" + filters);
			
			filters = "%" + filters  + "%";
			System.out.println("ssssssssfilter:" + filters);
			
			SqlSession session = opensssion();
			datacount = createdaoDao(session).like<%%# e.ClassName #%%>count(filters);
			session.close();
		}else {
			SqlSession session = opensssion();
			datacount = createdaoDao(session).countAll();
			session.close();
		}
		
		pagecount = datacount / pagesize;
		if (datacount % pagesize > 0) {
			pagecount += 1;
		}

		if (request.getParameter("pgindex") != null) {
			pgindex = Integer.parseInt(request.getParameter("pgindex").toString());
		}else {
			pgindex = 0;
		}
		
		System.out.println("DataCount:" + datacount + ",pgindex:" + pgindex + ",pagesize:" + pagesize + ",pagecount:" + pagecount);
	}
	/**
	 * 根据条件获取数据.
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	public void GOTDATAHTML(HttpServletRequest request, HttpServletResponse response) throws IOException {

		String result ;
		
		CalcPageInfos(request, response);
		
		if (pgindex < pagecount) {

			Map<String,Object> params = new HashMap<String ,Object>();  
	        params.put("offset", pgindex * pagesize);  
	        params.put("pagesize", pagesize);  

	        SqlSession session = opensssion();
			List<<%%# e.ClassName #%%>> <%%# e.ClassName #%%>s = createdaoDao(session).getAll<%%# e.ClassName #%%>(params);
			session.close();
			
			result = ContactList<%%# e.ClassName #%%>(<%%# e.ClassName #%%>s);
			
			if (result.trim().length() == 0) {
				result = "NO DATA, PLEASE INSERT NOW.";
			}
			
		}else {
			result ="NO MORE DATA";
		}

		
		RESPONSEUTIL.getinstance().WriteUTF8HTML(response, result);
	}
	/**
	 * 默认方法，暂时无用.
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	public void BAKdefault(HttpServletRequest request, HttpServletResponse response) throws IOException{
		RESPONSEUTIL.getinstance().WriteUTF8HTML(response, this.getClass().toString());
	}
	
	/**
	 * 根据条件返回分页信息。
	 * @param request
	 * @param response
	 * @return
	 * @throws IOException
	 */
	public void GetPagingCTRL(HttpServletRequest request, HttpServletResponse response) throws IOException{
		this.CalcPageInfos(request, response);
		
		String result = PGUTIL.I().GETNAVIHTML(request, pagecount, pgindex);
		
		RESPONSEUTIL.getinstance().WriteUTF8HTML(response, result);
	}
	/**
	 * 根据Id删除
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	public void DELTEBYID(HttpServletRequest request, HttpServletResponse response) throws IOException {
		response.setContentType("text; charset=UTF-8");
		PrintWriter out = response.getWriter();
		
		String <%%# e.getfirfieldName() #%%> = request.getParameter("uid");

		SqlSession session = opensssion();
		I<%%# e.ClassName #%%>Dao dao = createdaoDao(session);
				
		dao.delete<%%# e.ClassName #%%>(<%%# e.getfirfieldName() #%%>);

		session.commit();
		session.close();
		
		out.println("success");
		out.flush();
		out.close();
		
		RESPONSEUTIL.getinstance().WriteUTF8Text(response, "success");
	}
	/**
	 * 增加
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	public void ADD(HttpServletRequest request, HttpServletResponse response) throws IOException{
		
		System.out.println("ADD FUNCTION.");
		
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = new <%%# e.ClassName #%%>();
		
		<%%# [Fields[>1]={
		_<%#= e.ClassName #%>.set<%#= t.ColumnName.ToParscal() #%>(request.getParameter("form-<%#= t.ColumnName #%>"));
		 }] #%%>

		SqlSession session = opensssion();
		I<%%# e.ClassName #%%>Dao dao = createdaoDao(session);
		
		dao.insert(_<%%# e.ClassName #%%>);
		session.commit();
		session.close();
		
		RESPONSEUTIL.getinstance().WriteUTF8Text(response, "addsuccess");
	}
	/**
	 * 更新
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	public void UPDATEBYID(HttpServletRequest request, HttpServletResponse response) throws IOException{
		System.out.println("<%%# e.getfirfieldName() #%%>:" + request.getParameter("form-<%%# e.getfirfieldName() #%%>"));

		
		<%%# e.ClassName #%%> _<%%# e.ClassName #%%> = new <%%# e.ClassName #%%>();
		<%%# [Fields[>0]={
		_<%#= e.ClassName #%>.set<%#= t.ColumnName.ToParscal() #%>(request.getParameter("form-<%#= t.ColumnName #%>"));
		 }] #%%>

		SqlSession session = opensssion();
		I<%%# e.ClassName #%%>Dao dao = createdaoDao(session);
		
		dao.UpdateByUnid(_<%%# e.ClassName #%%>);

		session.commit();
		session.close();
		
		RESPONSEUTIL.getinstance().WriteUTF8Text(response, "updatesuccess");
	}
	/**
	 * 
	 * @param response
	 * @param request
	 * @throws IOException
	 */
	public void LIKEUSER(HttpServletResponse response, HttpServletRequest request) throws IOException {

		String filter = request.getParameter("FILTER");
		if (filter != null) {
			System.out.println("UNDECODED filter:" + filter);
			filter = URLDecoder.decode(filter, "UTF-8").replace(" ", "%");
			System.out.println("DECODED filter:" + filter);
			filter = "%" + filter + "%";
		}

		String result = "";

		CalcPageInfos(request, response);
		
		if (pgindex < pagecount) {
			
			Map<String,Object> params = new HashMap<String ,Object>();  
	        params.put("offset", pgindex * pagesize);  
	        params.put("pagesize", pagesize); 
	        params.put("filters", filter);   

	        SqlSession session = opensssion();
	        I<%%# e.ClassName #%%>Dao dao = createdaoDao(session);
	        
			List<<%%# e.ClassName #%%>> <%%# e.ClassName #%%>s = dao.like<%%# e.ClassName #%%>(params);
			
			result = ContactList<%%# e.ClassName #%%>(<%%# e.ClassName #%%>s);
			session.close();
			
			if (result.trim().length() == 0) {
				result = "NO DATA , PLEASE INSERT NOW.";
			}
		}else {
			result = "NO MORE DATA";
		}
		
		RESPONSEUTIL.getinstance().WriteUTF8HTML(response, result);
	}
	
	/**
	 * The doGet method of the servlet. <br>
	 *
	 * This method is called when a form has its tag value method equals to get.
	 * 
	 * @param request the request send by the client to the server
	 * @param response the response send by the server to the client
	 * @throws ServletException if an error occurred
	 * @throws IOException if an error occurred
	 */
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

	}

	/**
	 * The doPost method of the servlet. <br>
	 *
	 * This method is called when a form has its tag value method equals to post.
	 * 
	 * @param request the request send by the client to the server
	 * @param response the response send by the server to the client
	 * @throws ServletException if an error occurred
	 * @throws IOException if an error occurred
	 */
	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		
		String action = request.getParameter("behavior");
		
		switch (action) {
			
			case "LIMITDATA":
				this.GOTDATAHTML(request, response);
				break;
				
			case "LIKEUSER":
				this.LIKEUSER(response, request);
				break;
				
			case "GETPGS":
				this.GetPagingCTRL(request, response);
				break;
	
			case "DELETE":
				this.DELTEBYID(request, response);
				break;
				
			case "ADD":
				this.ADD(request, response);
				break;
				
			case "UPDATEBYID":
				this.UPDATEBYID(request, response);
				break;
				
			default:
				BAKdefault(request, response);
				break;
		}
	}

	/**
	 * Initialization of the servlet. <br>
	 *
	 * @throws ServletException if an error occurs
	 */
	public void init() throws ServletException {
		// Put your code here
	}
}




