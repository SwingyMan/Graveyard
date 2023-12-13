import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import {HttpHandler,HttpClient,HttpHeaders} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { formatDate } from '@angular/common';
import { catchError,of } from 'rxjs';
import { User } from '../user';
@Component({
  selector: 'grv-delete-accounts',
  templateUrl: './delete-accounts.component.html',
  styleUrls: ['./delete-accounts.component.css']
})
export class DeleteAccountsComponent {
  getJsonValue:any;
  parentComponent:AppComponent;
  pageToShowAccounts:number=0;

  account_list:User[]=[];

  selectedAccountToEdit:number=0
  editedName:string='';
  editedLastname:string='';
  editedEmail:string='';
  editedPassword:string='';
  editedRole:string='';

  deletedAccountID:number=0;
  selectedAccountToDelete:number=0;

  constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService) {
    this.parentComponent = appComponent;
    this.getAccountList();
  }
  public showEditAccounts(){
    this.pageToShowAccounts=0;
    this.reload();
  }
  public showDeleteAccounts(){
    this.pageToShowAccounts=1;
    this.reload();
  }
  public getAccountList(){
    let i:number=0
    for(i=0;i<10;i++){
     this.fetchAccountListFromEndpoint(i);
    }
  }
  public fetchAccountListFromEndpoint(i:number){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/Customer/list/'+i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.account_list=this.account_list.concat(this.getJsonValue);
        console.log(data.valueOf())
        this.account_list.sort((a, b) => (a.customerId < b.customerId ? -1 : 1));
      }
    );
  }
  public insertDataToEdit(i:number){
    var user=this.account_list[i];
    this.editedEmail=user.email;
    this.editedName=user.name;
    this.editedLastname=user.lastName;
    if(user.owned_role==0){this.editedRole="User"}
    else{
      if(user.owned_role==1){this.editedRole="Administrator"}
    }
  }
  public editAccount(){
    let accountID=this.account_list[this.selectedAccountToEdit].customerId;
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    var noError=true;
    let body:any;
    if(this.editedPassword==''){
      let body={
        email:this.editedEmail,
        firstName:this.editedName,
        lastName:this.editedLastname,
        owned_role:this.editedRole
      }
    }
    else{
      let body={
        email:this.editedEmail,
        password:this.editedPassword,
        firstName:this.editedName,
        lastName:this.editedLastname,
        owned_role:this.editedRole
      }
    }
    this.http.patch('https://graveyard.azurewebsites.net/api/Customer/edit/'+accountID, body, { headers: header }).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        noError=false;
        this.toastr.error('Wystąpił błąd','Błąd wypisywania pochowanego z grobu');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
      (data) => {
        console.log(data);
        if(noError){
          this.toastr.success("Użytkownik o ID "+accountID+" zmieniony :"+this.editedName+" "+this.editedLastname,"Konto zmodyfikowane")
      }
      }
    );
  }
  public deleteAccount(){
    var noError=true;
    var userID=this.account_list[this.selectedAccountToDelete].customerId;
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    this.http.delete('https://graveyard.azurewebsites.net/api/Customer/delete/'+userID,httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        noError=false;
        this.toastr.error('Wystąpił błąd','Błąd usuwania pochowanego');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(noError){
            this.toastr.success("Konto o ID "+userID+" usunięty","Konto usunięty")
            this.reload()
          }
        }
      )
  }
  public reload(){
    this.account_list=[];
    this.getAccountList();
  }
}
