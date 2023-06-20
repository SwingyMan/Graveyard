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

  pages: number[] = [1,2,3,4,5,6,7,8,9,10];
  page_len: number = 1;

  is_pages_ready = false;

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.grave_list = this.parentComponent.grave_list;
  }

  ngOnInit(): void {
    this.getMethod(0);
  }

  public getMethod(i: number) {

    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })

    this.http.get('https://graveyard.azurewebsites.net/api/grave/list/' + i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.grave_list = this.getJsonValue;
      }
    );

    this.parentComponent.grave_list = this.grave_list;
  }

}
