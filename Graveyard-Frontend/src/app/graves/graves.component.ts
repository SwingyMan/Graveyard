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
  }

  ngOnInit(): void {
    this.getMethod();
  }

  public getMethod() {

    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    var temp:Grave[]=[]
    this.iterator=0
      this.http.get('https://graveyard.azurewebsites.net/api/grave/list/'+this.iterator, { headers: header }).subscribe(
        (data) => {
          this.getJsonValue = data.valueOf();
          var t=this.getJsonValue;
          console.log(t)
            temp.push(...t)
        }

  );
  this.parentComponent.grave_list=temp;
  this.grave_list=this.parentComponent.grave_list;
      
}

}
