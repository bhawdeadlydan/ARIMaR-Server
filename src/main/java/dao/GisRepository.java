package dao;

import java.io.Serializable;
import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import gis.Points;

@Transactional 
@Repository
public interface GisRepository extends CrudRepository<Points, Serializable> {
		List<Points> findByAmenity(String amenity);
		List<Points> findByHighway(String highway);
		//Points findByOsm_id(long oms_id);
		
		/* @Query("SELECT a FROM Article a WHERE a.title=:title and a.category=:category")
		    List<Article> fetchArticles(@Param("title") String title, @Param("category") String category);*/
}
