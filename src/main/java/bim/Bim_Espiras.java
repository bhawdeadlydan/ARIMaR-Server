package bim;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

/***
 * This class represents the bim_espiras table to the spring boot framework
 * The parameters used are:
 *  @param espiras_id espiras id, type int
 *  @param intersection_id intersection id, type int
 *  @param material_id material id, type int
 *  @param tipologia tipologia of the espira, type String
 * @author JoelCarneiro
 *
 */
@Entity
@Table(name = "bim_espiras")
public class Bim_Espiras  {

	@Id
	@GeneratedValue
	@NotNull
	@Column(name = "espiras_id")
	private int espiras_id;

	@Column(name = "intersection_id")
	private int intersection_id;
	
	@Column(name = "material_id")
	private int material_id;
	
	@Column(name = "tipologia")
	private String tipologia;


	protected Bim_Espiras () {
	}

	public Bim_Espiras (int espiras_id, int intersection_id, int material_id, String tipologia) {
		this.espiras_id = espiras_id;
		this.intersection_id = intersection_id;
		this.material_id = material_id;
		this.tipologia = tipologia;
	}

	@Override
	public String toString() {
		return String.format("espiras_id='%s', intersection_id='%s', material_id='%s', tipologia='%s'", espiras_id, intersection_id, material_id, tipologia);
	}

	//getters and setters
	public int getEspiras_id() {
		return espiras_id;
	}

	public void setEspiras_id(int espiras_id) {
		this.espiras_id = espiras_id;
	}

	public int getIntersection_id() {
		return intersection_id;
	}

	public void setIntersection_id(int intersection_id) {
		this.intersection_id = intersection_id;
	}

	public int getMaterial_id() {
		return material_id;
	}

	public void setMaterial_id(int material_id) {
		this.material_id = material_id;
	}

	public String getTipologia() {
		return tipologia;
	}

	public void setTipologia(String tipologia) {
		this.tipologia = tipologia;
	}
	
	
}
