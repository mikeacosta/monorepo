package net.postcore.orderservice;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class OrderController {

    @RequestMapping("/")
    public String getOrder() {
        return("Hello from Order module");
    }
}
