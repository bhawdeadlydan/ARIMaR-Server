package gis;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

import org.geolatte.geom.Point;

	/***
	 * This class represents the gis_espiras table to the spring boot framework
	 * The parameters used are:
	 *  @param gis_espiras_id espira id, type int
	 *  @param gis_espiras_intersection_id intersection id , type int
	 *  @param espiras_coordinates coordinates, type Point
	 * @author JoelCarneiro
	 *
	 */
	@Entity
	@Table(name = "gis_espiras")
	public class GisEspiras {

		@Id
		@GeneratedValue
		@NotNull
		@Column(name = "gis_espiras_id")
		private int gis_espiras_id;

		@Column(name = "gis_espiras_intersection_id")
		private int gis_espiras_intersection_id;

		@Column(name = "espiras_coordinates") // geomerty -> Point
		private Point espiras_coordinates;

		protected GisEspiras() {
		}

		public GisEspiras(int gis_espiras_id, int gis_espiras_intersection_id, Point espiras_coordinates) {
			this.gis_espiras_id = gis_espiras_id;
			this.gis_espiras_intersection_id = gis_espiras_intersection_id;
			this.espiras_coordinates = espiras_coordinates;
		}

		@Override
		public String toString() {
			return String.format("gis_espiras_id='%s', gis_espiras_intersection_id='%s', espiras_coordinates='%s'", gis_espiras_id, gis_espiras_intersection_id, espiras_coordinates);
		}

		//getters and setters
		public int getGis_espiras_id() {
			return gis_espiras_id;
		}

		public void setGis_espiras_id(int gis_espiras_id) {
			this.gis_espiras_id = gis_espiras_id;
		}

		public int getGis_espiras_intersection_id() {
			return gis_espiras_intersection_id;
		}

		public void setGis_espiras_intersection_id(int gis_espiras_intersection_id) {
			this.gis_espiras_intersection_id = gis_espiras_intersection_id;
		}

		public Point getEspiras_coordinates() {
			return espiras_coordinates;
		}

		public void setEspiras_coordinates(Point espiras_coordinates) {
			this.espiras_coordinates = espiras_coordinates;
		}

	
}
