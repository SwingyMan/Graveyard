import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import {HttpHandler,HttpClient,HttpHeaders} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { formatDate } from '@angular/common';
import { catchError,of } from 'rxjs';
import { Burried } from '../burried';
@Component({
  selector: 'grv-add-burried',
  templateUrl: './add-burried.component.html',
  styleUrls: ['./add-burried.component.css']
})
export class AddBurriedComponent {
  getJsonValue:any;
  parentComponent:AppComponent;
  pageToShowBurried:number=0;
  burried_list:Burried[]=[];
  name:string;
  lastname:string;
  birthdate:Date;
  deathdate:Date;
  burialDate:Date=new Date;
  selectedBurriedToEdit:number=0;
  editedBurriedID:number=0;
  editedName:string="";
  editedLastname:string="";
  editedBirthdate:Date=new Date;
  editedDeathdate:Date=new Date;
  editedBurialDate:Date=new Date;
  assignedBurriedID:number=0;
  assignedGraveID:number=0;
  assignedGravediggerID:number=0;
  selectedBurriedToDelete:number=0;
  deletedBurriedID:number=0;
  unassignedBurriedID:number=0;
  unassignedGraveID:number=0;
  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.name="";
    this.lastname="";
    this.birthdate=new Date;
    this.deathdate=new Date;
    this.getBurriedList();

  }
  public showAddBurried(){
    this.pageToShowBurried=0;
  }
  public showEditBurried(){
    this.pageToShowBurried=1;
    this.reload()
  }
  public showDeleteBurried(){
    this.pageToShowBurried=2;
    this.reload()
  }
  public showAssignBurried(){
    this.pageToShowBurried=3;
  }
  public showUnassignBurried(){
    this.pageToShowBurried=4;
  }
  public getBurriedList(){
    let i:number=0
    for(i=0;i<10;i++){
     this.fetchBurriedListFromEndpoint(i);
    }
      
      this.parentComponent.burried_list=this.burried_list; 
  }
  public fetchBurriedListFromEndpoint(i:number){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/burried/getAll/'+i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.burried_list=this.burried_list.concat(this.getJsonValue);
        console.log(data.valueOf())
        this.burried_list.sort((a, b) => (a.burriedId < b.burriedId ? -1 : 1));
      }
    );
  }
  public checkAddBurried(){
    if(this.name==""||this.lastname==""||this.birthdate.toString()==""||this.deathdate.toString()==""||this.burialDate.toString()==""){
      this.toastr.error('Niepoprawne dane','Puste pole');
      return false
    } //zwraca error podczas konwersji pustego Date ale działa
    return true;
  }
  public checkEditBurried(){
    if(this.editedBurriedID<1){
      this.toastr.error('Niepoprawne dane','ID musi być większe od 0');
      return false
    }
    if(this.editedName==""||this.editedLastname==""||this.editedBirthdate.toString()==""||this.editedDeathdate.toString()==""){
      this.toastr.error('Niepoprawne dane','Puste pole');
      return false
    } //zwraca error podczas konwersji pustego Date ale działa
    return true;
  }
  public checkAddBurriedToGrave(){
    if(this.assignedGraveID<1||this.assignedBurriedID<1||this.assignedGravediggerID<1){
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
      date_of_death:this.deathdate,
      burialDate:this.burialDate
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
  public insertDataToEdit(i:number){
    var burr=this.burried_list[i];
    this.editedBurriedID=burr.burriedId;
    this.editedName=burr.name;
    this.editedLastname=burr.lastname;
    this.editedBirthdate=burr.date_of_birth;
    this.editedDeathdate=burr.date_of_death;
    this.editedBurialDate=burr.burialDate;
  }
  public editBurried(){
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    let body={
      name:this.editedName,
      lastname:this.editedLastname,
      date_of_birth:this.editedBirthdate,
      date_of_death:this.editedDeathdate,
      burialDate:this.editedBurialDate
    };
    if(this.checkEditBurried()){
      this.http.patch('https://graveyard.azurewebsites.net/api/Burried/editBurried/'+this.editedBurriedID, body, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd dodawania pochowanego');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(data!=null){
            this.toastr.success("Nowe dane: "+this.editedName+" "+this.editedLastname+" "+this.editedBirthdate+" "+this.editedDeathdate+" "+this.burialDate,"Nieboszczyk zmodyfikowany")
            this.reload();
          }
        }
      )
    }
    console.log("Name: "+this.editedName+" Lastname: "+this.editedLastname+" Birthday: "+formatDate(this.editedBirthdate,"yyyy-MM-dd","en-EN")+" Deathday: "+formatDate(this.editedDeathdate,"yyyy-MM-dd","en-EN"))

  }
  
  public deleteBurried(){
    this.deletedBurriedID=this.burried_list[this.selectedBurriedToDelete].burriedId;
    console.log(this.deletedBurriedID);
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
            this.reload()
          }
        }
      )

    }
  }
  public assignBurriedToGrave(){
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    if(this.checkAddBurriedToGrave()){
      this.http.get('https://graveyard.azurewebsites.net/api/GraveBurried/addBurriedToGrave/'+this.assignedGraveID+"/"+this.assignedBurriedID+"/"+this.assignedGravediggerID,httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd przypisywania pochowanego do grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(data!=null){
            this.toastr.success("Pochowany o ID "+this.assignedBurriedID+" przypisany do grobu od ID "+this.assignedGraveID,"Pochowany przypisany do grobu")
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
  public reload(){
    this.burried_list=[];
    this.getBurriedList();
  }
}
