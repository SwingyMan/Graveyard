import { Component } from '@angular/core';

@Component({
  selector: 'grv-delete-accounts',
  templateUrl: './delete-accounts.component.html',
  styleUrls: ['./delete-accounts.component.css']
})
export class DeleteAccountsComponent {
  deletedAccountID:number=0;
  public deleteAccount(){}
}
