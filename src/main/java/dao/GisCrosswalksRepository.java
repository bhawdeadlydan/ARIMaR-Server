package dao;

import java.io.Serializable;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import gis.GisCrosswalks;

@Transactional
@Repository
public interface GisCrosswalksRepository extends CrudRepository<GisCrosswalks, Serializable> {

}
