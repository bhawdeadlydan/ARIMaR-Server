package test;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

@Path("/test")
public class test {


	// Called if Text_PLAIN is request
//	@GET
//	@Produces(MediaType.TEXT_XML)
//	public String sayPlainTextHello() {
//		return "<h1>Hello World</h1>";
//	}


	// Called if xml is request
	@GET
	@Produces(MediaType.TEXT_XML)
	public String sayXMLHello() {
		String response =  "<?xml version='1.0'?>" + "<hello> Hello, World! </hello>" ;
		return response;
	}
}
