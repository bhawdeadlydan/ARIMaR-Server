package gis;

import java.util.ArrayList;
import java.util.List;

import org.geolatte.geom.Position;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import dao.GisCrosswalksRepository;
import dao.GisEspirasRepository;
import dao.GisRepository;
import main.DTO;

@RestController
@Component
public class GisController {

	@Autowired
	GisRepository repository;

	@Autowired
	GisCrosswalksRepository crosswalkRepo;
	
	@Autowired
	GisEspirasRepository espirasRepo;


	//gis/find?id=2805976805
	@RequestMapping(value="gis/find", method = RequestMethod.GET)
	public Object findById(@RequestParam("id") long id){
		Points object = repository.findOne(id);
		if(object == null) {
			return "Nothing found! The value entered as id must be misspelt! Type it again. (osm_id)";
		}
		@SuppressWarnings("unchecked")
		DTO dtoObject = new DTO(object.getOsm_id(), object.getAmenity(), object.getHighway(), object.getTags(), object.getWay());

		return dtoObject;
	}

	//gis/find/amenity?id=cafe
	@RequestMapping(value="gis/find/amenity", method = RequestMethod.GET)
	public Object findByAmenity(@RequestParam("id") String id){
		List<Points> object = repository.findByAmenity(id);
		if(object.isEmpty()) {
			System.out.println("Nothing found! The value entered as id must be misspelt! Type it again. (amenity)");
		}
		List<DTO> objList = new ArrayList<DTO>();
		for(Points ob: object) {
			DTO dtoObject = new DTO(ob.getOsm_id(), ob.getAmenity(), ob.getHighway(), ob.getTags(), ob.getWay());
			objList.add(dtoObject);
		}
		return objList;

	}

	//gis/find/highway?id=traffic_signals
	@RequestMapping(value="gis/find/highway", method = RequestMethod.GET)
	public Object findByHigway(@RequestParam("id") String id){
		List<Points> object = repository.findByHighway(id);
		if(object.isEmpty()) {
			return "Nothing found! The value entered as id must be misspelt! Type it again. (highway)";
		}
		List<DTO> objList = new ArrayList<DTO>();
		for(Points ob: object) {
			DTO dtoObject = new DTO(ob.getOsm_id(), ob.getAmenity(), ob.getHighway(), ob.getTags(), ob.getWay());
			objList.add(dtoObject);
		}
		return objList;
	}


	//gis/find/gis-crosswalks?id=1
	@RequestMapping(value="gis/find/gis-crosswalks", method = RequestMethod.GET)
	public Object findByGisCrosswalks(@RequestParam("id") int id){
		GisCrosswalks object = crosswalkRepo.findOne(id);
		if(object == null) {
			return "Nothing found! The value entered as id must be misspelt! Type it again. (gis_crosswalk_id)";
		}
		DTO dtoObject = new DTO();
		dtoObject.setGis_crosswalks_id(object.getGis_crosswalks_id());
		dtoObject.setGis_crosswalks_intersection_id(object.getIntersection_id());
		
		Position pos = object.getCrosswalk_coordinates().getPosition();			
		dtoObject.setGis_crosswalk_coordinatesX(pos.getCoordinate(0));
		dtoObject.setGis_crosswalk_coordinatesY(pos.getCoordinate(1));

		return dtoObject;
	}
	
	
	//gis/find/gis-espiras?id=1
		@RequestMapping(value="gis/find/gis-espiras", method = RequestMethod.GET)
		public Object findByGisEspiras(@RequestParam("id") int id){
			GisEspiras object = espirasRepo.findOne(id);
			if(object == null) {
				return "Nothing found! The value entered as id must be misspelt! Type it again. (gis_espiras_id)";
			}
			DTO dtoObject = new DTO();
			dtoObject.setGis_espiras_id(object.getGis_espiras_id());
			dtoObject.setGis_espiras_intersection_id(object.getGis_espiras_intersection_id());
			
			Position pos = object.getEspiras_coordinates().getPosition();			
			dtoObject.setGis_espiras_coordinatesX(pos.getCoordinate(0));
			dtoObject.setGis_espiras_coordinatesY(pos.getCoordinate(1));

			return dtoObject;
		}


	/*	public GisController() {

	}*/

}

