package controllers;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;


@SpringBootApplication
@EntityScan(basePackages = {"gis", "controllers", "dao"}) // to scan for @entity in the specified packages
@ComponentScan(basePackages = {"gis", "controllers", "dao" } ) // to scan fot @component in the specified packages
@EnableJpaRepositories("dao") // to scan for @repository in the specified packages
public class Application{

	public static void main(String[] args) throws Exception{
		ApplicationContext ctx = SpringApplication.run(Application.class, args);
		//SpringApplication.run(Application.class, args);
	}
}