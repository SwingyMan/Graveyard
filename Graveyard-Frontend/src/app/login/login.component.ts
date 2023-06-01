import { Component } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'grv-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  parentComponent: AppComponent;

  constructor(private appComponent: AppComponent) {
    this.parentComponent = appComponent;
  }

  email: string = '';
  password: string = '';

  login() {
    // Tutaj możesz umieścić logikę logowania, np. wywołanie API
    console.log('Zaloguj - Nazwa użytkownika:', this.email, 'Hasło:', this.password);
  }

  switchLoginRegister() {
    this.parentComponent.hide_login = !this.parentComponent.hide_login;
  }
}
