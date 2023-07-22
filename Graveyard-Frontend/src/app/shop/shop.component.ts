import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHandler, HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';
import { Gravedigger } from '../gravedigger';
import { NgForm } from '@angular/forms';
import { Item } from '../item';
import { Cart } from '../cart';
import { Grave } from '../grave';
@Component({
  selector: 'grv-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent {
  getJsonValue:any;
  parentComponent:AppComponent;
  pageToShowShop:number=0;
  itemPickPart=1;
  itemList:Item[]=[];
  currentCart?:Cart[];
  selectedItemToCart:number=0;

  totalPrice:number=0;
  grave_list:Grave[]=[]
  selectedGraveToAddItem:number=0;
  public constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService){
    this.parentComponent=appComponent;
    this.getItemList();
    this.getGraveList();
  }
  public changeItemPickPart(){
    this.itemPickPart+=1;
    if(this.itemPickPart>2){
      this.itemPickPart=1;
    }
  }
  public showItemPick(){
    this.pageToShowShop=0;
  }
  public showCart(){
    this.pageToShowShop=1;
    this.getCart();
    console.log(this.currentCart);
    
  }
  public showPurchaseSummary(){
    this.pageToShowShop=2;
  }
  public showPurchaseHistory(){
    this.pageToShowShop=3;
  }
  public getItemList(){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/Item/getItems/0', { headers: header }).subscribe(
      (data) => {
        this.getJsonValue=data.valueOf()
        this.itemList=this.getJsonValue;
        console.log(data.valueOf())
      }
    );
  }
 
  public getCart(){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/Cart/showCart', { headers: header }).subscribe(
      (data) => {
        this.getJsonValue=data.valueOf()
        this.currentCart=this.getJsonValue;
        console.log(data.valueOf())
        this.calculateTotalSum();
      }
    );
  }
  public getGraveList() {
    let i:number=0
    for(i=0;i<10;i++){
     this.fetchGraveListFromEndpoint(i);
    }
  }

  public fetchGraveListFromEndpoint(i:number){
    const header = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.parentComponent.auth_token}`,
    })
    this.http.get('https://graveyard.azurewebsites.net/api/grave/list/'+i, { headers: header }).subscribe(
      (data) => {
        this.getJsonValue = data.valueOf();
        this.grave_list=this.grave_list.concat(this.getJsonValue);
        console.log(data.valueOf())
        this.grave_list.sort((a, b) => (a.graveId < b.graveId ? -1 : 1));
      }
    );
  }
  public addItemToCart(){
    var itemID=this.itemList[this.selectedItemToCart].itemId;
    var graveID=this.grave_list[this.selectedGraveToAddItem].graveId; 
    const httpOptions={
      headers:new HttpHeaders({
        contentType: 'application/json',
        'Authorization': `Bearer ${this.parentComponent.auth_token}`,
      })
    };
    this.http.get('https://graveyard.azurewebsites.net/api/Cart/addItemToCart/'+itemID+'/'+graveID, httpOptions).pipe(
      catchError((error) => {
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd wrzucenia przedmiotu do koszyka');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(data!=null){
            this.toastr.success(this.itemList[this.selectedItemToCart].name+" dodany do koszyka","Przedmiot dodany do koszyka")
          }
        }
      )
    console.log(this.itemList[this.selectedItemToCart].name+" na grób nr "+this.grave_list[this.selectedGraveToAddItem].graveId);
    this.changeItemPickPart();
  }
  public radioButtonClick(i:number){
    console.log(i);
  }
  public calculateTotalSum(){
    this.totalPrice=0;
    if(this.currentCart!=undefined){
    for(let i=0;i<this.currentCart.length;i++){
      this.totalPrice+=this.currentCart[i].items.price;
    }
    console.log("Total Price: "+this.totalPrice);
    }
    
  }
  public deleteItemFromCart(i:number){
    if(this.currentCart!=undefined){
      var graveID=this.currentCart[i].graveId;
      var itemID=this.currentCart[i].itemId;
      var noError=true;
      const httpOptions={
        headers:new HttpHeaders({
          contentType: 'application/json',
          'Authorization': `Bearer ${this.parentComponent.auth_token}`,
        })
      };
      this.http.delete('https://graveyard.azurewebsites.net/api/Cart/delete/'+itemID+'/'+graveID, httpOptions).pipe(
      catchError((error) => {
        noError=false;
        console.error('Wystąpił błąd:', error);
        this.toastr.error('Wystąpił błąd','Błąd usunięcia przedmiotu z koszyka');
        return of(null); // Zwracamy wartość null, aby obsłużyć błąd
      })).subscribe(
        (data)=>{
            console.log(data);
            if(noError){
            this.toastr.success("Przedmiot usunięto","Przedmiot usunięto z koszyka")
            this.getCart();
          }
        }
      )
    }
    
  }
}

