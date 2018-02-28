package dao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import gis.GisEspiras;

@Transactional
@Repository
public interface GisEspirasRepository extends CrudRepository<GisEspiras, Serializable>{

}
