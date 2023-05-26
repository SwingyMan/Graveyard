import { Component } from '@angular/core';
import {faCoffee} from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'grv-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  icon = faCoffee

  username: string = '';
  password: string = '';

  login() {
    // Tutaj możesz umieścić logikę logowania, np. wywołanie API
    console.log('Zaloguj - Nazwa użytkownika:', this.username, 'Hasło:', this.password);
  }
}
