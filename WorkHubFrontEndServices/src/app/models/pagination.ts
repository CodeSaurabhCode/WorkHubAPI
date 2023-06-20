import {Item} from './items';

export interface Pagination<T> {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: T;
}