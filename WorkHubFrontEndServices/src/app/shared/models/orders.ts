export interface Order{
    id: number;
    employeeEmail: string;
    orderDate: Date;
    orderForDate: Date;
    orderType: string;
    orderItems: OrderItems[];
    orderStatus: string;
}

export interface OrderItems{
    id: number;
    itemName: string;
    category: string;
}