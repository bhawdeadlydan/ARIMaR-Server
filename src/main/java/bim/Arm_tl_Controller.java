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
 *  @param equipment_id equipment id, type long
 *  @param arm_vertice_id  vertice id, type long
 *  @param cmp_tl_intersection_id intersection id, type long
 *  @param cmp_intersection_id intersection id, type long
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

	@Column(name = "equipment_id")
	private long equipment_id;

	@Column(name = "arm_vertice_id") 
	private long arm_vertice_id;

	@Column(name = "cmp_tl_intersection_id") 
	private long cmp_tl_intersection_id;

	@Column(name = "cmp_intersection_id")
	private long cmp_intersection_id;

	protected Arm_tl_Controller() {}

	public Arm_tl_Controller(long tl_controller_id, long equipment_id, long arm_vertice_id, long cmp_tl_intersection_id, long cmp_intersection_id) {
		this.tl_controller_id = tl_controller_id;
		this.equipment_id = equipment_id;
		this.arm_vertice_id = arm_vertice_id;
		this.cmp_tl_intersection_id = cmp_tl_intersection_id;
		this.cmp_intersection_id = cmp_intersection_id;
	}

	@Override
	public String toString() {
		return String.format("tl_controller_id='%s', equipment_id='%s', arm_vertice_id='%s', cmp_tl_intersection_id='%s', cmp_intersection_id='%s'", tl_controller_id, equipment_id, 
				arm_vertice_id, cmp_tl_intersection_id, cmp_intersection_id);
	}

	//getters and setters
	public long getTl_controller_id() {
		return tl_controller_id;
	}

	public void setTl_controller_id(long tl_controller_id) {
		this.tl_controller_id = tl_controller_id;
	}

	public long getEquipment_id() {
		return equipment_id;
	}

	public void setEquipment_id(long equipment_id) {
		this.equipment_id = equipment_id;
	}

	public long getArm_vertice_id() {
		return arm_vertice_id;
	}

	public void setArm_vertice_id(long arm_vertice_id) {
		this.arm_vertice_id = arm_vertice_id;
	}

	public long getCmp_tl_intersection_id() {
		return cmp_tl_intersection_id;
	}

	public void setCmp_tl_intersection_id(long cmp_tl_intersection_id) {
		this.cmp_tl_intersection_id = cmp_tl_intersection_id;
	}

	public long getCmp_intersection_id() {
		return cmp_intersection_id;
	}

	public void setCmp_intersection_id(long cmp_intersection_id) {
		this.cmp_intersection_id = cmp_intersection_id;
	}
}