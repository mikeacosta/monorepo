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
  playerToEdit?: HoopsPlayer;

  constructor(private hoopsPlayerService: HoopsPlayerService) {}

  ngOnInit() : void {
    this.hoopsPlayerService
      .getHoopsPlayers()
      .subscribe((result: HoopsPlayer[]) => (this.players = result));
  }

  initNewPlayer() {
    this.playerToEdit = new HoopsPlayer();
  }

  editPlayer(player: HoopsPlayer) {
    this.playerToEdit = player;
  }
}
