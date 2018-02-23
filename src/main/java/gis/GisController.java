package gis;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import dao.GisRepository;

@RestController
@Component
public class GisController {

	@Autowired
	GisRepository repository;

		
	//findall?id=2805976805
	@RequestMapping(value="/findall", method = RequestMethod.GET)
	@ResponseBody
	public String findById(@RequestParam("id") long id){
		String result = "";
		result = repository.findOne(id).toString();
		return result + " found";
	}
	
/*	public GisController() {
		
	}*/
	
}

