export interface UpdateBlogpostRequest {
  title: string;
  shortDescription: string;
  content: string;
  featuredImageUrl: string;
  urlHandle: string;
  publishedDate: Date;
  author: String;
  isVisible: boolean;
  categories: string[];
}