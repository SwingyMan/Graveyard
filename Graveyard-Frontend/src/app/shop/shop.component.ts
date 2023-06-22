import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpHandler, HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { catchError, of } from 'rxjs';
import { Gravedigger } from '../gravedigger';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'grv-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent {
  parentComponent:AppComponent;
  pageToShowShop:number=0;
  public constructor(private appComponent: AppComponent, private http: HttpClient, private toastr: ToastrService){
    this.parentComponent=appComponent
  }
  public showItemPick(){
    this.pageToShowShop=0;
  }
  public showCart(){
    this.pageToShowShop=1;
  }
  public showPurchaseSummary(){
    this.pageToShowShop=2;
  }
  public showPurchaseHistory(){
    this.pageToShowShop=3;
  }
}
