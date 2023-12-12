import { Component, EventEmitter, Input, Output } from '@angular/core';
import { HoopsPlayer } from 'src/app/models/hoops-player';
import { HoopsPlayerService } from 'src/app/services/hoops-player.service';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent {
  @Input() player?: HoopsPlayer;
  @Output() playersUpdated = new EventEmitter<HoopsPlayer[]>();

  constructor(private hoopsPlayerService: HoopsPlayerService) { 
  }

  ngOnInit(): void {

  }

  updatePlayer(player: HoopsPlayer) {
    this.hoopsPlayerService
      .updatePlayer(player)
      .subscribe((players: HoopsPlayer[]) => this.playersUpdated.emit(players));
  }

  deletePlayer(player: HoopsPlayer) {
    this.hoopsPlayerService
      .deletePlayer(player)
      .subscribe((players: HoopsPlayer[]) => this.playersUpdated.emit(players));
  }

  createPlayer(player: HoopsPlayer) {
    this.hoopsPlayerService
      .createPlayer(player)
      .subscribe((players: HoopsPlayer[]) => this.playersUpdated.emit(players));
  }
}
