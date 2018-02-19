package serverHomePage;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

@Path("/")
public class Homepage {

	// Called if Text_PLAIN is request
	@GET
	@Produces(MediaType.TEXT_HTML)
	public String sayHTMLHello() {
		String htmlSource = "<h1 align='center'> ARIMaR Server </h1>" +
							"<p align='center'>Version 0.1.0 - 19/02/2018</p>"+
							"<p align='center'>Joel Carneiro</p>";
		return htmlSource;
	}
	
}
