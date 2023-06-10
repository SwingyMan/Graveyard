import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'grv-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})

export class SideMenuComponent {

  parentComponent: AppComponent;

  public postJsonValue: any;

  role!: number;
  
  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent
    this.role = this.parentComponent.role;
  }
  

  public postMethod() {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };

    if (!this.parentComponent.switch_login) this.http.delete('https://graveyard.azurewebsites.net/api/customer/deleteSelf', httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Skontaktuj się z administratorem','Wystąpił błąd');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })
    ).subscribe(
      (data) => {
        console.log(data);
        this.toastr.success("Akcja zakończona sukcesem!","Konto zostało usunięte!");
        this.postJsonValue = data;
        this.parentComponent.logout()
      }
    );
  }

  deleteSelfUser() {
    this.postMethod();
  }

  showGraves() {
    this.parentComponent.page_in_menu = 0;
  }

  showShop() {
    this.parentComponent.page_in_menu = 1;
  }

  showAddBurried() {
    this.parentComponent.page_in_menu = 2;
  }

  showAddGrave() {
    this.parentComponent.page_in_menu = 3;
  }
}
