package bimDao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import bim.Bim_Espiras;

@Transactional
@Repository
public interface BimEspirasRepository extends CrudRepository<Bim_Espiras, Serializable> {

}
