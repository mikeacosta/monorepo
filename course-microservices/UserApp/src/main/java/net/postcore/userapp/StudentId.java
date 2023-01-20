package net.postcore.userapp;

import java.io.Serializable;

public class StudentId implements Serializable {

    private Integer studentId;
    private Integer courseId;

    public StudentId() {
    }

    public StudentId(Integer studentId, Integer courseId) {
        this.studentId = studentId;
        this.courseId = courseId;
    }

    public Integer getStudentId() {
        return studentId;
    }

    public void setStudentId(Integer studentId) {
        this.studentId = studentId;
    }

    public Integer getCourseId() {
        return courseId;
    }

    public void setCourseId(Integer courseId) {
        this.courseId = courseId;
    }
}
