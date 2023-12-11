import { Component, Input } from '@angular/core';
import { HoopsPlayer } from 'src/app/models/hoops-player';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent {
  @Input() player?: HoopsPlayer;

  constructor() { 

  }

  ngOnInit(): void {

  }

  updatePlayer(player: HoopsPlayer) {

  }

  deletePlayer(player: HoopsPlayer) {

  }

  createPlayer(player: HoopsPlayer) {

  }
}
