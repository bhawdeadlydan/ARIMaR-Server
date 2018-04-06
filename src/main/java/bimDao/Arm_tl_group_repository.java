package bimDao;

import java.io.Serializable;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Arm_tl_group;


@Transactional 
@Repository
public interface Arm_tl_group_repository extends CrudRepository<Arm_tl_group, Serializable> {
		
	@Query(value = "SELECT * FROM arm_tl_group WHERE group_value = ?1 AND tl_controller_id = ?2", nativeQuery = true)
		Arm_tl_group findByGroupValueANDController(int group_value, long controller);
	
}
