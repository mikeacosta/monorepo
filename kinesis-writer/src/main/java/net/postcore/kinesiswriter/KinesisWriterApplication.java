package net.postcore.kinesiswriter;

import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class KinesisWriterApplication implements CommandLineRunner {

    public static void main(String[] args) {
        SpringApplication.run(KinesisWriterApplication.class, args);
    }

    @Override
    public void run(String... args) throws Exception {

    }
}
