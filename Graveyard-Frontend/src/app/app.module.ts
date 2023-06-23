import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { GravesComponent } from './graves/graves.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { RegisterComponent } from './register/register.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { ShopComponent } from './shop/shop.component';
import { AddBurriedComponent } from './add-burried/add-burried.component';
import { AddGraveComponent } from './add-grave/add-grave.component';
import { AddGravediggerComponent } from './add-gravedigger/add-gravedigger.component';
import { DeleteAccountsComponent } from './delete-accounts/delete-accounts.component';
import { PlannedBurrialsListComponent } from './planned-burrials-list/planned-burrials-list.component';

@NgModule({
  declarations: [
    AppComponent,
    GravesComponent,
    LoginComponent,
    RegisterComponent,
    SideMenuComponent,
    ShopComponent,
    AddBurriedComponent,
    AddGraveComponent,
    AddGravediggerComponent,
    DeleteAccountsComponent,
    PlannedBurrialsListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({

    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas);
  }
}
