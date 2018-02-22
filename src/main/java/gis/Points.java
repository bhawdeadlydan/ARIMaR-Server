package gis;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "planet_osm_point")
public class Points {

	//private static final long serialVersionUID = -3009157732242241606L;
	@Id
	@Column(name = "osm_id")
	private long osm_id;

	@Column(name = "amenity")
	private String amenity;

	protected Points() {
	}

	public Points(int osm_id, String amenity) {
		this.osm_id = osm_id;
		this.amenity = amenity;
	}

	@Override
	public String toString() {
		return String.format("osm_id='%s', amenity='%s'", osm_id, amenity);
	}
}