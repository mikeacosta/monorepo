import { Component, OnInit } from '@angular/core';
import { Task } from '../../Task';
import { NgFor } from '@angular/common';
import { TaskItemComponent } from "../task-item/task-item.component";
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-tasks',
  imports: [NgFor, TaskItemComponent],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private service: TaskService) {

  }

  ngOnInit(): void {
    this.service.getTasks().subscribe((tasks) => {
      this.tasks = tasks;
    });
  }
}
