import { Component, OnInit } from '@angular/core';
import { Employee } from './employee';
import { EmployeeService } from './employee.service';
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'employee-mgr-frontend';
  employees: Employee[] = [];
  editEmployee: Employee | undefined;
  deleteEmployee: Employee | undefined;

  constructor(private service: EmployeeService){}

  ngOnInit(): void {
    this.getEmployees();
  }

  public getEmployees(): void {
    this.service.getEmployees().subscribe(
      response => {
        this.employees = response;
      },
      error => {
        console.log(error.message);
      }
    );
  }

  public onOpenModal(employee: Employee | null, mode: string) {
    console.log(mode);
    const container = document.getElementById('main-container');
    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-toggle', 'modal');

    if (mode === 'add')
      button.setAttribute('data-target', '#addEmployeeModal');

    if (mode === 'edit') {
      button.setAttribute('data-target', '#updateEmployeeModal');
      if (employee)
        this.editEmployee = employee;
    }

    if (mode === 'delete') {
      button.setAttribute('data-target', '#deleteEmployeeModal'); 
      if (employee)
        this.deleteEmployee = employee;
    }

    container?.appendChild(button);
    button.click();
  }

  public onAddEmployee(addForm: NgForm): void {
    document.getElementById('add-employee-form')?.click();
    this.service.addEmployee(addForm.value).subscribe(
      (response: Employee) => {
        console.log(response);
        this.getEmployees();
        addForm.reset();
      },
      (error: HttpErrorResponse) => {
        console.log(error);
        addForm.reset();
      }
    );
  }

  public onUpdateEmployee(employee: Employee): void {
    this.service.updateEmployee(employee).subscribe(
      (response: Employee) => {
        console.log(response);
        this.getEmployees();
      },
      (error: HttpErrorResponse) => {
        console.log(error);
      }
    );
  }  

  public onDeleteEmployee(id: number): void {
    this.service.deleteEmployee(id).subscribe(
      (response: void) => {
        this.getEmployees();
      },
      (error: HttpErrorResponse) => {
        console.log(error);
      }
    );
  }
}
