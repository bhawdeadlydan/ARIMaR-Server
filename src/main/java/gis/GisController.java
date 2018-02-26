package gis;

import java.util.List;

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

		
	//find?id=2805976805
	@RequestMapping(value="/find", method = RequestMethod.GET)
	@ResponseBody
	public String findById(@RequestParam("id") long id){

		Points object = repository.findOne(id);
		if(object == null) {
			return "Nothing found! The value entered as id must be misspelt! Type it again. (osm_id)";
		}
		return object.toString();
	}
	
	//find/amenity?id=cafe
	@RequestMapping(value="/find/amenity", method = RequestMethod.GET)
	@ResponseBody
	public String findByAmenity(@RequestParam("id") String id){
		List<Points> object = repository.findByAmenity(id);
		if(object.isEmpty()) {
			return "Nothing found! The value entered as id must be misspelt! Type it again. (amenity)";
		}
		return object.toString();
	}
	
	//find/highway?id=traffic_signals
	@RequestMapping(value="/find/highway", method = RequestMethod.GET)
	@ResponseBody
	public String findByHigway(@RequestParam("id") String id){
		List<Points> object = repository.findByHighway(id);
		if(object.isEmpty()) {
			return "Nothing found! The value entered as id must be misspelt! Type it again. (highway)";
		}
		return object.toString();
	}
	
	
/*	public GisController() {
		
	}*/
	
}

