package gis;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

import org.geolatte.geom.Point;


/***
 * This class represents the planet_osm_point table to the spring boot framework
 * The parameters used are:
 *  @param osm_id object id, type long
 *  @param amenity type of object (cafe, etc), type String
 *  @param highway traffic_lights, type String
 *  @param tags "crossing"=>"traffic_signals" or "button_operated"=>"yes", type String (hstore)
 *  @param way coordinates, type Point
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "planet_osm_point")
public class Points {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "osm_id")
	private long osm_id;

	@Column(name = "amenity")
	private String amenity;
	
	@Column(name = "highway") // traffic_signals
	private String highway;

	@Column(name = "tags") // "crossing"=>"traffic_signals" or "button_operated"=>"yes" 
	private String tags;
	
	@Column(name = "way") // geomerty -> Point
	private Point way;

	protected Points() {
	}

	public Points(long osm_id, String amenity, String highway, String tags, Point way) {
		this.osm_id = osm_id;
		this.amenity = amenity;
		this.highway = highway;
		this.tags = tags;
		this.way = way;
	}

	@Override
	public String toString() {
		return String.format("osm_id='%s', amenity='%s', highway='%s', tags='%s', way='%s'", osm_id, amenity, highway, tags, way);
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

	public Point getWay() {
		return way;
	}

	public void setWay(Point way) {
		this.way = way;
	}
	
}