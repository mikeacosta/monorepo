import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Expense } from 'src/app/models/expense.model';
import { ExpenseService } from 'src/app/services/expense.service';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.css']
})
export class AddExpenseComponent {

  expense = {} as Expense;

  constructor(private service: ExpenseService,
    private router: Router) { }

  saveExpense() {
    this.service.saveExpense(this.expense).subscribe(
      data => {
        console.log('response', data);
        this.router.navigateByUrl('/expenses');
      }
    )
  }
}
