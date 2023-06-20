import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Item } from './models/items';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'WorkHubFrontEndServices';
  items : Item[] = [];

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get<Pagination<Item[]>>("https://localhost:5001/api/Menu/items?PageSize=10").subscribe({
      next : response => this.items = response.data,
      error : error => console.log(error),
      complete : () => {
        console.log("request completed");
        console.log("extra statement")
        
      }
    })
  }
}
