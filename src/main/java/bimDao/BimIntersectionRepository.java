package bimDao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Bim_Intersection;

@Transactional
@Repository
public interface BimIntersectionRepository extends CrudRepository<Bim_Intersection, Serializable>{

}
