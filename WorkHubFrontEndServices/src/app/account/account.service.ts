import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../shared/models/user';
import { HttpClient } from '@angular/common/http';
import { Route, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = "https://localhost:5001/api/Account"

  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  token?: string;

  constructor(private http: HttpClient, private router: Router) { }

  login(values: any){
    return this.http.post<User>(this.baseUrl + '/login', values).pipe(
      map(user => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        this.token = user.token
      })
    )
  }

  register(values: any){
    return this.http.post<User>(this.baseUrl + '/register', values).pipe(
      map(user => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
      })
    )
  }

  logout(){
    localStorage.removeItem('token')
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/')
  }

}
