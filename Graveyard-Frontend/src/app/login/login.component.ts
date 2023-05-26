import { Component } from '@angular/core';

@Component({
  selector: 'grv-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {


  username: string = '';
  password: string = '';

  login() {
    // Tutaj możesz umieścić logikę logowania, np. wywołanie API
    console.log('Zaloguj - Nazwa użytkownika:', this.username, 'Hasło:', this.password);
  }
}
