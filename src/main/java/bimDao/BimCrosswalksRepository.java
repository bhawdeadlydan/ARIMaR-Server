package bimDao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Bim_Crosswalks;

@Transactional
@Repository
public interface BimCrosswalksRepository extends CrudRepository<Bim_Crosswalks, Serializable>{

}
