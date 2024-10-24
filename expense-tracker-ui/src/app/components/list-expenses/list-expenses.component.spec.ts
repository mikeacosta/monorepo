import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListExpensesComponent } from './list-expenses.component';

describe('ListExpensesComponent', () => {
  let component: ListExpensesComponent;
  let fixture: ComponentFixture<ListExpensesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListExpensesComponent]
    });
    fixture = TestBed.createComponent(ListExpensesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
