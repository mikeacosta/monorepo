import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  title: string = "Task Tracker";
  showAddTask: boolean = false;

  constructor() {}

  ngOnInit(): void {
    
  }

  toggleAddTask() {
    console.log('toggle');
    this.showAddTask = !this.showAddTask
  }
}
