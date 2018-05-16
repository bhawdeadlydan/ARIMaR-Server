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
 *  @param tl_plan_id plan id, type int
 *  @param tl_controller_id controller id, type int
 *  @param plan_value  vertice id, type int
 *  @param duration duration in seconds, type int
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
	private int tl_plan_id;

	@Column(name = "tl_controller_id")
	private long tlcontrollerid;

	@Column(name = "plan_value") 
	private int plan_value;

	@Column(name = "duration") 
	private int duration;

	protected Arm_tl_plan() {}

	public Arm_tl_plan(int tl_plan_id, int tl_controller_id, int plan_value, int duration) {
		this.tl_plan_id = tl_plan_id;
		this.tlcontrollerid = tl_controller_id;
		this.plan_value = plan_value;
		this.duration = duration;
	}

	@Override
	public String toString() {
		return String.format("tl_plan_id='%s', tl_controller_id='%s', plan_value='%s', duration='%s'",
				tl_plan_id, tlcontrollerid, plan_value, duration);
	}

	//getters and setters
	public int getTl_plan_id() {
		return tl_plan_id;
	}

	public void setTl_plan_id(int tl_plan_id) {
		this.tl_plan_id = tl_plan_id;
	}

	public long getTl_controller_id() {
		return tlcontrollerid;
	}

	public void setTl_controller_id(long tl_controller_id) {
		this.tlcontrollerid = tl_controller_id;
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

	
}