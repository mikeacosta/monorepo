import { Component } from '@angular/core';
import { CompanyService } from '../../../services/company.service';
import { Company } from '../../../models/company.model';

@Component({
  selector: 'app-company-list',
  standalone: false,
  
  templateUrl: './company-list.component.html',
  styleUrl: './company-list.component.css'
})
export class CompanyListComponent {
  public companies!: Company[];
  
  constructor(private companyService: CompanyService) {
    this.companyService.get().subscribe(
      data => {
        console.log('companies: ', data);
        this.companies = data;
      })   
  }

}
