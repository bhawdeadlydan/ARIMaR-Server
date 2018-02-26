package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
  

/**
 * This class represents the arm_tl_plan table to the spring boot framework
 * The parameters used are:
 *  @param tl_plan_id plan id, type long
 *  @param tl_controller_id controller id, type long
 *  @param plan_value  vertice id, type long
 *  @param duration duration in seconds, type int
 *  @param description description, type String
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "arm_tl_plan")
public class Arm_tl_plan {


	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "tl_plan_id")
	private long tl_plan_id;

	@Column(name = "tl_controller_id")
	private long tl_controller_id;

	@Column(name = "plan_value") 
	private long plan_value;

	@Column(name = "duration") 
	private int duration;

	@Column(name = "description")
	private String description;

	protected Arm_tl_plan() {}

	public Arm_tl_plan(long tl_plan_id, long tl_controller_id, long plan_value, int duration, String description) {
		this.tl_plan_id = tl_plan_id;
		this.tl_controller_id = tl_controller_id;
		this.plan_value = plan_value;
		this.duration = duration;
		this.description = description;
	}

	@Override
	public String toString() {
		return String.format("tl_plan_id='%s', tl_controller_id='%s', plan_value='%s', duration='%s', description='%s'",
				tl_plan_id, tl_controller_id, plan_value, duration, description);
	}

	//getters and setters
	public long getTl_plan_id() {
		return tl_plan_id;
	}

	public void setTl_plan_id(long tl_plan_id) {
		this.tl_plan_id = tl_plan_id;
	}

	public long getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(long tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
	}

	public long getPlan_value() {
		return plan_value;
	}

	public void setPlan_value(long plan_value) {
		this.plan_value = plan_value;
	}

	public int getDuration() {
		return duration;
	}

	public void setDuration(int duration) {
		this.duration = duration;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}
	
}