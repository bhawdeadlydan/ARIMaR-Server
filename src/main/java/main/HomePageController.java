package main;

import org.springframework.stereotype.Component;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@Component
public class HomePageController {
	
	@RequestMapping(value = "/", method = RequestMethod.GET)
	public String homepage() {
		return "homepage";
	}
}
