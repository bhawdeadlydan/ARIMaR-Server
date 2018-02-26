package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

/**
 * This class represents the arm_tl_step_group table to the spring boot framework
 * The parameters used are:
 *  @param tl_step_group_id , type int
 *  @param tl_step_id  , type int
 *  @param tl_group_id  , type int
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "arm_tl_step_group")
public class Arm_tl_step_group {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "tl_step_group_id")
	private int tl_step_group_id;

	@Column(name = "tl_step_id")
	private int tl_step_id;

	@Column(name = "tl_group_id") 
	private int tl_group_id;
	
	protected Arm_tl_step_group() {}

	public Arm_tl_step_group(int tl_step_group_id, int tl_step_id, int tl_group_id) {
		this.tl_step_group_id = tl_step_group_id;
		this.tl_step_id = tl_step_id;
		this.tl_group_id = tl_group_id;

	}

	@Override
	public String toString() {
		return String.format("tl_step_group_id='%s', tl_step_id='%s', tl_group_id='%s'", 
				tl_step_group_id, tl_step_id, tl_group_id);
	}

	//getters and setters
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

	public int getTl_group_id() {
		return tl_group_id;
	}

	public void setTl_group_id(int tl_group_id) {
		this.tl_group_id = tl_group_id;
	}
	
}
