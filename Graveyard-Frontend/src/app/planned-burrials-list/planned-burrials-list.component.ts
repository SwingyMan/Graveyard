import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import {HttpHandler,HttpClient,HttpHeaders} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { formatDate } from '@angular/common';
import { catchError,of } from 'rxjs';
import { Burried } from '../burried';
@Component({
  selector: 'grv-planned-burrials-list',
  templateUrl: './planned-burrials-list.component.html',
  styleUrls: ['./planned-burrials-list.component.css']
})
export class PlannedBurrialsListComponent {
  getJsonValue:any;
  parentComponent:AppComponent;
  
  plannedToBeBurried?:Burried[]

  public constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService){
    this.parentComponent = appComponent;
    this.getPlannedBurials();
  }
  public getPlannedBurials(){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/Burried/GetNewBurried', { headers: header }).subscribe(
      (data) => {
        this.getJsonValue=data.valueOf()
        this.plannedToBeBurried=this.getJsonValue;
        console.log(data.valueOf())
      }
    );
  }
}
