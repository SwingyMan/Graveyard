import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import {HttpHandler,HttpClient,HttpHeaders} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { catchError,of } from 'rxjs';
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
  public checkForCoords(x:number,y:number){

    let n=0;
    var checked=true;
    if(x<=0||y<=0){
      console.log(false)
      return false;
    }
    for(var i=0;i<this.parentComponent.grave_list.length;i++){
        if(x==this.parentComponent.grave_list[i].x&&y==this.parentComponent.grave_list[i].y){
          checked=false;
        }
    }
    console.log(checked);
    return checked;
    
  }
  public addGrave() {
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    let body={
      x:this.x,
      y:this.y
    };
    if(this.checkForCoords(this.x,this.y)){
      this.http.post('https://graveyard.azurewebsites.net/api/grave/add', body, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd dodawania grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })
    ).subscribe(
      (data) =>{
          this.postJsonValue=data;
          console.log(this.postJsonValue)
      }

    )

    }
    console.log("X: "+this.x+" Y: "+this.y)}
}
