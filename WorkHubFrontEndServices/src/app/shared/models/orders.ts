export interface Order{
    id: number;
    employeeEmail: string;
    orderDate: Date;
    orderedForDate: Date;
    orderType: string;
    orderItems: OrderItems[];
    orderStatus: string;
}

export interface OrderItems{
    id: number;
    itemName: string;
    category: string;
}