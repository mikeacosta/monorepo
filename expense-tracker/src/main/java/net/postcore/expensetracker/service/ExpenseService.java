package net.postcore.expensetracker.service;

import net.postcore.expensetracker.model.Expense;

import java.util.List;

public interface ExpenseService {

    List<Expense> findAll();
}
