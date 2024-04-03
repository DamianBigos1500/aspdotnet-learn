import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { AuthResponse } from '../interfaces/auth/AuthResponse';
import { LoginRequest } from '../interfaces/auth/LoginRequest';
import { environment } from 'environments/environment';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({ providedIn: 'root' })
export class AuthService {
  apiUrl: string = environment.apiUrl;
  private tokenKey = 'token';

  constructor(private http: HttpClient) {}

  login(data: LoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.apiUrl}accounts/login`, {
        username: data.email,
        password: data.password,
      })
      .pipe(
        map((response) => {
          if (response.isSuccess) {
            localStorage.setItem(this.tokenKey, response.token);
          }
          return response;
        })
      );
  }
  getComments(): Observable<any> {
    return this.http.get<AuthResponse>(`${this.apiUrl}comments`);
  }

  getUserDetail = () => {
    const token = this.getToken();
    if (!token) return null;
    const decodedToken: any = jwtDecode(token);
    const userDetail = {
      id: decodedToken.nameid,
      fullName: decodedToken.name,
      email: decodedToken.email,
      roles: decodedToken.role || [],
    };

    return userDetail;
  };

  logout = (): void => {
    localStorage.removeItem(this.tokenKey);
  };

  private getToken = (): string | null =>
    localStorage.getItem(this.tokenKey) || '';
}
