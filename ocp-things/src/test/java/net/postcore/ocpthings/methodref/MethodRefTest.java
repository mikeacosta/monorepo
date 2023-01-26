package net.postcore.ocpthings.methodref;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.util.function.Supplier;

import static org.assertj.core.api.Assertions.assertThat;

@DisplayName("Passing arguments to method references \uD83E\uDD2F")
class MethodRefTest {

    @Test
    @DisplayName("Schools created through various constructors should have the right properties.")
    void createSchoolsUsingConstructor() {
        final School randomSchool = new School();
        assertRandomSchool(randomSchool);

        final School tinyClassroom = new School("Classroom");
        assertTinyClassroom(tinyClassroom);

        final School largeRandomSchool = new School(200);
        assertLargeRandomSchool(largeRandomSchool);

        final School regularClassroom = new School("Classroom", 30);
        assertRegularClassroom(regularClassroom);
    }

    @Test
    @DisplayName("Schools created through lambda expressions should have the right properties.")
    void createSchoolUsingLambdas() {
        final Supplier<School> randomSchoolSupplier = () -> new School();
        assertRandomSchool(randomSchoolSupplier.get());

        final Supplier<School> tinyClassroomSupplier = () -> new School("Classroom");
        assertTinyClassroom(tinyClassroomSupplier.get());

        final Supplier<School> largeRandomSchoolSupplier = () -> new School(200);
        assertLargeRandomSchool(largeRandomSchoolSupplier.get());

        final Supplier<School> regularClassroomSupplier = () -> new School("Classroom", 30);
        assertRegularClassroom(regularClassroomSupplier.get());
    }

    @Test
    @DisplayName("Schools created through method references should have the right properties.")
    void createSchoolUsingMethodReferences() {
        /*
        "Get me the constructor reference of the constructor that does not take any argument"
         */
        final Supplier<School> randomSchoolFunction = School::new;
        assertRandomSchool(randomSchoolFunction.get());

        /*
        "Get me the constructor reference of the constructor that takes a String argument"
         */
        final Supplier<School> tinyClassroomSchoolFunction = School::new;
        assertTinyClassroom(tinyClassroomSchoolFunction.get());

        /*
        "Get me the constructor reference of the constructor that takes an Integer argument"
         */
        final Supplier<School> largeRandomSchoolFunction = School::new;
        assertLargeRandomSchool(largeRandomSchoolFunction.get());

        /*
        "Get me the constructor reference of the constructor that takes a String and Integer argument"
         */
        final Supplier<School> regularClassroomFunction = School::new;
        assertRegularClassroom(regularClassroomFunction.get());
    }

    private void assertRandomSchool(School randomSchool) {
        assertThat(randomSchool.getName()).isEqualTo("Random school");
        assertThat(randomSchool.getCapacity()).isEqualTo(0);
    }

    private void assertTinyClassroom(School tinyClassroom) {
        assertThat(tinyClassroom.getName()).isEqualTo("Classroom");
        assertThat(tinyClassroom.getCapacity()).isEqualTo(0);
    }

    private void assertLargeRandomSchool(School largeRandomSchool) {
        assertThat(largeRandomSchool.getName()).isEqualTo("Random school");
        assertThat(largeRandomSchool.getCapacity()).isEqualTo(200);
    }

    private void assertRegularClassroom(School regularClassroom) {
        assertThat(regularClassroom.getName()).isEqualTo("Classroom");
        assertThat(regularClassroom.getCapacity()).isEqualTo(30);
    }
}