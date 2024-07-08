import { Component } from '@angular/core';
import { AddBlogpostRequest } from '../models/add-blogpost-request.model';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent {

  model: AddBlogpostRequest;
  
  constructor() {

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
    console.log(this.model);
  }  

}
