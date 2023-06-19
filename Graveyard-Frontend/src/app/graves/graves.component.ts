import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { Grave } from '../grave';
@Component({
  selector: 'grv-graves',
  templateUrl: './graves.component.html',
  styleUrls: ['./graves.component.css']
})
export class GravesComponent implements OnInit {

  parentComponent: AppComponent;

  public getJsonValue: any;
  public postJsonValue: any;

  grave_list: Grave[]

  iterator: number = 0;

  pages: number[] = [];
  page_len: number = 1;

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.grave_list = this.parentComponent.grave_list;
  }

  ngOnInit(): void {
    this.getPages();
    console.log(this.pages)
    this.getMethod();
  }

  public getPages() {

    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })

    for (let i = 0; i<10; i++) {

      this.http.get('https://graveyard.azurewebsites.net/api/grave/list/' + i, { headers: header }).subscribe(
        (data) => {
          this.getJsonValue = data.valueOf();
          this.page_len = this.getJsonValue.length;
          console.log(i+": "+this.page_len)
          if (this.page_len > 0 ) this.pages.push(i);
        }
      );
    }
  }

  public getMethod() {

    let i: number = 0

    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })

    this.http.get('https://graveyard.azurewebsites.net/api/grave/list/' + i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.grave_list = this.grave_list.concat(this.getJsonValue);
      }
    );

    this.parentComponent.grave_list = this.grave_list;
  }

}
