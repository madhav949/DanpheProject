import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { PatientModel } from '../models/patient.model';

@Injectable({
  providedIn: 'root'
})
export class Patient {

  private apiUrl ="http://localhost:5065/api/Patient";
  constructor(private http: HttpClient) {}

  getAll(): Observable<PatientModel[]> {
    return this.http.get<PatientModel[]>(this.apiUrl);
  }

  getById(id: number): Observable<PatientModel> {
    return this.http.get<PatientModel>(`${this.apiUrl}/${id}`);
  }

  create(patient: PatientModel): Observable<PatientModel> {
    return this.http.post<PatientModel>(this.apiUrl, patient);
  }

  update(id: number, patient: PatientModel): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, patient);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}