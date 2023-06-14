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
  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.x=0;
    this.y=0;
  }
  
  public addGrave() {console.log("X: "+this.x+" Y: "+this.y)}
}
