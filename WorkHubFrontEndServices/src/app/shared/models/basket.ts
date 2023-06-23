import * as cuid from "cuid";

export interface Basket {
    id: string;
    items: BasketItem[];
  }
  
export interface BasketItem {
    id: number;
    itemName: string;
    price: number;
    quantity: number;
    category: string;
}

export class Basket implements Basket{
    id = cuid();
    items: BasketItem[] = [];

}