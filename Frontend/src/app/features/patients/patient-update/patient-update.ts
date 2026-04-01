import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
} from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { Patient } from '../../../core/services/patient';

@Component({
  selector: 'app-patient-update',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './patient-update.html',
  styleUrl: './patient-update.css',
})
export class PatientUpdate {
  patientForm!: FormGroup;

  submitted = false;
  private _patient: any;
  @Output() refresh = new EventEmitter<any>();
  @Input()
  set patient(value: any) {
    if (value) {
      this._patient = value;

      this.patientForm.patchValue({
        ...value,
        dateOfAdmit: value.dateOfAdmit ? value.dateOfAdmit.substring(0, 16) : '',
      });
    }
  }

  get patient(): any {
    return this._patient;
  }

  constructor(
    private fb: FormBuilder,
    private PatientService: Patient,
  ) {
    this.patientForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],

      phoneNumber: [
        '',
        [
          Validators.required,
          Validators.pattern('^[0-9]{10}$'), // 10 digit number validation
        ],
      ],

      gender: ['', Validators.required],

      address: ['', [Validators.required, Validators.minLength(5)]],

      dateOfAdmit: ['', Validators.required],
    });
  }

  get f() {
    return this.patientForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    if (this.patientForm.invalid) {
      return;
    }
    this.PatientService.update(this.patient.id, this.patientForm.value).subscribe((res) => {
      this.refresh.emit(this.patientForm.value);
    });
  }
}
