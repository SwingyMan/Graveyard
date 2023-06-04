import { Component } from '@angular/core';

import {User} from './user';

@Component({
  selector: 'grv-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'E - Graveyard';

  role = 0;

  hide_login = false;
  succes_login = false;

  user!: User;

  auth_token!: any;
}
