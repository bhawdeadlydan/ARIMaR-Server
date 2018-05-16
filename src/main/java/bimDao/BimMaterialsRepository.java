package bimDao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Bim_Materials;

@Transactional
@Repository
public interface BimMaterialsRepository extends CrudRepository<Bim_Materials, Serializable>{

}
