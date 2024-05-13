import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';
import { Injectable } from '@angular/core';
import { IConversation } from '../interfaces/IConversation';

@Injectable({ providedIn: 'root' })
export class ConversationService {
  apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getConversations(): Observable<IConversation[]> {
    return this.http.get<IConversation[]>(`http://localhost:8001/api/conversations`);
  }
  getConversationById(id: string): Observable<IConversation[]> {
    return this.http.get<IConversation[]>(`${this.apiUrl}course/${id}`);
  }
}