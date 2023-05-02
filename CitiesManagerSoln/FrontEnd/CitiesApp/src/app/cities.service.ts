import { Injectable } from "@angular/core";
import { City } from "./models/city";
import { HttpClient } from "@angular/common/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class CitiesService {

  constructor(private http: HttpClient) {
  }

  public getCities() {
    return this.http.get<City[]>('https://localhost:7223/api/cities').pipe();
  }
}