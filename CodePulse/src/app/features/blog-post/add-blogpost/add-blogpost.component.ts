import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddBlogpostRequest } from '../models/add-blogpost-request.model';
import { Observable, Subscription } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';
import { Router } from '@angular/router';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit, OnDestroy {

  model: AddBlogpostRequest;
  categories$?: Observable<Category[]>;
  private addBlogPostSubscription?: Subscription;

  constructor(private blogPostService: BlogPostService,
    private router: Router,
    private categoryService: CategoryService) {

    this.model = {
      title: '',
      shortDescription: '',
      content: '',
      featuredImageUrl: '',
      urlHandle: '',
      publishedDate: new Date(),
      author: '',
      isVisible: true,
      categories: []
    }
  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();
  }  

  onFormSubmit() {
    console.log(this.model);
    this.addBlogPostSubscription = this.blogPostService.createBlogPost(this.model)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/blogposts');
        }
      });
  } 

  ngOnDestroy(): void {
    this.addBlogPostSubscription?.unsubscribe();
  }   

}
