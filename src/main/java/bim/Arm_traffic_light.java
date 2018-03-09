package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

import com.vividsolutions.jts.geom.Point;

  
/**
 * This class represents the arm_traffic_light table to the spring boot framework
 * The parameters used are:
 *  @param traffic_light_id traffic light id, type int
 *  @param feu  , type int
 *  @param tys  , type int
 *  @param type , type int
 *  @param tl_controller_id controller id, type int
 *  @param coordinates, type Point
 *  
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "arm_traffic_light")
public class Arm_traffic_light {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "traffic_light_id")
	private int traffic_light_id;

	@Column(name = "feu")
	private int feu;

	@Column(name = "tys") 
	private int tys;

	@Column(name = "type") 
	private Integer type;

	@Column(name = "tl_controller_id")
	private int tl_controller_id;
	
	@Column(name = "coordinates")
	private Point coordinates;

	protected Arm_traffic_light() {}

	public Arm_traffic_light(int traffic_light_id, int feu, int tys, Integer type, int tl_controller_id, Point coordinates) {
		this.traffic_light_id = traffic_light_id;
		this.feu = feu;
		this.tys = tys;
		this.type = type;
		this.tl_controller_id = tl_controller_id;
		this.coordinates = coordinates;
	}

	@Override
	public String toString() {
		return String.format("traffic_light_id='%s', feu='%s', tys='%s', type='%s', tl_controller_id='%s'", 
				traffic_light_id, feu, tys, type, tl_controller_id);
	}

	//getters and setters
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

	public int getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(int tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
	}

	public Point getCoordinates() {
		return coordinates;
	}

	public void setCoordinates(Point coordinates) {
		this.coordinates = coordinates;
	}
	
}