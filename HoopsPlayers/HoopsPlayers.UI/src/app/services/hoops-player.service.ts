import { Injectable } from '@angular/core';
import { HoopsPlayer } from '../models/hoops-player';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class HoopsPlayerService {
  private url = "HoopsPlayers";
  constructor(private http: HttpClient) { }

  public getHoopsPlayers() : Observable<HoopsPlayer[]> {
    return this.http.get<HoopsPlayer[]>(`${environment.apiUrl}/${this.url}`)
  }
}
