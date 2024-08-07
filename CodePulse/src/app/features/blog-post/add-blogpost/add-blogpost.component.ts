import { Component, OnDestroy } from '@angular/core';
import { AddBlogpostRequest } from '../models/add-blogpost-request.model';
import { Subscription } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnDestroy {

  model: AddBlogpostRequest;
  private addBlogPostSubscription?: Subscription;

  constructor(private blogPostService: BlogPostService,
    private router: Router) {

    this.model = {
      title: '',
      shortDescription: '',
      content: '',
      featuredImageUrl: '',
      urlHandle: '',
      publishedDate: new Date(),
      author: '',
      isVisible: true
    }
  }

  onFormSubmit() {
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
