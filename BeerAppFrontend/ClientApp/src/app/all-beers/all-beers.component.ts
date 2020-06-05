import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-all-beers-component',
  templateUrl: './all-beers.component.html'
})
export class AllBeersComponent implements OnInit {

  constructor(private http: HttpClient) { }

  AllBeers
  ngOnInit() {
    this.getAllBeers()
  }

  getAllBeers() {
    this.http.get('https://api.punkapi.com/v2/beers?per_page=80').subscribe(data => this.AllBeers = data)
  }

  postToFavourites(beer) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post('https://localhost:44399/api/beers', beer.id, httpOptions).subscribe(() => console.log(beer.id))
  }
}
