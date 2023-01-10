package net.postcore.coursecatalog;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

@RestController
public class CatalogController {

    @RequestMapping("/")
    public String getCatalogHome() {
        String courseAppMessage = "";
        String courseAppUrl = "http://localhost:8080";
        RestTemplate restTemplate = new RestTemplate();
        courseAppMessage = restTemplate.getForObject(courseAppUrl, String.class);

        return "Welcome to Course Catalog" + '\n' + courseAppMessage;
    }

    @RequestMapping("/catalog")
    public String getCatalog() {
        String courses = "";
        String courseAppUrl = "http://localhost:8080/courses";
        RestTemplate restTemplate = new RestTemplate();
        courses = restTemplate.getForObject(courseAppUrl, String.class);

        return "Our courses are: " + '\n' + courses;
    }

    @RequestMapping("/firstcourse")
    public String getCatalogCourse() {
        Course course = null;
        String courseAppUrl = "http://localhost:8080/courses/1";
        RestTemplate restTemplate = new RestTemplate();
        course = restTemplate.getForObject(courseAppUrl, Course.class);

        return "Our first course is: " + (course != null ? course.getCourseName() : " not found");
    }
}
