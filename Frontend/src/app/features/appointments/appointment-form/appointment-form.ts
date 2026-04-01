import { Component, Input } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Doctor } from '../../../core/services/doctor';
import { Appointment } from '../../../core/services/appointment';
import { Patient } from '../../../core/services/patient';
import { NgIf, NgFor } from '@angular/common';
import { PatientModel } from '../../../core/models/patient.model';

@Component({
  selector: 'app-appointment-form',
  imports: [ReactiveFormsModule, NgIf, FormsModule, NgFor],
  templateUrl: './appointment-form.html',
  styleUrl: './appointment-form.css',
})
export class AppointmentForm {
  @Input() AppData: any;
  appointmentForm!: FormGroup;
  isEditMode = false;
  patients: any[] = [];
  doctors: any[] = [];
  currentpatient!: PatientModel | any;
 
  today = new Date().toISOString().slice(0, 16);
  constructor(
    private fb: FormBuilder,
    private patientService: Patient,
    private doctorService: Doctor,
    private appointmentService: Appointment,
  ) {}

  ngOnInit(): void {
    this.appointmentForm = this.fb.group({
      patientId: ['', Validators.required],
      doctorId: ['', Validators.required],
      appointmentDate: ['', Validators.required],
    });
    if (this.AppData) {
      this.isEditMode = true;
      this.appointmentForm.patchValue(this.appointmentForm);
    }

    this.loadPatients();
    this.loadDoctors();
  }

  loadPatients() {
    this.patientService.getAll().subscribe((res) => {
      this.patients=res;
    });
  }

  loadDoctors() {
    this.doctorService.getAll().subscribe((res) => {
      console.log(res)
      this.doctors = res;
    });
  }
  f() {
    return this.appointmentForm;
  }
  Filterpatient(id:any) {
    const matchpatient = this.patients.find((p) => p.id == id);
    if (matchpatient) {
      this.currentpatient = matchpatient;
      // patch patientId to form
      this.appointmentForm.patchValue({
        patientId: matchpatient.id,
      });
    }else
    {
      this.currentpatient=undefined;
    }
  }

  submit() {
    if (this.appointmentForm.invalid) return;

    const payload = {
      ...this.appointmentForm.value,
      appointmentStatus: 0,
    };

    this.appointmentService.create(payload).subscribe(() => {
      alert('Appointment Booked');
      this.appointmentForm.reset();
    });
  }
}
