import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Company } from '../models/company.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  apiUrl = 'https://localhost:7108/api/companies/'
  constructor(private http: HttpClient) { }

  get(): Observable<Company[]> {
    return this.http.get<Company[]>(this.apiUrl);
  }

  getById(id: number): Observable<Company> {
    return this.http.get<Company>(`${this.apiUrl}${id}`);
  }

  post(company: Company): Observable<Company> {
    return this.http.post<Company>(this.apiUrl, company);
  }  
}
