package dao;

import java.io.Serializable;
import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import gis.GisEspiras;

@Transactional
@Repository
public interface GisEspirasRepository extends CrudRepository<GisEspiras, Serializable>{

	@Query(value = "SELECT * FROM gis_espiras WHERE espiras_coordinates = ST_SetSRID(ST_MakePoint(?1, ?2),4326)", nativeQuery = true)
		GisEspiras findByCoord(double coordx, double coordy);
	
	@Query(value = "SELECT * FROM gis_espiras WHERE ST_DWithin(espiras_coordinates, ST_SetSRID(ST_Point(?1, ?2),4326), 0.0003)", nativeQuery = true)
		List<GisEspiras> findEspirasAround(double coordx, double coordy);
}
