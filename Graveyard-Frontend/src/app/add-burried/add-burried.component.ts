import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import {HttpHandler,HttpClient,HttpHeaders} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { formatDate } from '@angular/common';
import { catchError,of } from 'rxjs';
import { Burried } from '../burried';
import { Gravedigger } from '../gravedigger';
import { Grave } from '../grave';
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
  grave_list:Grave[]=[];
  gravedigger_list:Gravedigger[]=[];

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

  selectedBurriedToAssign:number=0;
  selectedGraveToAssign:number=0;
  selectedGravediggerToAssign:number=0;

  assignedBurriedID:number=0;
  assignedGraveID:number=0;
  assignedGravediggerID:number=0;

  selectedBurriedToDelete:number=0;
  deletedBurriedID:number=0;

  unassignedBurriedID:number=0;
  unassignedGraveID:number=0;

  assigningPart:number=1;
  unassigningPart:number=1;

  selectedBurriedToUnassign:number=-1;
  selectedGraveToUnassign:number=-1;
  
  listFromGrave:Burried[]=[]

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.name="";
    this.lastname="";
    this.birthdate=new Date;
    this.deathdate=new Date;
    this.getBurriedList();
    this.getGraveList();
    this.getGravediggerList();

  }

  //changing subsites
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
    this.assigningPart=1;
  }
  public showUnassignBurried(){
    this.pageToShowBurried=4;
    this.unassigningPart=1;
  }
  public changeAssigningPart(){
    this.assigningPart+=1;
    if(this.assigningPart>3){this.assigningPart=1;}
  }
  public changeUnassigningPart(){
    this.unassigningPart+=1;
    if(this.assigningPart>2){this.assigningPart=1;}
    this.fetchBurriedFromAGrave(this.grave_list[this.selectedGraveToUnassign].graveId);
  }
  //getting data from/to endpoints
  public fetchBurriedFromAGrave(i:number){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/GraveBurried/getBurriedFromGrave/'+i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.listFromGrave=this.getJsonValue;
        console.log(data.valueOf())
      }
    );
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
  public getGraveList(){
    let i:number=0
    for(i=0;i<10;i++){
     this.fetchGraveListFromEndpoint(i);
    }
      
      this.parentComponent.grave_list=this.grave_list; 
  }
  public fetchGraveListFromEndpoint(i:number){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/grave/list/'+i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.grave_list=this.grave_list.concat(this.getJsonValue);
        console.log(data.valueOf())
        this.grave_list.sort((a, b) => (a.graveId < b.graveId ? -1 : 1));
      }
    );
  }
  public getGravediggerList() {
    let i:number=0
    for(i=0;i<10;i++){
     this.fetchGravediggerListFromEndpoint(i);
    }
      this.parentComponent.gravedigger_list=this.gravedigger_list; 
  }
  public fetchGravediggerListFromEndpoint(i:number){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/Gravedigger/listGravediggers/'+i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.gravedigger_list=this.gravedigger_list.concat(this.getJsonValue);
        console.log(data.valueOf())
        this.gravedigger_list.sort((a, b) => (a.gravediggerId < b.gravediggerId ? -1 : 1));
      }
    );
  }
  public checkAddBurried(){
    if(this.name==""||this.lastname==""||this.birthdate.toString()==""||this.deathdate.toString()==""||this.burialDate.toString()==""){
      this.toastr.error('Niepoprawne dane','Puste pole');
      return false
    }
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
    }
    return true;
  }
  public checkAddBurriedToGrave(){
    if(this.grave_list[this.selectedGraveToAssign].graveId<1||this.burried_list[this.selectedBurriedToAssign].burriedId<1||this.gravedigger_list[this.selectedGravediggerToAssign].gravediggerId<1){
      this.toastr.error('Niepoprawne dane','ID musi być większe od 0');
      return false;
    }
    else{
      let tempGetJsonValue:any;
      var listToCheck:Burried[];
      const header = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
      this.http.get('https://graveyard.azurewebsites.net/api/GraveBurried/getBurriedFromGrave/'+this.grave_list[this.selectedGraveToAssign].graveId, { headers: header }).subscribe(
        (data) => {
          tempGetJsonValue = data.valueOf();
          listToCheck=tempGetJsonValue;
          console.log(data.valueOf())
          var check=true;
          var i:number;
          for(i=0;i<listToCheck.length;i++){
              if(listToCheck[i].burriedId==this.burried_list[this.selectedBurriedToAssign].burriedId){
                check=false;
                break;
              }
          }
          return check;
        }
      );
    }
    return "Error"
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
    }
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
    var graveID=this.grave_list[this.selectedGraveToAssign].graveId;
    var burriedID=this.burried_list[this.selectedBurriedToAssign].burriedId;
    var gravediggerID=this.gravedigger_list[this.selectedGravediggerToAssign].gravediggerId;
    console.log(graveID+" "+burriedID+" "+gravediggerID);
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    if(this.checkAddBurriedToGrave()){
      this.http.get('https://graveyard.azurewebsites.net/api/GraveBurried/addBurriedToGrave/'+graveID+"/"+burriedID+"/"+gravediggerID, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd przypisywania pochowanego do grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(data!=null){
            this.toastr.success("Pochowany o ID "+burriedID+" przypisany do grobu od ID "+graveID,"Pochowany przypisany do grobu")
          }
        }
      )
    }
    this.changeAssigningPart();
  }
  public unassignBurriedToGrave(){
    var noError=true;
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    if(this.unassigningPart==1){
      return;
    }
    else{if(this.selectedGraveToAssign<0||this.selectedBurriedToUnassign<0){
      console.log()
      return;
    }
    else{
      var burried=this.listFromGrave[this.selectedBurriedToUnassign].burriedId;
      var grave=this.grave_list[this.selectedGraveToUnassign].graveId;
      this.http.delete('https://graveyard.azurewebsites.net/api/GraveBurried/removeBurriedFromGrave/'+grave+"/"+burried,httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        noError=false;
        this.toastr.error('Wystąpił błąd','Błąd wypisywania pochowanego z grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(noError){
              this.toastr.success("Pochowany o ID "+burried+" wypisany z grobu o ID "+grave,"Pochowany wypisany z grobu")
              this.changeUnassigningPart();
          }
        }
      )
    }}
   
  }
  public reload(){
    this.burried_list=[];
    this.getBurriedList();
  }
}
