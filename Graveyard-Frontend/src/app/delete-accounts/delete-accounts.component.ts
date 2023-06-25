import { Component } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'grv-delete-accounts',
  templateUrl: './delete-accounts.component.html',
  styleUrls: ['./delete-accounts.component.css']
})
export class DeleteAccountsComponent {
  //parentComponent:AppComponent;
  pageToShowAccounts:number=0;

  selectedAccountToEdit:number=0

  deletedAccountID:number=0;
  selectedAccountToDelete:number=0;

  public showEditAccounts(){
    this.pageToShowAccounts=0;
  }
  public showDeleteAccounts(){
    this.pageToShowAccounts=1;
  }
  public editAccount(){}
  public deleteAccount(){}
}
