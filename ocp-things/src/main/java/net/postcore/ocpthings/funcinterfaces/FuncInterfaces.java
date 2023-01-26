package net.postcore.ocpthings.funcinterfaces;

import java.time.LocalTime;

public class FuncInterfaces {

}

// must be an interface, not a class
//@FunctionalInterface
abstract class School {
    public abstract void startClasses();
}

@FunctionalInterface
interface Teacher {
    void teach();
}

// one abstract method, the other is a default method w/implementation
@FunctionalInterface
interface Credential {
    void print();
    default void renew() {
        System.out.println("Renew credential");
    }
}

// adds another abstract method, so not a functional interface
//@FunctionalInterface
interface JavaTeacher extends Teacher {
    void teachVersion(int version);
}

// overrides existing teach() method, so only one abstract method
@FunctionalInterface
interface KotlinTeacher extends Teacher {
    default void teach() {
        System.out.println("Teaching Kotlin");
    }
    void teachVersion(String version);
}

// equals() and toString() are inherited from Object, are not abstract methods
@FunctionalInterface
interface Classroom {
    void schedule(LocalTime time);
    boolean equals(Object otherClassroom);
    String toString();
}