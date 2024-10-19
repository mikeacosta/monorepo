import { Component, OnInit } from '@angular/core';
import { Employee } from './employee';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'employee-mgr-frontend';

  public employees: Employee[] = [];

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
}
