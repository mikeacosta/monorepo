package net.postcore.aerosense;

import net.postcore.aerosense.entity.Employee;
import net.postcore.aerosense.repository.EmployeeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class AerosenseApplication implements CommandLineRunner {

    public static void main(String[] args) {
        SpringApplication.run(AerosenseApplication.class, args);
        System.out.println("Aerosense app started...");
    }

    @Autowired
    private EmployeeRepository employeeRepository;

    @Override
    public void run(String... args) throws Exception {

        Employee employee1 = Employee.builder()
                .firstName("Joe")
                .lastName("Blow")
                .email("joe@blow.com")
                .build();

        Employee employee2 = Employee.builder()
                .firstName("Mickey")
                .lastName("Mouse")
                .email("mickey@disney.com")
                .build();

        Employee employee3 = Employee.builder()
                .firstName("Shrek")
                .lastName("Evergreen")
                .email("shrek@gmail.com")
                .build();

        employeeRepository.save(employee1);
        employeeRepository.save(employee2);
        employeeRepository.save(employee3);
    }
}
