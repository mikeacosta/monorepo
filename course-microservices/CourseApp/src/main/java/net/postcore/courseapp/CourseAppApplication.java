package net.postcore.courseapp;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class CourseAppApplication {

    public static void main(String[] args) {

        SpringApplication.run(CourseAppApplication.class, args);
        System.out.println("CourseApp is running...");
    }

}
