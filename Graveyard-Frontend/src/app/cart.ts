import { Grave } from "./grave";
import { Item } from "./item";
import { User } from "./user";

export interface Cart {
    cartId: number;
    customerId: number;
    itemId:number;
    graveId:number;
    quantity:number;
    customer:User;
    items:Item[];
    grave:Grave;
}