package dao;

import java.io.Serializable;
import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import gis.GisCrosswalks;

@Transactional
@Repository
public interface GisCrosswalksRepository extends CrudRepository<GisCrosswalks, Serializable> {

	@Query(value = "SELECT * FROM gis_crosswalks WHERE crosswalks_coordinates = ST_SetSRID(ST_MakePoint(?1, ?2),4326)", nativeQuery = true)
		GisCrosswalks findByCoord(double coordx, double coordy);
	
	@Query(value = "SELECT * FROM gis_crosswalks WHERE ST_DWithin(crosswalk_coordinates, ST_SetSRID(ST_Point(?1, ?2), 4326), 0.0003)", nativeQuery = true)
		List <GisCrosswalks> findCrosswalksAround(double coordx, double coordy);
}
