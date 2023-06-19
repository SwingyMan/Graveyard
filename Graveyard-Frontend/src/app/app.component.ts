import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import {User} from './user';
import { Grave } from './grave';
import { Burried } from './burried';
import { Gravedigger } from './gravedigger';

@Component({
  selector: 'grv-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'E - Cmentarz';
  getJsonValue:any;
  role = -1;

  switch_login = false;
  hide_login_panel = true;

  page_in_menu = 0;

  user!: User;

  grave_list: Grave[] = [];
  burried_list: Burried[]=[];
  gravedigger_list:Gravedigger[]=[];

  empty_user: User = {
    carts: '',
    customerId: -1,
    date_of_creation: new Date(),
    email: '',
    lastname: '',
    name: '',
    owned_role: -1,
    password: ''
  }

  auth_token!: any;

  constructor(private toastr: ToastrService) {

  }
 

  toggleLoginPanel() {
    this.hide_login_panel = !this.hide_login_panel;
    this.switch_login = false;
  }

  logout() {
    this.toastr.success('Do zobaczenia!', 'Wylogowano!')

    this.role = -1;

    this.switch_login = false;
    this.hide_login_panel = true;
    this.page_in_menu = 0

    this.user = this.empty_user;

    this.auth_token = '';
  }
}
