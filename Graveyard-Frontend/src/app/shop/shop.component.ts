import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHandler, HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';
import { Gravedigger } from '../gravedigger';
import { NgForm } from '@angular/forms';
import { Item } from '../item';
import { Cart } from '../cart';
@Component({
  selector: 'grv-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent {
  getJsonValue:any;
  parentComponent:AppComponent;
  pageToShowShop:number=0;
  itemList:Item[]=[];
  currentCart?:Cart;
  selectedItemToCart:number=0;
  public constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService){
    this.parentComponent=appComponent;
    this.getItemList();
  }
  public showItemPick(){
    this.pageToShowShop=0;
  }
  public showCart(){
    this.pageToShowShop=1;
    this.getCart();
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
  public addItemToCart(){
    console.log(this.itemList[this.selectedItemToCart].name)
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
      }
    );
  }
}
