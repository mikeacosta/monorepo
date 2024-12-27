import { Component, OnInit } from '@angular/core';
import { Task } from '../../Task';
import { NgFor } from '@angular/common';
import { TaskItemComponent } from "../task-item/task-item.component";
import { TaskService } from '../../services/task.service';
import { AddTaskComponent } from '../../components/add-task/add-task.component';

@Component({
  selector: 'app-tasks',
  imports: [NgFor, TaskItemComponent, AddTaskComponent],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private service: TaskService) {}

  ngOnInit(): void {
    this.service.getTasks().subscribe((tasks) => {
      this.tasks = tasks;
    });
  }

  deleteTask(task: Task) {
    this.service
      .deleteTask(task)
      .subscribe(
        () => (this.tasks = this.tasks.filter((t) => t.id !== task.id))
      );
  }

  toggleReminder(task: Task) {
    task.reminder = !task.reminder;
    this.service.updateTaskReminder(task).subscribe();
  }

  addTask(task: Task) {
    var maxId = Math.max(...this.tasks.map(t => t.id!), 0);
    task.id = maxId + 1;
    this.service.addTask(task).subscribe();
    this.tasks.push(task);
  }  
}
