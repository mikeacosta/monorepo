package net.postcore.coursecatalog;

import com.netflix.appinfo.InstanceInfo;
import com.netflix.discovery.EurekaClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

@RestController
public class CatalogController {

    @Autowired
    private EurekaClient eurekaClient;

    private InstanceInfo instanceInfo;

    @RequestMapping("/")
    public String getCatalogHome() {
        String courseAppMessage = "";
        RestTemplate restTemplate = new RestTemplate();
        courseAppMessage = restTemplate.getForObject(getCourseAppUrl(), String.class);

        return "Welcome to Course Catalog" + '\n' + courseAppMessage;
    }

    @RequestMapping("/catalog")
    public String getCatalog() {
        String courses = "";
        RestTemplate restTemplate = new RestTemplate();
        courses = restTemplate.getForObject(getCourseAppUrl() + "/courses", String.class);

        return "Our courses are: " + '\n' + courses;
    }

    @RequestMapping("/firstcourse")
    public String getCatalogCourse() {
        Course course = null;
        RestTemplate restTemplate = new RestTemplate();
        course = restTemplate.getForObject(getCourseAppUrl() + "/courses/1", Course.class);

        return "Our first course is: " + (course != null ? course.getCourseName() : " not found");
    }

    private String getCourseAppUrl() {
        if (instanceInfo == null)
            instanceInfo = eurekaClient.getNextServerFromEureka("course-app", false);

        return instanceInfo.getHomePageUrl();
    }
}
