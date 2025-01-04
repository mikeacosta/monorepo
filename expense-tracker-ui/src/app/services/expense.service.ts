import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Expense } from '../models/expense.model';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  private baseUrl: string = 'http://localhost:8080/api/v1';

  constructor(private httpClient: HttpClient) { }

  getExpenses(): Observable<Expense[]> {
    return this.httpClient.get<Expense[]>(`${this.baseUrl}/expenses`)
      .pipe(map(response => response));
  }  

  saveExpense(expense: Expense): Observable<Expense> {
    return this.httpClient.post<Expense>(`${this.baseUrl}/expenses`, expense);
  }
}
