import { Component } from '@angular/core';
import { HoopsPlayer } from './models/hoops-player';
import { HoopsPlayerService } from './services/hoops-player.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HoopsPlayers.UI';
  players: HoopsPlayer[] = [];

  constructor(private hoopsPlayerService: HoopsPlayerService) {}

  ngOnInit() : void {
    this.players = this.hoopsPlayerService.getHoopsPlayers();
    console.log(this.players);
  }
}
