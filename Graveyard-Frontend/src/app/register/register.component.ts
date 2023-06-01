import { Component } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'grv-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  parentComponent: AppComponent;

  constructor(private appComponent: AppComponent) {
    this.parentComponent = appComponent;
  }

  email: string = '';
  password: string = '';
  firstname: string = '';
  lastname: string = '';

  register() {
    // Tutaj możesz umieścić logikę logowania, np. wywołanie API
    console.log('Zaloguj - Nazwa użytkownika:', this.email, 'Hasło:', this.password);
  }

  switchLoginRegister() {
    this.parentComponent.hide_login = !this.parentComponent.hide_login;
  }
}
