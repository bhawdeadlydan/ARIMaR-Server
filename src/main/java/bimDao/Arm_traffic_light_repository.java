package bimDao;

import java.io.Serializable;
import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Arm_traffic_light;


@Transactional 
@Repository
public interface Arm_traffic_light_repository extends CrudRepository<Arm_traffic_light, Serializable> {

	@Query(value = "SELECT * FROM arm_traffic_light WHERE ST_DWithin(coordinates, ST_SetSRID(ST_Point(?1,?2),4326), 0.00015)", nativeQuery = true)
		List<Arm_traffic_light> findInfraAround(double coordx, double coordy);
}
