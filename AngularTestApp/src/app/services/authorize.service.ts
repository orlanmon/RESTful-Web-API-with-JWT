import { Injectable } from '@angular/core';
import { User } from '../shared/models/User';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {

  objHttp: HttpClient;

  constructor(private http: HttpClient) { 

    this.objHttp = http;

  }

  register( username: string, password: string  ) : Observable<any> {

    // Content Type Recevied
    const headers = { 'Content-Type': 'application/json' };
    
    let url =  "http://localhost:8042/api/Auth/register";
    
    return this.http.post(url,
    {
    "username" : username,
    "password" : password
    },
    {headers}
    );

  }

  login( username: string, password: string  ) : Observable<any> {

    // Content Type Recevied
    const headers = { 'Content-Type': 'application/json' };
    
    let url =  "http://localhost:8042/api/Auth/login";
    
    return this.http.post(url,
    {
    "username" : username,
    "password" : password
    },
    {headers}
    );

  }


}
