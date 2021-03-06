package bimDao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Arm_tl_plan;

@Transactional 
@Repository
public interface Arm_tl_plan_repository extends CrudRepository<Arm_tl_plan, Serializable> {
	Arm_tl_plan findByTlcontrollerid(long tlcontrollerid);
}
