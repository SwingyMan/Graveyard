import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'grv-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  parentComponent: AppComponent;

  public postJsonValue: any;

  email: string = '';
  password: string = '';
  firstname: string = '';
  lastname: string = '';

  constructor(private appComponent: AppComponent, private http: HttpClient) {
    this.parentComponent = appComponent;
  }

  

  ngOnInit(): void {
    
  }
  

  public postMethod() {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization-Type': 'Bearer'
      })
    };

    let body = {
      email: this.email,
      password: this.password,
      firstName: this.firstname,
      lastName: this.lastname
    };

    this.http.post('https://graveyard.azurewebsites.net/api/customer/register', body, httpOptions).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 200 && error.error instanceof Blob && error.headers.has('Authorization')) {
          const token = error.headers.get('Authorization');
          // Przechwyć token Bearer
          console.log(token);
        }
        return throwError(error);
      })
    ).subscribe(
      (data) => {
        console.log(data);
        this.postJsonValue = data;
      }
    );
  }

  register() {
    this.postMethod();
  }

  switchLoginRegister() {
    this.parentComponent.hide_login = !this.parentComponent.hide_login;
  }
}
