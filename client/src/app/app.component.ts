import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Today in History';
  posts: any;
  
  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get("http://localhost:5235/HistEvents").subscribe(
      response => { 
        this.posts = response;
        for (let i = 0; i < this.posts.length; i++) {
          let DATE = new Date(this.posts[i].date);
          this.posts[i].date = `${DATE.getMonth()}-${DATE.getDate()}-${DATE.getFullYear()}`;
          let datetime_today = new Date();
          let month = DATE.getMonth() == datetime_today.getMonth();
          let day = DATE.getDate() == datetime_today.getDate();
          if (!month || !day) {
            this.posts[i] = null;
          }
        }
        this.posts = this.posts.filter(x=>x); // remove any empty

      },
      error => { console.log(error); }
    );
  }
}
