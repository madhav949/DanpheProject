import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DepartmentModel } from '../../../core/models/department.model';
import { Department } from '../../../core/services/department';
import { NgFor, NgIf } from '@angular/common';
import { Doctor } from '../../../core/services/doctor';
import { DoctorModel } from '../../../core/models/doctor.model';

@Component({
  selector: 'app-doctor-form',
  imports: [ReactiveFormsModule, NgFor, NgIf],
  templateUrl: './doctor-form.html',
  styleUrl: './doctor-form.css',
})
export class DoctorForm {
  @Output() updateDoctor=new EventEmitter<DoctorModel>();
  @Input() set doctorData(value: DoctorModel | null) {
    if (!value) {
      this.isEditMode = false;
      this.doctorForm?.reset();
      return;
    }

    this.isEditMode = true;

    if (this.doctorForm) {
      this.doctorForm.patchValue(value);
    }
  }
  @Output() DocterCreate = new EventEmitter<DoctorModel>();
  departments!: DepartmentModel[];
  doctorForm!: FormGroup;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private deptservice: Department,
  ) {}
  loadAllDepartment() {
    this.deptservice.getAll().subscribe((res) => {
      console.log(res);
      this.departments = res;
    });
  }
  ngOnInit(): void {
    this.loadAllDepartment();
    this.doctorForm = this.fb.group({
      id:[],
      departmentId: [null, [Validators.required, Validators.min(1)]],
      docFullName: ['', [Validators.required, Validators.minLength(3)]],
      qualification: ['', [Validators.required]],
      experienceYears: [0, [Validators.required, Validators.min(0)]],
    });

  }

  onSubmit() {
    if (this.doctorForm.invalid) {
      this.doctorForm.markAllAsTouched();
      return;
    }
    

    const formData = this.doctorForm.value;
    formData.id = Number(formData.id);
    if (this.isEditMode) {
      this.updateDoctor.emit(formData);
    } else {
      // this.doctorserv.create(formData).subscribe((res)=>{
      this.DocterCreate.emit(formData);
      // })
    }
  }
}
