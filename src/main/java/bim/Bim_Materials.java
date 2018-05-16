package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;



/***
 * This class represents the bim_materials table to the spring boot framework
 * The parameters used are:
 *  @param espiras_id espiras id, type int
 *  @param intersection_id intersection id, type int
 *  @param material_id material id, type int
 *  @param tipologia tipologia of the espira, type String
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "bim_materials")
public class Bim_Materials{

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "id")
	private int materialsid;
	
	@Column(name = "name")
	private String materialsname;
	
	@Column(name = "description")
	private String materialsdescription;
	
	@Column(name = "cost")
	private double materialscost;


	protected Bim_Materials () {
	}

	public Bim_Materials (int materialsid, String materialsname, String materialsdescription, double materialscost) {
		this.materialsid = materialsid;
		this.materialsname = materialsname;
		this.materialsdescription = materialsdescription;
		this.materialscost = materialscost;
	}

	public int getMaterialsid() {
		return materialsid;
	}

	public void setMaterialsid(int materialsid) {
		this.materialsid = materialsid;
	}

	public String getMaterialsname() {
		return materialsname;
	}

	public void setMaterialsname(String materialsname) {
		this.materialsname = materialsname;
	}

	public String getMaterialsdescription() {
		return materialsdescription;
	}

	public void setMaterialsdescription(String materialsdescription) {
		this.materialsdescription = materialsdescription;
	}

	public double getMaterialscost() {
		return materialscost;
	}

	public void setMaterialscost(double materialscost) {
		this.materialscost = materialscost;
	}
	
	
	
	
	
}
