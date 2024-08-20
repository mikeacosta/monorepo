import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlogPost } from '../models/blogpost.model';
import { BlogPostService } from '../services/blog-post.service';
import { Observable, Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { UpdateBlogpostRequest } from '../models/update-blogpost-request.model';

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
  getBlogPostSubscription?: Subscription;

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
        console.log(this.id);

        // get blog post from API
        if (this.id) {
          this.getBlogPostSubscription = this.blogPostService.getBlogPostById(this.id)
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
    //console.log(this.blogPost);
    if (this.blogPost && this.id) {
      var updateBlogpostRequest: UpdateBlogpostRequest = {
        title: this.blogPost.title,
        shortDescription: this.blogPost.shortDescription,
        content: this.blogPost.content,
        featuredImageUrl: this.blogPost.featuredImageUrl,
        urlHandle: this.blogPost.urlHandle,
        publishedDate: this.blogPost.publishedDate,
        author: this.blogPost.author,
        isVisible: this.blogPost.isVisible,
        categories: this.selectedCategories ?? []
      }; 

      this.editBlogPostSubscription = this.blogPostService.updateBlogPost(this.id, updateBlogpostRequest)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/blogposts');
        }
      });      
    }
   
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editBlogPostSubscription?.unsubscribe();
    this.getBlogPostSubscription?.unsubscribe();
  }
}
