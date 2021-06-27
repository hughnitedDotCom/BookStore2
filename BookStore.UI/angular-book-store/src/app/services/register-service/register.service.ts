import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RegisterRequest } from 'src/app/models/register-request';
import { User } from 'src/app/models/user-model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }

  register(registerReuest: RegisterRequest) : Observable<User>{
    return this.http.post<User>(`${environment.apiURL}api/User/Register`, registerReuest);
  }

}
