import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddBlogpostRequest } from '../models/add-blogpost-request.model';
import { Observable, Subscription } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';
import { Router } from '@angular/router';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { ImageService } from 'src/app/shared/components/image-selector/image.service';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit, OnDestroy {

  model: AddBlogpostRequest;
  categories$?: Observable<Category[]>;
  isImageSelectorVisible: boolean = false;
  private addBlogPostSubscription?: Subscription;
  imageSelectSubscription?: Subscription

  constructor(private blogPostService: BlogPostService,
    private router: Router,
    private categoryService: CategoryService,
    private imageService: ImageService) {

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

    this.imageSelectSubscription = this.imageService.onSelectImage()
      .subscribe({
        next: (selectedImage) => {
          this.model.featuredImageUrl = selectedImage.url;
          this.closeImageSelector();
        }
      });    
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

  openImageSelector(): void {
    this.isImageSelectorVisible = true;
  }

  closeImageSelector(): void {
    this.isImageSelectorVisible = false;
  }  

  ngOnDestroy(): void {
    this.addBlogPostSubscription?.unsubscribe();
    this.imageSelectSubscription?.unsubscribe();
  }   

}
