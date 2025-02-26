import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IApplication } from '../models/application.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl: string = 'https://localhost:7025/api/applications';

  private apiKey: string = 'ApiKey';

  constructor(private http: HttpClient) {}

  getApplications(): Observable<IApplication[]> {
    return this.http.get<IApplication[]>(this.baseUrl);
  }

  get<T>(endpoint: string): Observable<T> {
    const headers = new HttpHeaders({
      'x-api-key': this.apiKey,
    });

    return this.http.get<T>(`${this.baseUrl}/${endpoint}`, { headers });
  }

  post<T>(endpoint: string, body: any): Observable<T> {
    const headers = new HttpHeaders({
      'x-api-key': this.apiKey,
      'Content-Type': 'application/json',
    });

    return this.http.post<T>(`${this.baseUrl}/${endpoint}`, body, { headers });
  }

  delete<T>(endpoint: string): Observable<T> {
    const headers = new HttpHeaders({
      'x-api-key': this.apiKey,
    });

    return this.http.delete<T>(`${this.baseUrl}/${endpoint}`, { headers });
  }
}
