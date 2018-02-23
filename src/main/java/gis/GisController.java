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

		
	//findall?id=2805976805
	@RequestMapping(value="/findall", method = RequestMethod.GET)
	@ResponseBody
	public String findById(@RequestParam("id") long id){
		Points object = repository.findOne(id);
		return object.toString();
	}
	
	//findall/amenity?id=cafe
	@RequestMapping(value="/findall/amenity", method = RequestMethod.GET)
	@ResponseBody
	public String findByAmenity(@RequestParam("id") String id){
		List<Points> object = repository.findByAmenity(id);
		return object.toString();
	}
	
	//findall/higway?id=traffic_signals
	@RequestMapping(value="/findall/highway", method = RequestMethod.GET)
	@ResponseBody
	public String findByHigway(@RequestParam("id") String id){
		List<Points> object = repository.findByHighway(id);
		return object.toString();
	}
	
	
/*	public GisController() {
		
	}*/
	
}

