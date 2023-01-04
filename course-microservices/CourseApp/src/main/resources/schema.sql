DROP TABLE IF EXISTS course;

CREATE TABLE course (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(250) NOT NULL,
    author VARCHAR(250) NOT NULL
);