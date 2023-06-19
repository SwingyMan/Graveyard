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

  grave_list:Grave[]
  iterator:number
  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.grave_list=this.parentComponent.grave_list;
    this.iterator=0;
    this.getMethod();
 
  }

  ngOnInit(): void {
    
  }

  public getMethod() {
    let i:number=0
    for(i=0;i<10;i++){
      this.fetchGraveListFromEndpoint(i);
    }
      this.parentComponent.grave_list=this.grave_list; 
  }
  public fetchGraveListFromEndpoint(i:number){
    console.log(i)
    var endChecking=false;
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/grave/list/'+i, { headers: header }).subscribe(
      (data) => {
        console.log(data);
        this.getJsonValue = data.valueOf();
        console.log(this.getJsonValue.length)
        
        this.grave_list=this.grave_list.concat(this.getJsonValue);
      }
    );
  }
}
