import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RegisterRequest } from 'src/app/models/register-request';
import { User } from 'src/app/models/user-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUser(email: string): Observable<User> {
    return this.http.get<User>(`${environment.apiURL}api/User/${email}`);
  }

}
