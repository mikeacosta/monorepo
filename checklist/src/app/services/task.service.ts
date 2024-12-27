import { Injectable } from '@angular/core';
import { Task } from '../Task';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://200g6jznzc.execute-api.us-west-2.amazonaws.com/Prod/checklist';

  constructor(private httpClient: HttpClient) { }

  getTasks(): Observable<Task[]> {
    return this.httpClient.get<Task[]>(this.apiUrl);
  }

  deleteTask(task: Task): Observable<Task> {
    const url = `${this.apiUrl}/${task.id}`;
    return this.httpClient.delete<Task>(url);
  }  

  addTask(task: Task): Observable<Task> {
    return this.httpClient.post<Task>(this.apiUrl, task, httpOptions);
  }   

  updateTaskReminder(task: Task): Observable<Task> {
    const url = `${this.apiUrl}/${task.id}`;
    var taskForUpdate = {
      text: task.text,
      day: task.day,
      reminder: task.reminder
    };
    return this.httpClient.put<Task>(url, taskForUpdate, httpOptions);
  }  
}
