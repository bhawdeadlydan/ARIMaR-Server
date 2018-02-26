package bimDao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Arm_tl_Step;

@Transactional 
@Repository
public interface Arm_tl_step extends CrudRepository<Arm_tl_Step, Serializable> {

}
