package net.postcore.courseapp;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.math.BigInteger;
import java.util.List;
import java.util.Optional;

@RestController
public class CourseController {

    @Autowired
    private CourseRepository courseRepository;

    @RequestMapping("/")
    public String getCourseAppHome() {
        return "Course App Home";
    }

    @RequestMapping("/courses")
    public List<Course> getCourses() {
        return courseRepository.findAll();
    }

    @RequestMapping("/courses/{id}")
    public Optional<Course> getSpecificCourse(@PathVariable("id") BigInteger id ) {
        return courseRepository.findById(id);
    }

    @RequestMapping(method = RequestMethod.POST, value="/courses")
    public void saveCourse(@RequestBody Course course) {
        courseRepository.save(course);
    }

    @RequestMapping(method = RequestMethod.DELETE, value = "/courses/{id}")
    public void deleteCourse(@PathVariable BigInteger id) {
        courseRepository.deleteById(id);
    }
}
