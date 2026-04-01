
import { Component } from '@angular/core';
import * as bootstrap from 'bootstrap';
import { DoctorForm } from '../doctor-form/doctor-form';
import type { ColDef } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';
import { Doctor } from '../../../core/services/doctor';
import { DoctorModel } from '../../../core/models/doctor.model';
@Component({
  selector: 'app-doctor-list',
  imports: [DoctorForm, AgGridAngular],
  templateUrl: './doctor-list.html',
  styleUrl: './doctor-list.css',
})

// type DoctorOperation= 'edit' | "create";
export class DoctorList {
  doctorInstance!: bootstrap.Modal;
  constructor(private doctorservice:Doctor){}
  isEdit=false;
  ngOnInit():void{
    this.loadAllDoctors();
  }
  loadAllDoctors(){
    this.doctorservice.getAll().subscribe((res)=>{
      this.rowData = res;
      console.log(res);
    })
  }
currentDoctor!:DoctorModel;

  OpenModel() {
    const doctorModel = document.getElementById('DoctorCreate');

    if (doctorModel) {
      this.doctorInstance = new bootstrap.Modal(doctorModel);
      this.doctorInstance.show();
    }
  }

    rowData : DoctorModel[] = [];
  defaultcoldef = { flex: 1, resizable: true, sortable: true, fliter: true };
    // Column Definitions: Defines the columns to be displayed.
    colDefs: ColDef[] = [
        {headerName:"ID", field: "id" },
        {headerName:"Department ID" ,field: "departmentId" },
        {headerName:"Doctor Name", field: "docFullName" },
        { field: "qualification" },
         { field: "experienceYears" },
          { field: "departmentName" },
          {
             headerName: 'Actions',
      cellRenderer: (params: any) => {
       const editBtn = document.createElement('button');
        editBtn.innerText = 'Edit';
        editBtn.className='btn btn-secondary btn-sm'
    ;
      
        editBtn.style.color = 'white';

        editBtn.addEventListener('click', () => {
          this.currentDoctor=params.data;
          this.isEdit=true;
          console.log(this.currentDoctor)
          this.OpenModel()
        });

        const deleteBtn = document.createElement('button');
        deleteBtn.innerText = 'Delete';
        deleteBtn.style.backgroundColor = '#f44336';
        deleteBtn.style.color = 'white';

        deleteBtn.addEventListener('click', () => {
          this.onDelete(params.data.id);
        });

        const container = document.createElement('div');
        container.appendChild(editBtn);
        container.appendChild(deleteBtn);

        return container;
          }
        }
    ];

    // Create doctor
    CreateDoctor(event:DoctorModel){
      this.doctorservice.create(event).subscribe((res)=>{
        this.rowData=[...this.rowData,res];
        this.doctorInstance.hide();
      })
    }

    // update docotr 
    UpdateDoctor(event:DoctorModel){
      this.doctorservice.update(event.id,event).subscribe((res)=>{
            console.log("data,updated",res);
            this.doctorInstance.hide();
      })
    }
      // ✅ Delete Method
  onDelete(id: number) {

    if (confirm('Are you sure you want to delete?')) {
         this.doctorservice.delete(id).subscribe((res)=>{
          this.rowData=this.rowData.filter((p)=>p.id!=id)

    })
    }
  }
    
}
