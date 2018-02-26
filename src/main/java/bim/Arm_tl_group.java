package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

import org.geolatte.geom.Point;
 
/**
 * This class represents the arm_tl_group table to the spring boot framework
 * The parameters used are:
 *  @param tl_group_id group id, type long
 *  @param tl_controller_id controller id, type long
 *  @param group_value  , type long
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
	private int tl_group_id;

	@Column(name = "tl_controller_id")
	private int tl_controller_id;
	
	@Column(name = "group_value") 
	private int group_value;

	protected Arm_tl_group() {}

	public Arm_tl_group(int tl_group_id, int tl_controller_id, int group_value) {
		this.tl_group_id = tl_group_id;
		this.tl_controller_id = tl_controller_id;
		this.group_value = group_value;
	}

	@Override
	public String toString() {
		return String.format("tl_group_id='%s', tl_controller_id='%s', group_value='%s'", tl_group_id, tl_controller_id, 
				group_value);
	}

	//getters and setters
	public int getTl_group_id() {
		return tl_group_id;
	}

	public void setTl_group_id(int tl_group_id) {
		this.tl_group_id = tl_group_id;
	}

	public int getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(int tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
	}

	public int getGroup_value() {
		return group_value;
	}

	public void setGroup_value(int group_value) {
		this.group_value = group_value;
	}
	
}
