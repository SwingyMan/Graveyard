import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHandler, HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';
@Component({
  selector: 'grv-add-grave',
  templateUrl: './add-grave.component.html',
  styleUrls: ['./add-grave.component.css']
})
export class AddGraveComponent {
  parentComponent: AppComponent;
  x: number;
  y: number;
  pageToShowGraves:number=0;
  deletedGraveID: number = 0;
  public getJsonValue: any;
  public postJsonValue: any;
  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.x = 0;
    this.y = 0;
  }
  public showAddGrave(){
    this.pageToShowGraves=0;
  }
  public showEditGrave(){
    this.pageToShowGraves=1;
  }
  public showDeleteGrave(){
    this.pageToShowGraves=2;
  }




  public checkForCoords(x: number, y: number) {

    let n = 0;
    var checked = true;
    if (x <= 0 || y <= 0) {
      console.log(false)
      this.toastr.error('Niepoprawne dane', 'Współrzędne nie mogą się równać 0');
      return false;
    }
    for (var i = 0; i < this.parentComponent.grave_list.length; i++) {
      if (x == this.parentComponent.grave_list[i].x && y == this.parentComponent.grave_list[i].y) {
        checked = false;
      }
    }
    console.log(checked);
    if (!checked) { this.toastr.error('Niepoprawne dane', 'Grób w tym miejscu już istnieje'); }
    return checked;

  }
  public addGrave() {
    const httpOptions = {
      headers: new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    let body = {
      x: this.x,
      y: this.y
    };
    if (this.checkForCoords(this.x, this.y)) {
      this.http.post('https://graveyard.azurewebsites.net/api/grave/add', body, httpOptions).pipe(
        catchError((error) => {
          console.error('Wystąpił błąd:', error);
          this.toastr.error('Wystąpił błąd', 'Błąd dodawania grobu');
          return of(null); // Zwracamy wartość null, aby obsłużyć błąd
        })
      ).subscribe(
        (data) => {
          this.postJsonValue = data;
          console.log(this.postJsonValue)
          this.toastr.success(`Nowy grób, X:` + this.x + ' Y: ' + this.y, "Grób dodany")
        }

      )

    }
    console.log("X: " + this.x + " Y: " + this.y)
  }
  public deleteGrave() {
    var noError = true;
    const httpOptions = {
      headers: new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    if (this.deletedGraveID < 1) {
      this.toastr.error('Niepoprawne dane', 'ID musi być większe od 0');
      return;
    }//jeszcze po endpoincie sprawdzić czy pochowany o ID wgl istnieje
    else {
      this.http.delete('https://graveyard.azurewebsites.net/api/Grave/delete/' + this.deletedGraveID, httpOptions).pipe(
        catchError((error) => {
          console.error('Wystąpił błąd:', error);
          noError = false;
          this.toastr.error('Wystąpił błąd', 'Błąd wypisywania pochowanego z grobu');
          return of(null); // Zwracamy wartość null, aby obsłużyć błąd
        })).subscribe(
          (data) => {
            console.log(data);
            if (noError) {
              this.toastr.success("Grób o ID " + this.deletedGraveID + " usunięty", "Grób usunięty")
            }
          }
        )
    }
  }
}
