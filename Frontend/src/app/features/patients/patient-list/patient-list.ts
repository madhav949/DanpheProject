import { Component, OnChanges, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef } from 'ag-grid-community';
import { Patient } from '../../../core/services/patient';
import { PatientModel } from '../../../core/models/patient.model';
import * as bootstrap from 'bootstrap';
import { PatientUpdate } from "../patient-update/patient-update";

@Component({
  selector: 'app-patient-list',
  standalone: true,
  imports: [CommonModule, AgGridAngular, PatientUpdate],
  templateUrl: './patient-list.html',
  styleUrl: './patient-list.css',
})
export class PatientList implements OnInit {
  ModalInstance!: bootstrap.Modal;
  // testingInstance!:bootstrap.Modal;
  constructor(private patientService: Patient) {}
  rowData: PatientModel[] = [];
  currentPatient! : PatientModel 
  defaultcoldef = { flex: 1, resizable: true, sortable: true, fliter: true };
  colDefs: ColDef[] = [
    { field: 'id' },
    { field: 'fullName' },
    { field: 'phoneNumber' },
    { field: 'gender' },
    { field: 'address' },
    { field: 'dateOfAdmit' },

    // ✅ ACTION COLUMN
    {
      headerName: 'Actions',
      cellRenderer: (params: any) => {
        const editBtn = document.createElement('button');
        editBtn.innerText = 'Edit';
        editBtn.className='btn btn-secondary btn-sm'
    ;
      
        editBtn.style.color = 'white';

        editBtn.addEventListener('click', () => {
          this.currentPatient=params.data;
          this.openModal();
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
      },
    },
  ];
  ngOnInit(): void {
    this.loadPatients();

  }
  loadPatients() {
    this.patientService.getAll().subscribe((res) => {
      this.rowData = res;
      console.log(res);
    });
  }

  PatietnUpdate(event:any){
   
    this.ModalInstance.hide();
  }


  // ✅ Delete Method
  onDelete(id: number) {

    if (confirm('Are you sure you want to delete?')) {
         this.patientService.delete(id).subscribe((res)=>{
          this.rowData=this.rowData.filter((p)=>p.id!=id)

    })
    }
  }
//Model create
  openModal() {
    const UpdateModal = document.getElementById('patientUpdate');
    if (UpdateModal) {
      this.ModalInstance = new bootstrap.Modal(UpdateModal);
      this.ModalInstance.show();
    }
  }

//   testing(){
// const testingModal = document.getElementById('testing');
// if(testingModal){
//   this.testingInstance = new bootstrap.Modal(testingModal);
//   this.testingInstance.show();
// }
//   }
}
