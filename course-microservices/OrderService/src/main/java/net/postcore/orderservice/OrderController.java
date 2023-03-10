package net.postcore.orderservice;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class OrderController {

    @Value("${organization.name}")
    private String organizationName;

    @Value("${service.welcome.message}")
    private String serviceMessage;

    @RequestMapping("/")
    public String getOrder() {
        return(organizationName + " *** " + serviceMessage);
    }
}
