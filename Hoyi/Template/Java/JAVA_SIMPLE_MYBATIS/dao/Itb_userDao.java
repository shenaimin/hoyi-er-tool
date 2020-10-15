package <%%# a.NameSpace #%%>.dao;

import java.util.List;
import java.util.Map;

import <%%# a.NameSpace #%%>.model.<%%# e.ClassName #%%>;

/**
 * I<%%# e.ClassName #%%>Dao
 * @author ellen@kuaifish.com
 *
 */
public interface I<%%# e.ClassName #%%>Dao {
	int countAll();
	
	List<<%%# e.ClassName #%%>> getAll<%%# e.ClassName #%%>(Map<String, Object> pgs);
	
	List<<%%# e.ClassName #%%>> limit<%%# e.ClassName #%%>(Map<String, Object> pgs);
	
	int insert(<%%# e.ClassName #%%> _<%%# e.ClassName #%%>);
	
	void delete<%%# e.ClassName #%%>(String <%%# e.getfirfieldName() #%%>);
	
	void UpdateByUnid(<%%# e.ClassName #%%> _<%%# e.ClassName #%%>);
	
	List<<%%# e.ClassName #%%>> like<%%# e.ClassName #%%>(Map<String, Object> pgs);
	
	int like<%%# e.ClassName #%%>count(String filters);
}
