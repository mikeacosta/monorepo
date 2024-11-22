import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompaniesRoutingModule } from './companies-routing.module';
import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyCreateComponent } from './company-create/company-create.component';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import { CompanyEditComponent } from './company-edit/company-edit.component';
import { MatTableModule } from '@angular/material/table'; 
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    CompanyListComponent,
    CompanyCreateComponent,
    CompanyDetailsComponent,
    CompanyEditComponent
  ],
  imports: [
    CommonModule,
    CompaniesRoutingModule,
    MatTableModule,
    MatButtonModule
  ]
})
export class CompaniesModule { }
