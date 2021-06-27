import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RegisterRequest } from 'src/app/models/register-request';
import { User } from 'src/app/models/user-model';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {

  constructor(private http: HttpClient) { }

  subscribe(userId: number, bookId: number): Observable<User> {
    return this.http.post<User>(`${environment.apiURL}api/Subscription/${userId}/Subscribe/${bookId}`, '');
  }

  unSubscribe(userId: number, bookId: number): Observable<User> {
    return this.http.post<User>(`${environment.apiURL}api/Subscription/${userId}/Unsubscribe/${bookId}`, '');
  }

}
