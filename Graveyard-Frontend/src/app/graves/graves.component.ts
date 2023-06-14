import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';


import {Grave} from './graves';

@Component({
  selector: 'grv-graves',
  templateUrl: './graves.component.html',
  styleUrls: ['./graves.component.css']
})
export class GravesComponent implements OnInit {

  parentComponent: AppComponent;

  public getJsonValue: any;
  public postJsonValue: any;

  grave_list: Grave[] = [];

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
  }

  ngOnInit(): void {
    this.getMethod();
  }

  public getMethod() {

    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })

  this.http.get('https://graveyard.azurewebsites.net/api/grave/list/0', { headers: header }).subscribe(
    (data) => {
      console.log(data);
      this.getJsonValue = data.valueOf();
      this.grave_list = this.getJsonValue;
    }
  );
}

}
