import { Injectable } from '@angular/core';
import { User } from '../shared/models/User';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import HttpService from './http.service';
import { RegisteredUser } from '../shared/models/RegisteredUser';
import { JWT } from '../shared/models/JWT';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {
  constructor(private httpService: HttpService) { }

  public register(username: string, password: string): Observable<RegisteredUser> {
    const user: User = new User(username, password);

    const result = this.httpService.post<RegisteredUser>("/auth/register", user);
    return result;
  }

  public login(username: string, password: string): Observable<JWT> {
    const user: User = new User(username, password);

    const result = this.httpService.post<JWT>("/auth/login", user);
    return result;
  }
}