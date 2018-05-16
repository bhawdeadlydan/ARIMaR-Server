package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;


/***
 * This class represents the bim_intersection table to the spring boot framework
 * The parameters used are:
 *  @param id intersection id, type int
 *  @param description description of the intersection , type String
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "bim_intersection")
public class Bim_Intersection  {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "id")
	private int bim_intersection_id;

	@Column(name = "description")
	private String bim_intersection_description;


	protected Bim_Intersection () {
	}

	public Bim_Intersection (int bim_intersection_id, String bim_intersection_description) {
		this.bim_intersection_id = bim_intersection_id;
		this.bim_intersection_description = bim_intersection_description;
	}

	@Override
	public String toString() {
		return String.format("bim_intersection_id='%s', bim_intersection_description='%s'", bim_intersection_id, bim_intersection_description);
	}
	
	//getters and setters
	public int getBim_intersection_id() {
		return bim_intersection_id;
	}

	public void setBim_intersection_id(int bim_intersection_id) {
		this.bim_intersection_id = bim_intersection_id;
	}

	public String getBim_intersection_description() {
		return bim_intersection_description;
	}

	public void setBim_intersection_description(String bim_intersection_description) {
		this.bim_intersection_description = bim_intersection_description;
	}
	
}
