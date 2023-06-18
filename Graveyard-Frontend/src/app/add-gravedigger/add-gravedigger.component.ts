import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHandler, HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';

@Component({
  selector: 'grv-add-gravedigger',
  templateUrl: './add-gravedigger.component.html',
  styleUrls: ['./add-gravedigger.component.css']
})
export class AddGravediggerComponent {
  parentComponent: AppComponent;
  pageToShowGravedigger:number=0;
  name:string=""
  lastname:string=""
  deletedGravediggerID:number=0
  public constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService){
    this.parentComponent = appComponent;
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
          this.toastr.success("Grabarz o ID "+this.deletedGravediggerID+" usunięty","Usunięto grabarza")
        }
      }
    )
  }
}
}
