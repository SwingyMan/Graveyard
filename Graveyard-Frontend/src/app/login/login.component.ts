import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'grv-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  parentComponent: AppComponent;

  public postJsonValue: any;

  email: string = '';
  password: string = '';

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
  }

  public postMethod() {

    const httpOptions = {
      headers: new HttpHeaders({
        contentType: 'application/json',
      })
    };

    let body = {
      email: this.email,
      password: this.password
    };

    this.http.post('https://graveyard.azurewebsites.net/api/customer/login', body, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        if (!this.parentComponent.hide_login) this.toastr.error('Niepoprawne dane','Błąd logowania');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })
    ).subscribe(
      (data) => {
        console.log(data);
        this.postJsonValue = data;
      }
    );
  }

  login() {
    this.postMethod();
  }

  switchLoginRegister() {
    this.parentComponent.hide_login = !this.parentComponent.hide_login;
  }
}
