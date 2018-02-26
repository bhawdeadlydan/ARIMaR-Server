package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
  
/**
 * This class represents the arm_traffic_light table to the spring boot framework
 * The parameters used are:
 *  @param traffic_light_id traffic light id, type long
 *  @param feu  , type long
 *  @param tys  , type long
 *  @param type , type long
 *  @param tl_controller_id controller id, type long
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
	private long traffic_light_id;

	@Column(name = "feu")
	private long feu;

	@Column(name = "tys") 
	private long tys;

	@Column(name = "type") 
	private long type;

	@Column(name = "tl_controller_id")
	private long tl_controller_id;

	protected Arm_traffic_light() {}

	public Arm_traffic_light(long traffic_light_id, long feu, long tys, long type, long tl_controller_id) {
		this.traffic_light_id = traffic_light_id;
		this.feu = feu;
		this.tys = tys;
		this.type = type;
		this.tl_controller_id = tl_controller_id;
	}

	@Override
	public String toString() {
		return String.format("traffic_light_id='%s', feu='%s', tys='%s', type='%s', tl_controller_id='%s'", 
				traffic_light_id, feu, tys, type, tl_controller_id);
	}

	//getters and setters
	public long getTraffic_light_id() {
		return traffic_light_id;
	}

	public void setTraffic_light_id(long traffic_light_id) {
		this.traffic_light_id = traffic_light_id;
	}

	public long getFeu() {
		return feu;
	}

	public void setFeu(long feu) {
		this.feu = feu;
	}

	public long getTys() {
		return tys;
	}

	public void setTys(long tys) {
		this.tys = tys;
	}

	public long getType() {
		return type;
	}

	public void setType(long type) {
		this.type = type;
	}

	public long getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(long tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
	}
	
}