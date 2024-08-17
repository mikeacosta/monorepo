import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlogPost } from '../models/blogpost.model';
import { BlogPostService } from '../services/blog-post.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

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

  constructor(private route: ActivatedRoute, 
    private blogPostService: BlogPostService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id')

        if (this.id) {
          this.blogPostService.getBlogPostById(this.id)
            .subscribe({
              next: (response) => {
                this.blogPost = response;
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
