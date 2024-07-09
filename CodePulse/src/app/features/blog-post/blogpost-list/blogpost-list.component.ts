import { Component, OnInit } from '@angular/core';
import { BlogPost } from '../models/blogpost.model';
import { Observable } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';

@Component({
  selector: 'app-blogpost-list',
  templateUrl: './blogpost-list.component.html',
  styleUrls: ['./blogpost-list.component.css']
})
export class BlogpostListComponent implements OnInit {

  blogPosts$?: Observable<BlogPost[]>;

  constructor(private blogPostService: BlogPostService) {

  }

  ngOnInit(): void {
    this.blogPosts$ = this.blogPostService.getAllBlogPosts();
  }
}
