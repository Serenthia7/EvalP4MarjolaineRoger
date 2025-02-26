import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IApplication } from '../models/application.model'; // Assure-toi d'avoir défini cette interface IApplication

@Injectable({
  providedIn: 'root',
})
export class ApplicationService {
  private apiUrl = 'http://localhost:5000/api/applications'; // L'URL de ton API pour récupérer les applications

  constructor(private http: HttpClient) {}

  getApplications(): Observable<IApplication[]> {
    return this.http.get<IApplication[]>(this.apiUrl);
  }
}
