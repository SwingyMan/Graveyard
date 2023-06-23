import { Cart } from "./cart";
import { User } from "./user";
export interface Purchase{
    shopHistoryId:number;
    customerId:number;
    customer:User;
    cart:Cart;
    date_of_purchase:Date;
    status:number;
    totalPrice:0;
}