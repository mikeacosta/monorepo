package net.postcore.ocpthings.funcinterfaces;

import net.postcore.ocpthings.funcinterfaces.FuncInterfaces.*;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.time.LocalTime;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.*;

@DisplayName("Functional interfaces actually *can* contain multiple abstract methods")
class FuncInterfacesTest {

    @Test
    void testFunctionalInterfaces() {
//        School school = () -> System.out.println("Classes are starting");

        Teacher teacher = () -> System.out.println("Teacher is teaching");

        Credential credential = () -> System.out.println("Printing credential");

//        JavaTeacher javaTeacher = version -> System.out.println("Teaching Java version " + version);

        KotlinTeacher kotlinTeacher = v -> System.out.printf("Teaching Kotlin version %s\n", v);

        Classroom classroom = localTime -> System.out.printf("Schedule class at %tT", localTime);
    }
}