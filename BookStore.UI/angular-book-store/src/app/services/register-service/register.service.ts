import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RegisterRequest } from 'src/app/models/register-request';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) { }


  register(registerReuest: RegisterRequest) {
    return this.http.post(`${environment.apiURL}/register`, registerReuest);
}

}
