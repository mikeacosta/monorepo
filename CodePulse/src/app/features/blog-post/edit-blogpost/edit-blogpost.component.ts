import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlogPost } from '../models/blogpost.model';
import { BlogPostService } from '../services/blog-post.service';
import { Observable, Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.css']
})
export class EditBlogpostComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription?: Subscription;
  editBlogPostSubscription?: Subscription;
  blogPost?: BlogPost;
  categories$?: Observable<Category[]>;
  selectedCategories?: string[];

  constructor(private route: ActivatedRoute, 
    private blogPostService: BlogPostService,
    private router: Router,
    private categoryService: CategoryService) {

  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();

    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id')

        // get blog post from API
        if (this.id) {
          this.blogPostService.getBlogPostById(this.id)
            .subscribe({
              next: (response) => {
                this.blogPost = response;
                this.selectedCategories = response.categories.map(c => c.id);
              }
            });
        }
      }
    });
  }

  onFormSubmit(): void {
    console.log(this.blogPost);
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editBlogPostSubscription?.unsubscribe();
  }
}
