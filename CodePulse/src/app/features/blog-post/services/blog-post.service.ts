import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddBlogpostRequest } from '../models/add-blogpost-request.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {

  constructor(private http: HttpClient) { }

  createBlogPost(model: AddBlogpostRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/blogposts`, model);
  }
}
