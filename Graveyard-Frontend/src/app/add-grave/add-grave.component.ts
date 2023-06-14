import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import {HttpHandler,HttpClient,HttpHeaders} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'grv-add-grave',
  templateUrl: './add-grave.component.html',
  styleUrls: ['./add-grave.component.css']
})
export class AddGraveComponent {
  parentComponent:AppComponent;
  x:number;
  y:number;
  public getJsonValue: any;
  public postJsonValue: any;
  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.x=0;
    this.y=0;
  }
  public checkForCoords(){
    const header=new HttpHeaders({
        "Content-Type":"application/json"
      });
    let n=0;
    //this.http.get()
  }
  public addGrave() {
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
      })
    };
    let body={
      x:this.x,
      y:this.y
    };

    console.log("X: "+this.x+" Y: "+this.y)}
}
