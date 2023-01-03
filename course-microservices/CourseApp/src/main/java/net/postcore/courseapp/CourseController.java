package net.postcore.courseapp;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Arrays;
import java.util.List;

@RestController
public class CourseController {

    @RequestMapping("/courses")
    public List<Course> getCourses() {
        return Arrays.asList(
                new Course("100","abc","author1"),
                new Course("101","xyz","author2"),
                new Course("102","pqr","author3")
        );
    }
}
