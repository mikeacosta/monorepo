import { Component, EventEmitter, Output } from '@angular/core';
import { Task } from '../../Task';
import { Subscription } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UiService } from '../../services/ui.service';

@Component({
  selector: 'app-add-task',
  imports: [FormsModule, CommonModule],
  templateUrl: './add-task.component.html',
  styleUrl: './add-task.component.css'
})
export class AddTaskComponent {
  @Output() onAddTask: EventEmitter<Task> = new EventEmitter();
  text!: string;
  day!: string;
  reminder: boolean = false;
  showAddTask: boolean | undefined;
  subscription: Subscription;

  constructor(private uiService: UiService) {
    this.subscription = this.uiService
      .onToggle()
      .subscribe((value) => this.showAddTask = value);    
  }


  ngOnDestroy() {
    this.subscription.unsubscribe();   
  }

  onSubmit() {
    if (!this.text) {
      alert('Please add a task!');
      return;
    }

    const newTask: Task = {
      text: this.text,
      day: this.day,
      reminder: this.reminder,
    };
    
    this.onAddTask.emit(newTask);

    this.text = '';
    this.day = '';
    this.reminder = false;
  }
}
