import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import {HttpHandler,HttpClient,HttpHeaders} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { formatDate } from '@angular/common';
import { catchError,of } from 'rxjs';
@Component({
  selector: 'grv-add-burried',
  templateUrl: './add-burried.component.html',
  styleUrls: ['./add-burried.component.css']
})
export class AddBurriedComponent {

  parentComponent:AppComponent;
  pageToShowBurried:number=0;
  name:string;
  lastname:string;
  birthdate:Date;
  deathdate:Date;
  datepipe:DatePipe=new DatePipe("pl-PL")
  burriedID:number=0;
  graveID:number=0;
  gravediggerID:number=0;
  deletedBurriedID:number=0;
  unassignedBurriedID:number=0;
  unassignedGraveID:number=0;
  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.name="";
    this.lastname="";
    this.birthdate=new Date;
    this.deathdate=new Date;

  }
  public showAddBurried(){
    this.pageToShowBurried=0;
  }
  public showEditBurried(){
    this.pageToShowBurried=1;
  }
  public showDeleteBurried(){
    this.pageToShowBurried=2;
  }
  public showAssignBurried(){
    this.pageToShowBurried=3;
  }
  public showUnassignBurried(){
    this.pageToShowBurried=4;
  }


  public checkAddBurried(){
    if(this.name==""||this.lastname==""||this.birthdate.toString()==""||this.deathdate.toString()==""){
      this.toastr.error('Niepoprawne dane','Puste pole');
      return false
    } //zwraca error podczas konwersji pustego Date ale działa
    return true;
  }
  public checkAddBurriedToGrave(){
    if(this.graveID<1||this.burriedID<1||this.gravediggerID<1){
      this.toastr.error('Niepoprawne dane','ID musi być większe od 0');
      return false;
    }
    //jeszcze sprawdzanie endpointów getbyID
    return true;
  }
  public addBurried() {
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    let body={
      name:this.name,
      lastname:this.lastname,
      date_of_birth:this.birthdate,
      date_of_death:this.deathdate
    };
    if(this.checkAddBurried()){
      this.http.post('https://graveyard.azurewebsites.net/api/Burried/addBurried', body, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd dodawania pochowanego');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(data!=null){
            this.toastr.success("Nowy pochowany: "+this.name+" "+this.lastname,"Pochowany dodany")
          }
        }
      )
    }
    console.log("Name: "+this.name+" Lastname: "+this.lastname+" Birthday: "+formatDate(this.birthdate,"yyyy-MM-dd","en-EN")+" Deathday: "+formatDate(this.deathdate,"yyyy-MM-dd","en-EN"))
  }
  public assignBurriedToGrave(){
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    if(this.checkAddBurriedToGrave()){
      this.http.get('https://graveyard.azurewebsites.net/api/GraveBurried/addBurriedToGrave/'+this.graveID+"/"+this.burriedID+"/"+this.gravediggerID,httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd przypisywania pochowanego do grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(data!=null){
            this.toastr.success("Pochowany o ID "+this.burriedID+" przypisany do grobu od ID "+this.graveID,"Pochowany przypisany do grobu")
          }
        }
      )
    }
  }
  public deleteBurried(){
    var noError=true;
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    if(this.deletedBurriedID<1){
      this.toastr.error('Niepoprawne dane','ID musi być większe od 0');
      return;
    }//jeszcze po endpoincie sprawdzić czy pochowany o ID wgl istnieje
    else{
      this.http.delete('https://graveyard.azurewebsites.net/api/Burried/deleteByID/'+this.deletedBurriedID,httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        noError=false;
        this.toastr.error('Wystąpił błąd','Błąd usuwania pochowanego');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(noError){
            this.toastr.success("Pochowany o ID "+this.deletedBurriedID+" usunięty","Pochowany usunięty")
          }
        }
      )
    }
  }
  public unassignBurriedToGrave(){
    var noError=true;
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    if(this.unassignedBurriedID<1||this.unassignedGraveID<1){
      this.toastr.error('Niepoprawne dane','ID musi być większe od 0');
      return;
    }//jeszcze po endpoincie sprawdzić czy pochowany o ID wgl istnieje
    else{
      this.http.delete('https://graveyard.azurewebsites.net/api/GraveBurried/removeBurriedFromGrave/'+this.unassignedGraveID+"/"+this.unassignedBurriedID,httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        noError=false;
        this.toastr.error('Wystąpił błąd','Błąd wypisywania pochowanego z grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(noError){
            this.toastr.success("Pochowany o ID "+this.unassignedBurriedID+" wypisany z grobu o ID "+this.unassignedGraveID,"Pochowany wypisany z grobu")
          }
        }
      )
    }
  }
}
