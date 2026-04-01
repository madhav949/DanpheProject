import {  NgIf } from '@angular/common';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Patient } from '../../../core/services/patient';


@Component({
  selector: 'app-patient-form',
  imports: [ReactiveFormsModule,NgIf],
  templateUrl: './patient-form.html',
  styleUrl: './patient-form.css',
})
export class PatientForm {
    patientForm!: FormGroup;
  submitted = false;
  today = new Date().toISOString().slice(0,16);

  constructor(private fb: FormBuilder , private patientService:Patient , private cd:ChangeDetectorRef) {

    this.patientForm = this.fb.group({
      fullName: ['', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50)
      ]],

      phoneNumber: ['', [
        Validators.required,
        Validators.pattern('^[0-9]{10}$') // 10 digit number validation
      ]],

      gender: ['', Validators.required],

      address: ['', [
        Validators.required,
        Validators.minLength(5)
      ]],

      dateOfAdmit: ['', Validators.required]
    });
  }

  get f() {
    // console.log(this.patientForm)
    return this.patientForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    if (this.patientForm.invalid) {
      return;
    }
    this.patientService.create(this.patientForm.value).subscribe((res)=>{
    console.log(res);
    })

   
  }

}
