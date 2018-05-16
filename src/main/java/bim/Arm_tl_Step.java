package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

/**
 * This class represents the arm_tl_step table to the spring boot framework
 * The parameters used are:
 *  @param tl_step_id step id, type int
 *  @param tl_controller_id controller id, type int
 *  @param step_value  , type int
 *  @param max_step_time maximum time in seconds, type int
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "arm_tl_step")
public class Arm_tl_Step {


	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "tl_step_id")
	private int tl_step_id;

	@Column(name = "tl_controller_id")
	private int tl_controller_id;

	@Column(name = "step_value") 
	private int step_value;

	@Column(name = "max_step_time")
	private int max_step_time;

	protected Arm_tl_Step() {}

	public Arm_tl_Step(int tl_step_id, int tl_controller_id, int step_value, int max_step_time) {
		this.tl_step_id = tl_step_id;
		this.tl_controller_id = tl_controller_id;
		this.step_value = step_value;
		this.max_step_time = max_step_time;
	}

	@Override
	public String toString() {
		return String.format("tl_step_id='%s', tl_controller_id='%s', step_value='%s', max_step_time='%s'", tl_step_id,
				tl_controller_id, step_value, max_step_time);
	}

	//getters and setters
	public int getTl_step_id() {
		return tl_step_id;
	}

	public void setTl_step_id(int tl_step_id) {
		this.tl_step_id = tl_step_id;
	}

	public int getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(int tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
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

}