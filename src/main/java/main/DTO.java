package main;

import org.geolatte.geom.Point;
import org.geolatte.geom.Position;


public class DTO{

	//points
	private long osm_id;	
	private String amenity;
	private String highway;
	private String tags;
	private double wayX; // Point --> geometry
	private double wayY;

	//tl_controller
	private long tl__Controller_controller_id;
	private long cmp_longersection_id;

	//tl_group
	private int tl_group_id;
	private int tl_Group_controller_id;
	private int group_value;

	//tl_plan
	private int tl_plan_id;
	private int tl_Plan_controller_id;
	private int plan_value;
	private int duration;

	//tl_step_group
	private int tl_step_group_id;
	private int tl_step_id;
	private int tl_Step_Group_group_id;

	//tl_step
	private int tl_Step_step_id;
	private int tl_Step_controller_id;
	private int step_value;
	private int max_step_time;

	//traffic_light
	private int traffic_light_id;
	private int feu;
	private int tys;
	private Integer type;
	private int tl_Traffic_controller_id;
	private double coordinatesX; // Point --> geometry
	private double coordinatesY;

	//gis_crosswalks
	private int gis_crosswalks_id;
	private int gis_crosswalks_intersection_id;
	private double gis_crosswalk_coordinatesX;
	private double gis_crosswalk_coordinatesY;
	
	//bim_crosswalks
	private int bim_crosswalks_id;
	private int bim_crosswalks_intersection_id;
	private int bim_crosswalks_material_id;
	
	//bim_intersection
	private int bim_intersection_id;
	private String bim_intersection_description;


    /**
     *  empty contructor
     */
	public DTO () {}


	/**
	 *  planet_osm_point --> GIS SIDE CONSTRUCTOR
	 * @param osm_id
	 * @param amenity
	 * @param highway
	 * @param tags
	 * @param way
	 */
	public DTO(long osm_id, String amenity, String highway, String tags, Point<Position> way){ 
		this.osm_id = osm_id;
		this.amenity = amenity;
		this.highway = highway;
		// coordinates conversion
		Position pos = way.getPosition();
		this.wayX = pos.getCoordinate(0);
		this.wayY = pos.getCoordinate(1);	

	}



	//getters and setters
	public long getOsm_id() {
		return osm_id;
	}

	public void setOsm_id(long osm_id) {
		this.osm_id = osm_id;
	}

	public String getAmenity() {
		return amenity;
	}

	public void setAmenity(String amenity) {
		this.amenity = amenity;
	}

	public String getHighway() {
		return highway;
	}

	public void setHighway(String highway) {
		this.highway = highway;
	}

	public String getTags() {
		return tags;
	}

	public void setTags(String tags) {
		this.tags = tags;
	}

	public double getWayX() {
		return wayX;
	}

	public void setWayX(double wayX) {
		this.wayX = wayX;
	}

	public double getWayY() {
		return wayY;
	}

	public void setWayY(double wayY) {
		this.wayY = wayY;
	}


	public long getTl__Controller_controller_id() {
		return tl__Controller_controller_id;
	}


	public void setTl__Controller_controller_id(long tl__Controller_controller_id) {
		this.tl__Controller_controller_id = tl__Controller_controller_id;
	}


	public long getCmp_longersection_id() {
		return cmp_longersection_id;
	}


	public void setCmp_longersection_id(long cmp_longersection_id) {
		this.cmp_longersection_id = cmp_longersection_id;
	}


	public int getTl_group_id() {
		return tl_group_id;
	}


	public void setTl_group_id(int tl_group_id) {
		this.tl_group_id = tl_group_id;
	}


	public int getTl_Group_controller_id() {
		return tl_Group_controller_id;
	}


	public void setTl_Group_controller_id(int tl_Group_controller_id) {
		this.tl_Group_controller_id = tl_Group_controller_id;
	}


	public int getGroup_value() {
		return group_value;
	}


	public void setGroup_value(int group_value) {
		this.group_value = group_value;
	}


	public int getTl_plan_id() {
		return tl_plan_id;
	}


	public void setTl_plan_id(int tl_plan_id) {
		this.tl_plan_id = tl_plan_id;
	}


	public int getTl_Plan_controller_id() {
		return tl_Plan_controller_id;
	}


	public void setTl_Plan_controller_id(int tl_Plan_controller_id) {
		this.tl_Plan_controller_id = tl_Plan_controller_id;
	}


	public int getPlan_value() {
		return plan_value;
	}


	public void setPlan_value(int plan_value) {
		this.plan_value = plan_value;
	}


	public int getDuration() {
		return duration;
	}


	public void setDuration(int duration) {
		this.duration = duration;
	}


	public int getTl_step_group_id() {
		return tl_step_group_id;
	}


