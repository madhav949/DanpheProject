import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppointmentModel } from '../models/appointment.model';

@Injectable({
  providedIn: 'root',
})
export class Appointment {
  private apiUrl ="http://localhost:5065/api/Appointment";
    constructor(private http: HttpClient) {}
  
    getAllAppointment(): Observable<AppointmentModel[]> {
      return this.http.get<AppointmentModel[]>(this.apiUrl);
    }
  
    getById(id: number): Observable<AppointmentModel> {
      return this.http.get<AppointmentModel>(`${this.apiUrl}/${id}`);
    }
  
    create(patient: AppointmentModel): Observable<AppointmentModel> {
      return this.http.post<AppointmentModel>(this.apiUrl, patient);
    }
  
    update(id: number, patient: AppointmentModel): Observable<void> {
      return this.http.put<void>(`${this.apiUrl}/${id}`, patient);
    }
  
    delete(id: number): Observable<void> {
      return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}
