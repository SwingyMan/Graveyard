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

  public getJsonValue: any;
  public postJsonValue: any;

  email: string = '';
  password: string = '';

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
  }

  public getMethod() {

      const header = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })

    this.http.get('https://graveyard.azurewebsites.net/api/customer/getSelf', { headers: header }).subscribe(
      (data) => {
        console.log(data);
        this.getJsonValue = data.valueOf();
        this.parentComponent.user = this.getJsonValue;
        this.parentComponent.role = this.parentComponent.user.owned_role;

        console.log(this.parentComponent.user.name)

        this.toastr.success(`Witaj ${this.parentComponent.user.name}!`,"Zalogowano!")
      }
    );
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

    if (!this.parentComponent.switch_login) this.http.post('https://graveyard.azurewebsites.net/api/customer/login', body, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Niepoprawne dane','Błąd logowania');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })
    ).subscribe(
      (data) => {
        console.log(data);

        if (data != null) {
          this.email = '';
          this.password = ''

          this.postJsonValue = data.valueOf();
          this.parentComponent.auth_token = this.postJsonValue!.bearer;
          
          this.parentComponent.hide_login_panel = true;
          
          this.getMethod();
        } 
      }
    );
  }

  login() {
    this.postMethod();
  }

  switchLoginRegister() {
    this.parentComponent.switch_login = !this.parentComponent.switch_login;
  }
}
