package controllers;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;





@SpringBootApplication
@EntityScan(basePackages = "gis")
//@ComponentScan(basePackages = { "com.person","com.controller"} )
@ComponentScan(basePackages = "gis" )
public class Application{

	//@Autowired
	//GisRepository repository;
	
	public static void main(String[] args) throws Exception{
		ApplicationContext ctx = SpringApplication.run(Application.class, args);
		//SpringApplication.run(Application.class, args);
	}

	/*@Override
	public void run(String... strings) throws Exception {
		// clear all record if existed before do the tutorial with new data 
		//repository.deleteAll();
       
	}*/

}