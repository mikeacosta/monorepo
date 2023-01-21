package net.postcore.userapp;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class StudentController {

    @Autowired
    private StudentRepository studentRepository;

    @RequestMapping("/")
    public List<Student> getStudents() {
        return studentRepository.findAll();
    }

    @RequestMapping("/{id}")
    public List<Student> getByCoursesId(@PathVariable("id") Integer courseId) {
        return studentRepository.findByCourseId(courseId);
    }
}
