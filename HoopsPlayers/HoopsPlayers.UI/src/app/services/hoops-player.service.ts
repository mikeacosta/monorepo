import { Injectable } from '@angular/core';
import { HoopsPlayer } from '../models/hoops-player';

@Injectable({
  providedIn: 'root'
})
export class HoopsPlayerService {

  constructor() { }

  public getHoopsPlayers() : HoopsPlayer[] {
    let player = new HoopsPlayer();
    player.id = 1;
    player.firstName = "Stephen";
    player.lastName = "Curry"
    player.team = "Warriors";
    player.country = "USA";

    return [player];
  }
}
