package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;


/**
 * This class represents the arm_tl_controller table to the spring boot framework
 * The parameters used are:
 *  @param tl_controller_id controller id, type long
 *  @param cmp_longersection_id longersection id, type long
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "arm_tl_controller")
public class Arm_tl_Controller {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "tl_controller_id")
	private long tl_controller_id;

	@Column(name = "cmp_intersection_id")
	private long cmpintersectionid;

	protected Arm_tl_Controller() {}

	public Arm_tl_Controller(long tl_controller_id, long cmp_longersection_id) {
		this.tl_controller_id = tl_controller_id;
		this.cmpintersectionid = cmp_longersection_id;
	}

	@Override
	public String toString() {
		return String.format("tl_controller_id='%s',  cmp_longersection_id='%s'", tl_controller_id, cmpintersectionid);
	}

	//getters and setters
	public long getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(long tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
	}

	public long getCmp_longersection_id() {
		return cmpintersectionid;
	}

	public void setCmp_longersection_id(long cmp_longersection_id) {
		this.cmpintersectionid = cmp_longersection_id;
	}

	
}