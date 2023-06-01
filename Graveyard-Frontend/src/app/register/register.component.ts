import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';

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
        contentType: 'application/json',
      })
    };

    let body = {
      email: this.email,
      password: this.password,
      firstName: this.firstname,
      lastName: this.lastname
    };

    this.http.post('https://graveyard.azurewebsites.net/api/customer/register', body, httpOptions).subscribe(
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
