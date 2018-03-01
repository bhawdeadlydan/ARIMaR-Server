package gis;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

import com.vividsolutions.jts.geom.Point;

/***
 * This class represents the gis_crosswalks table to the spring boot framework
 * The parameters used are:
 *  @param gis_crosswalks_id crosswalk id, type int
 *  @param intersection_id intersection id , type int
 *  @param crosswalk_coordinates coordinates, type Point
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "gis_crosswalks")
public class GisCrosswalks {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "gis_crosswalk_id")
	private int gis_crosswalk_id;

	@Column(name = "intersection_id")
	private int intersection_id;

	@Column(name = "crosswalk_coordinates") // geomerty -> Point
	private Point crosswalk_coordinates;

	protected GisCrosswalks() {
	}

	public GisCrosswalks(int gis_crosswalk_id, int intersection_id, Point crosswalk_coordinates) {
		this.gis_crosswalk_id = gis_crosswalk_id;
		this.intersection_id = intersection_id;
		this.crosswalk_coordinates = crosswalk_coordinates;
	}

	@Override
	public String toString() {
		return String.format("gis_crosswalk_id='%s', intersection_id='%s', crosswalk_coordinates='%s'", gis_crosswalk_id, intersection_id, crosswalk_coordinates);
	}

	//getters and setters
	public int getGis_crosswalks_id() {
		return gis_crosswalk_id;
	}

	public void setGis_crosswalks_id(int gis_crosswalks_id) {
		this.gis_crosswalk_id = gis_crosswalks_id;
	}

	public int getIntersection_id() {
		return intersection_id;
	}

	public void setIntersection_id(int intersection_id) {
		this.intersection_id = intersection_id;
	}

	public Point getCrosswalk_coordinates() {
		return crosswalk_coordinates;
	}

	public void setCrosswalk_coordinates(Point crosswalk_coordinates) {
		this.crosswalk_coordinates = crosswalk_coordinates;
	}
	
	

}