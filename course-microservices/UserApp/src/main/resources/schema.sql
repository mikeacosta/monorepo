DROP TABLE IF EXISTS student;

CREATE TABLE student (
                        student_id INT NOT NULL,
                        course_id INT NOT NULL,
                        username VARCHAR(250) NOT NULL,
                        PRIMARY KEY (student_id, course_id)
);