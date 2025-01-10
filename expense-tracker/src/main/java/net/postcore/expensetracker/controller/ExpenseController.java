package net.postcore.expensetracker.controller;

import net.postcore.expensetracker.model.Expense;
import net.postcore.expensetracker.service.ExpenseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@CrossOrigin("*")
@RestController
@RequestMapping("/api/v1")
public class ExpenseController {

    @Autowired
    ExpenseService expenseService;

    @GetMapping("/expenses")
    public ResponseEntity<List<Expense>> getAllExpenses() {
        List<Expense> expenses = expenseService.findAll();
        return new ResponseEntity<List<Expense>>(expenses, HttpStatus.OK);
    }

    @PostMapping("/expenses")
    public ResponseEntity<Expense> createExpense(@RequestBody Expense expense) {
        var newExpense = expenseService.save(expense);
        return new ResponseEntity<>(newExpense, HttpStatus.CREATED);
    }

    @GetMapping("/expenses/{id}")
    public ResponseEntity<Expense> getExpense(@PathVariable("id") Long id) {
        var expense = expenseService.findById(id);
        return expense != null
                ? new ResponseEntity<>(expense, HttpStatus.OK)
                : new ResponseEntity<>(HttpStatus.NOT_FOUND);
    }
}
