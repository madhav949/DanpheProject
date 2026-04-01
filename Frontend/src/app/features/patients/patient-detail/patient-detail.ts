import { Component } from '@angular/core';
import { PatientForm } from "../patient-form/patient-form";
import { AgGridAngular } from 'ag-grid-angular';
import { PatientList } from "../patient-list/patient-list";
import * as bootstrap from "bootstrap"

@Component({
  selector: 'app-patient-detail',
  imports: [PatientForm, PatientList],
  templateUrl: './patient-detail.html',
  styleUrl: './patient-detail.css',
})
export class PatientDetail {
 
}
