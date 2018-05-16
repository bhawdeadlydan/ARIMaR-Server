package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

/***
 * This class represents the bim_crosswalks table to the spring boot framework
 * The parameters used are:
 *  @param bim_crosswalks_id crosswalk id, type int
 *  @param intersection_id intersection id , type int
 *  @param material_id material id, type int
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "bim_crosswalks")
public class Bim_Crosswalks  {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "crosswalk_id")
	private int bim_crosswalk_id;

	@Column(name = "intersection_id")
	private int bim_intersection_id;

	@Column(name = "material_id") 
	private int crosswalk_material_id;

	protected Bim_Crosswalks () {
	}

	public Bim_Crosswalks (int bim_crosswalk_id, int bim_intersection_id, int crosswalk_material_id) {
		this.bim_crosswalk_id = bim_crosswalk_id;
		this.bim_intersection_id = bim_intersection_id;
		this.crosswalk_material_id = crosswalk_material_id;
	}

	@Override
	public String toString() {
		return String.format("bim_crosswalk_id='%s', bim_intersection_id='%s', crosswalk_material_id='%s'", bim_crosswalk_id, bim_intersection_id, crosswalk_material_id);
	}

	//getters and setters
	public int getBim_crosswalk_id() {
		return bim_crosswalk_id;
	}

	public void setBim_crosswalk_id(int bim_crosswalk_id) {
		this.bim_crosswalk_id = bim_crosswalk_id;
	}

	public int getBim_intersection_id() {
		return bim_intersection_id;
	}

	public void setBim_intersection_id(int bim_intersection_id) {
		this.bim_intersection_id = bim_intersection_id;
	}

	public int getCrosswalk_material_id() {
		return crosswalk_material_id;
	}

	public void setCrosswalk_material_id(int crosswalk_material_id) {
		this.crosswalk_material_id = crosswalk_material_id;
	}
	
	
	
}
