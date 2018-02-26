package bimDao;

import java.io.Serializable;
import org.springframework.data.repository.CrudRepository;
import bim.Arm_tl_Controller;

public interface Arm_tl_controller_repository extends CrudRepository<Arm_tl_Controller, Serializable> {
	//List<Points> findByAmenity(String amenity);
	//List<Points> findByHighway(String highway);
	//Points findByOsm_id(long oms_id);
}

