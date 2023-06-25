import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'grv-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  parentComponent: AppComponent;

  public getJsonValue: any;
  public postJsonValue: any;

  email: string = '';
  password: string = '';
  firstname: string = '';
  lastname: string = '';

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
  }

  ngOnInit(): void {
    
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

      this.toastr.success(`Witaj ${this.parentComponent.user.name}!`,"Konto utworzone pomyślnie!")
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
      password: this.password,
      firstName: this.firstname,
      lastName: this.lastname
    };
    console.log(body)
    if (this.parentComponent.switch_login) this.http.post('https://graveyard.azurewebsites.net/api/Customer/register', body, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Niepoprawne dane','Błąd rejstracji');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })
    ).subscribe(
      (data) => {
        console.log(data);

        if (data != null) {
          this.email = '';
          this.password = '';
          this.firstname = '';
          this.lastname = ''; 

          this.parentComponent.hide_login_panel = true;
          this.postJsonValue = data.valueOf();
          this.parentComponent.auth_token = this.postJsonValue!.bearer;
          
          this.getMethod();
        } 
      }
    );
  }

  register() {
    this.postMethod();
  }

  switchLoginRegister() {
    this.parentComponent.switch_login = !this.parentComponent.switch_login;
  }
}
