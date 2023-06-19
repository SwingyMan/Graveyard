import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHandler, HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';
import { Gravedigger } from '../gravedigger';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'grv-add-gravedigger',
  templateUrl: './add-gravedigger.component.html',
  styleUrls: ['./add-gravedigger.component.css']
})
export class AddGravediggerComponent {
  getJsonValue:any;
  parentComponent: AppComponent;
  showComponent:boolean=true;
  pageToShowGravedigger:number=0;
  name:string=""
  lastname:string=""
  deletedGravediggerID:number=0
  gravedigger_list:Gravedigger[]=[]
  selectedGravediggerToDelete:number=0;
  public constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService){
    this.parentComponent = appComponent;
    this.getGravediggerList();
  }
  public ngOnChanges(){
    console.log("On Changes test");
  }
  public showAddGravedigger(){
    this.pageToShowGravedigger=0;
  }
  public showEditGravedigger(){
    this.pageToShowGravedigger=1;
  }
  public showDeleteGravedigger(){
    this.pageToShowGravedigger=2;
  }
  public showDeleteGravediggerPlus(){
    this.pageToShowGravedigger=3;
    this.reload();
    console.log(this.gravedigger_list);
  }
  public getGravediggerList() {
    let i:number=0
    for(i=0;i<10;i++){
      this.fetchGravediggerListFromEndpoint(i);
    }
      this.parentComponent.gravedigger_list=this.gravedigger_list; 
      console.log(this.gravedigger_list);
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
      }
    );
  }
  public test(i:number){console.log(i)}
  public addGravedigger(){
    const httpOptions = {
      headers: new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
  }
  let body = {
    firstName: this.name,
    lastName: this.lastname
  };
  if (this.name==""||this.lastname==""){
    this.toastr.error('Niepoprawne dane','Imię i/lub nazwisko nie może być puste');
      return;
  }
  else {
    this.http.post('https://graveyard.azurewebsites.net/api/Gravedigger/addGravedigger', body, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd', 'Błąd dodawania grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })
    ).subscribe(
      (data)=>{
        console.log(data)
        this.toastr.success("Nowy grabarz: "+this.name+" "+this.lastname, "Grabarz dodany")
      }

    )

  }
  console.log("Name: " + this.name + " Lastname: " + this.lastname)
}
  public deleteGravedigger(){
    var noError=true;
    const httpOptions = {
      headers: new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
  }
  if(this.deletedGravediggerID<1){
    this.toastr.error('Niepoprawne dane','ID musi być większe od 0');
    return;
  }//jeszcze po endpoincie sprawdzić czy grabarz o ID wgl istnieje
  else{
    this.http.delete('https://graveyard.azurewebsites.net/api/Gravedigger/removeGravedigger/'+this.deletedGravediggerID,httpOptions).pipe(
    catchError((error) => {
      console.error('Wystąpił błąd:', error);
      noError=false;
      this.toastr.error('Wystąpił błąd','Błąd wypisywania pochowanego z grobu');
      return of(null); // Zwracamy wartość null, aby obsłużyć błąd
    })).subscribe(
      (data)=>{
          console.log(data);
          if(noError){
          this.toastr.success("Grabarz o ID "+this.deletedGravediggerID+" usunięty","Usunięto grabarza");
        }
      }
    )
  }
}
  public deleteGravediggerPlus(form:NgForm){
    this.deletedGravediggerID=this.gravedigger_list[this.selectedGravediggerToDelete].gravediggerId;
    console.log(this.gravedigger_list[this.selectedGravediggerToDelete].gravediggerId);
    this.deleteGravedigger();
    this.gravedigger_list=[];
    this.reload()
    //działa ale trzeba guzik kliknąć 2 razy idk why
  }
  public reload(){
    this.showComponent = false;
    setTimeout(() => this.showComponent = true);
    this.gravedigger_list=[];
    this.getGravediggerList();
  }
}