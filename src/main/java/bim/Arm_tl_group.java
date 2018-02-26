package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
 
/**
 * This class represents the arm_tl_group table to the spring boot framework
 * The parameters used are:
 *  @param tl_group_id group id, type long
 *  @param tl_controller_id controller id, type long
 *  @param group_value  , type long
 *  @param geom  , type long
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "arm_tl_group")
public class Arm_tl_group {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "tl_group_id")
	private long tl_group_id;

	@Column(name = "tl_controller_id")
	private long tl_controller_id;
	
	@Column(name = "group_value") 
	private long group_value;

	@Column(name = "geom") 
	private long geom;
	

	protected Arm_tl_group() {}

	public Arm_tl_group(long tl_group_id, long tl_controller_id, long group_value, long geom) {
		this.tl_group_id = tl_group_id;
		this.tl_controller_id = tl_controller_id;
		this.group_value = group_value;
		this.geom = geom;

	}

	@Override
	public String toString() {
		return String.format("tl_group_id='%s', tl_controller_id='%s', group_value='%s', geom='%s'", tl_group_id, tl_controller_id, 
				group_value, geom);
	}

	//getters and setters
	public long getTl_group_id() {
		return tl_group_id;
	}

	public void setTl_group_id(long tl_group_id) {
		this.tl_group_id = tl_group_id;
	}

	public long getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(long tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
	}

	public long getGroup_value() {
		return group_value;
	}

	public void setGroup_value(long group_value) {
		this.group_value = group_value;
	}

	public long getGeom() {
		return geom;
	}

	public void setGeom(long geom) {
		this.geom = geom;
	}
	
	
}
