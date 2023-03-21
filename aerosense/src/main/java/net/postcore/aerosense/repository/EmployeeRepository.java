package net.postcore.aerosense.repository;

import net.postcore.aerosense.entity.Employee;
import org.springframework.data.jpa.repository.JpaRepository;

public interface EmployeeRepository extends JpaRepository<Employee, Long> {
}
