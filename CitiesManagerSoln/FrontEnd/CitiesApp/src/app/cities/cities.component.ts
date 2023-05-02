import { Component } from '@angular/core';
import { City } from '../models/city';
import { CitiesService } from '../cities.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent {
  cities: City[] = [];

  constructor(public citiesService: CitiesService) { }

  ngOnInit() {
    this.citiesService.getCities().subscribe(cities => {
      this.cities = cities;
    })
  }

}
