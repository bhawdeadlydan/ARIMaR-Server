package controllers;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import gis.Points;

//@Transactional
//@Repository
public interface GisRepository extends CrudRepository<Points, Long> {
		List<Points> findAll();
	//	List<Points> findByUid(long osm_id);
}
