package bimDao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Arm_traffic_light;

@Transactional 
@Repository
public interface Arm_traffic_light_repository extends CrudRepository<Arm_traffic_light, Serializable> {

}
