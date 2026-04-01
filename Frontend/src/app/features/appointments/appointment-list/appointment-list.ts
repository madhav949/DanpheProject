import { Component } from '@angular/core';
import { Appointment } from '../../../core/services/appointment';
import { AgGridAngular } from 'ag-grid-angular';
import type { ColDef, ValueFormatterParams } from 'ag-grid-community';
import { AppointmentForm } from '../appointment-form/appointment-form';
import * as bootstrap from 'bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { AppointmentStatus } from '../../../core/enums/role';
@Component({
  selector: 'app-appointment-list',
  imports: [AgGridAngular, AppointmentForm, ReactiveFormsModule],
  templateUrl: './appointment-list.html',
  styleUrl: './appointment-list.css',
})
export class AppointmentList {
  rowData: any[] = [];
  AppointmentInstance!: bootstrap.Modal;
  defaultcoldef = { flex: 1, resizable: true, sortable: true, fliter: true };
  columnDefs: ColDef[] = [
    { headerName: 'ID', field: 'id' },
    { headerName: 'PatientName', field: 'patientName' },
    { headerName: 'DoctorName', field: 'doctorName' },
    { headerName: 'Date', field: 'appointmentDate' },
    {
      field: 'status',
      headerName: 'Status',
      valueFormatter:(params:ValueFormatterParams)=>{
        return AppointmentStatus[params.value as number]
      }
    },

    {
      headerName: 'Actions',
      cellRenderer: (params: any) => {
        return `
        <button class="btn btn-sm btn-info view-btn">View</button>
        <button class="btn btn-sm btn-danger cancel-btn">Cancel</button>
        `;
      },
    },
  ];

  constructor(private appointment: Appointment) {}

  ngOnInit() {
    this.loadAppointments();
  }

  loadAppointments() {
    this.appointment.getAllAppointment().subscribe((data) => {
      this.rowData = data;
    });
  }

  openModel() {
    const appointmodel = document.getElementById('appointment');
    if (appointmodel) {
      this.AppointmentInstance = new bootstrap.Modal(appointmodel);
      this.AppointmentInstance.show();
    }
  }
}
