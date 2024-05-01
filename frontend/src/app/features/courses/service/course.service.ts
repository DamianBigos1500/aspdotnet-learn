import { HttpClient } from '@angular/common/http';
import { Observable, delay, map } from 'rxjs';
import { AuthResponse } from '../../../core/interfaces/auth/AuthResponse';
import { environment } from 'environments/environment';
import { Injectable } from '@angular/core';
import { ICourse } from '../interfaces/ICourse';

@Injectable({ providedIn: 'root' })
export class CourseService {
  apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getCourse(): Observable<ICourse[]> {
    return this.http.get<ICourse[]>(`${this.apiUrl}course`);
  }
  getCourseById(id: string): Observable<ICourse[]> {
    return this.http.get<ICourse[]>(`${this.apiUrl}course/${id}`);
  }
}
