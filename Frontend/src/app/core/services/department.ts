import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentModel } from '../models/department.model';

@Injectable({
  providedIn: 'root',
})
export class Department {
  private apiUrl = 'http://localhost:5065/api/Department';
  constructor(private http: HttpClient) {}

  getAll(): Observable<DepartmentModel[]> {
    return this.http.get<DepartmentModel[]>(this.apiUrl);
  }

  getById(id: number): Observable<DepartmentModel> {
    return this.http.get<DepartmentModel>(`${this.apiUrl}/${id}`);
  }

  create(patient: DepartmentModel): Observable<DepartmentModel> {
    return this.http.post<DepartmentModel>(this.apiUrl, patient);
  }

  update(id: number, patient: DepartmentModel): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, patient);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
