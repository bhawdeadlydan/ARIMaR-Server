package bimDao;

import java.io.Serializable;
import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Bim_Crosswalks;

@Transactional
@Repository
public interface BimCrosswalksRepository extends CrudRepository<Bim_Crosswalks, Serializable>{

	@Query("select crosswalk from Bim_Crosswalks crosswalk where crosswalk.bim_intersection_id = ?1 and crosswalk.crosswalk_material_id = ?2 ")
	 	List<Bim_Crosswalks> findByTwo(int bim_intesection_id, int crosswalk_material_id);
}
