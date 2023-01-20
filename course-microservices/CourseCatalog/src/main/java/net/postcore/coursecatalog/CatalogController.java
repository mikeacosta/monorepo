package net.postcore.coursecatalog;

import com.netflix.appinfo.InstanceInfo;
import com.netflix.discovery.EurekaClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cloud.client.circuitbreaker.CircuitBreaker;
import org.springframework.cloud.client.circuitbreaker.CircuitBreakerFactory;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

@RestController
public class CatalogController {

    @Autowired
    private EurekaClient eurekaClient;

    @Autowired
    private CircuitBreakerFactory circuitBreakerFactory;

    @RequestMapping("/")
    public String getCatalogHome() {
        CircuitBreaker circuitBreaker = circuitBreakerFactory.create("circuitbreaker");

        String url = getCourseAppUrl();
        RestTemplate restTemplate = new RestTemplate();
        String courseAppMessage = circuitBreaker.run(() -> restTemplate.getForObject(url, String.class),
                throwable -> displayDefaultHome());

        return "Welcome to Course Catalog" + '\n' + courseAppMessage;
    }

    private String displayDefaultHome() {
        return("Welcome to Course Catalog " + " Please try again later");
    }

    @RequestMapping("/catalog")
    public String getCatalog() {
        RestTemplate restTemplate = new RestTemplate();
        String courses = restTemplate.getForObject(getCourseAppUrl() + "/courses", String.class);
        return "Our courses are: " + '\n' + courses;
    }

    @RequestMapping("/firstcourse")
    public String getCatalogCourse() {
        RestTemplate restTemplate = new RestTemplate();
        Course course = restTemplate.getForObject(getCourseAppUrl() + "/courses/1", Course.class);
        return "Our first course is: " + (course != null ? course.getCourseName() : " not found");
    }

    private String getCourseAppUrl() {
        InstanceInfo instanceInfo = eurekaClient.getNextServerFromEureka("course-app", false);
        return instanceInfo.getHomePageUrl();
    }
}
