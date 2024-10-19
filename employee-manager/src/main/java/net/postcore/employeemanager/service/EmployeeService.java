package net.postcore.employeemanager.service;

import net.postcore.employeemanager.exception.UserNotFoundException;
import net.postcore.employeemanager.model.Employee;
import net.postcore.employeemanager.repo.EmployeeRepo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.UUID;

@Service
public class EmployeeService {
    private final EmployeeRepo employeeRepo;

    @Autowired
    public EmployeeService(EmployeeRepo employeeRepo) {
        this.employeeRepo = employeeRepo;
    }

    public Employee addEmployee(Employee employee) {
        employee.setEmployeeCode(UUID.randomUUID().toString());
        return employeeRepo.save(employee);
    }

    public List<Employee> getAllEmployees() {
        return employeeRepo.findAll();
    }

    public Employee getEmployee(Long id) {
        return employeeRepo.findById(id).orElse(null);
    }

    public Employee updateEmployee(Employee employee) {
        return employeeRepo.save(employee);
    }

    public void deleteEmployee(Long id) {
        employeeRepo.deleteById(id);
    }
}
