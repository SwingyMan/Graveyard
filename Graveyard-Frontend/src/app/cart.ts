import { Grave } from "./grave";
import { Item } from "./item";
import { User } from "./user";

export interface Cart {
    cartId: number;
    customer:User;
    customerId: number;
    grave:Grave;
    graveId:number;
    itemId:number;
    items:Item;
    purchaseHistoryShopHistoryId:number
    quantity:number;
}