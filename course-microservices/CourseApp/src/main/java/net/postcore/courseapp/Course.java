package net.postcore.courseapp;

public class Course {
    private String courseId;
    private String courseName;
    private String author;

    public Course(String courseId, String courseName, String author) {
        this.courseId = courseId;
        this.courseName = courseName;
        this.author = author;
    }

    public String getCourseId() {
        return courseId;
    }

    public void setCourseId(String courseId) {
        this.courseId = courseId;
    }

    public String getCourseName() {
        return courseName;
    }

    public void setCourseName(String courseName) {
        this.courseName = courseName;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }
}
