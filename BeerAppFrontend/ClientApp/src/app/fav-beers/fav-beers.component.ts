import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-fav-beers-component',
  templateUrl: './fav-beers.component.html'
})
export class FavBeersComponent implements OnInit {

  constructor(private http: HttpClient) { }
  FavouriteBeerIds
  FavouriteBeers = []
  AllBeers
  ngOnInit() {
    this.getFavouriteBeers()
    this.getAllBeers()
  }

  getFavouriteBeers() {
    this.http.get('https://localhost:44399/api/beers').subscribe(data => this.FavouriteBeerIds = data)
  }

  getAllBeers(): any {
    fetch('https://api.punkapi.com/v2/beers')
      .then(data => data.json())
      .then(data => this.AllBeers = data)
      .then(() => this.setFavouriteBeers())
  }

  setFavouriteBeers() {

  
  }


}