	public void setTl_step_group_id(int tl_step_group_id) {
		this.tl_step_group_id = tl_step_group_id;
	}


	public int getTl_step_id() {
		return tl_step_id;
	}


	public void setTl_step_id(int tl_step_id) {
		this.tl_step_id = tl_step_id;
	}


	public int getTl_Step_Group_group_id() {
		return tl_Step_Group_group_id;
	}


	public void setTl_Step_Group_group_id(int tl_Step_Group_group_id) {
		this.tl_Step_Group_group_id = tl_Step_Group_group_id;
	}


	public int getTl_Step_step_id() {
		return tl_Step_step_id;
	}


	public void setTl_Step_step_id(int tl_Step_step_id) {
		this.tl_Step_step_id = tl_Step_step_id;
	}


	public int getTl_Step_controller_id() {
		return tl_Step_controller_id;
	}


	public void setTl_Step_controller_id(int tl_Step_controller_id) {
		this.tl_Step_controller_id = tl_Step_controller_id;
	}


	public int getStep_value() {
		return step_value;
	}


	public void setStep_value(int step_value) {
		this.step_value = step_value;
	}


	public int getMax_step_time() {
		return max_step_time;
	}


	public void setMax_step_time(int max_step_time) {
		this.max_step_time = max_step_time;
	}


	public int getTraffic_light_id() {
		return traffic_light_id;
	}


	public void setTraffic_light_id(int traffic_light_id) {
		this.traffic_light_id = traffic_light_id;
	}


	public int getFeu() {
		return feu;
	}


	public void setFeu(int feu) {
		this.feu = feu;
	}


	public int getTys() {
		return tys;
	}


	public void setTys(int tys) {
		this.tys = tys;
	}


	public Integer getType() {
		return type;
	}


	public void setType(Integer type) {
		this.type = type;
	}


	public int getTl_Traffic_controller_id() {
		return tl_Traffic_controller_id;
	}


	public void setTl_Traffic_controller_id(int tl_Traffic_controller_id) {
		this.tl_Traffic_controller_id = tl_Traffic_controller_id;
	}


	public double getCoordinatesX() {
		return coordinatesX;
	}


	public void setCoordinatesX(double coordinatesX) {
		this.coordinatesX = coordinatesX;
	}


	public double getCoordinatesY() {
		return coordinatesY;
	}


	public void setCoordinatesY(double coordinatesY) {
		this.coordinatesY = coordinatesY;
	}


	public int getGis_crosswalks_id() {
		return gis_crosswalks_id;
	}


	public void setGis_crosswalks_id(int gis_crosswalks_id) {
		this.gis_crosswalks_id = gis_crosswalks_id;
	}


	public int getGis_crosswalks_intersection_id() {
		return gis_crosswalks_intersection_id;
	}


	public void setGis_crosswalks_intersection_id(int gis_crosswalks_intersection_id) {
		this.gis_crosswalks_intersection_id = gis_crosswalks_intersection_id;
	}


	public double getGis_crosswalk_coordinatesX() {
		return gis_crosswalk_coordinatesX;
	}


	public void setGis_crosswalk_coordinatesX(double gis_crosswalk_coordinatesX) {
		this.gis_crosswalk_coordinatesX = gis_crosswalk_coordinatesX;
	}


	public double getGis_crosswalk_coordinatesY() {
		return gis_crosswalk_coordinatesY;
	}


	public void setGis_crosswalk_coordinatesY(double gis_crosswalk_coordinatesY) {
		this.gis_crosswalk_coordinatesY = gis_crosswalk_coordinatesY;
	}


	public int getBim_crosswalks_id() {
		return bim_crosswalks_id;
	}


	public void setBim_crosswalks_id(int bim_crosswalks_id) {
		this.bim_crosswalks_id = bim_crosswalks_id;
	}


	public int getBim_crosswalks_intersection_id() {
		return bim_crosswalks_intersection_id;
	}


	public void setBim_crosswalks_intersection_id(int bim_crosswalks_intersection_id) {
		this.bim_crosswalks_intersection_id = bim_crosswalks_intersection_id;
	}


	public int getBim_crosswalks_material_id() {
		return bim_crosswalks_material_id;
	}


	public void setBim_crosswalks_material_id(int bim_crosswalks_material_id) {
		this.bim_crosswalks_material_id = bim_crosswalks_material_id;
	}


	public int getBim_intersection_id() {
		return bim_intersection_id;
	}


	public void setBim_intersection_id(int bim_intersection_id) {
		this.bim_intersection_id = bim_intersection_id;
	}


	public String getBim_intersection_description() {
		return bim_intersection_description;
	}


	public void setBim_intersection_description(String bim_intersection_description) {
		this.bim_intersection_description = bim_intersection_description;
	}
	
	

}
