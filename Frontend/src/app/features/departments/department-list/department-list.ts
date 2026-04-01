import { Component, OnInit } from '@angular/core';
import { DepartmentModel } from '../../../core/models/department.model';
import { ColDef  } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';
import { Department } from '../../../core/services/department';

@Component({
  selector: 'app-department-list',
  imports: [AgGridAngular],
  templateUrl: './department-list.html',
  styleUrl: './department-list.css',
})
export class DepartmentList implements OnInit{
  constructor(private DepartmentService:Department){

  }
rowData: DepartmentModel[] = [];
  defaultcoldef = { flex: 1, resizable: true, sortable: true, fliter: true };
  colDefs: ColDef[] = [
    { field: 'id' },
    { field: 'name' },
    { field: 'description' },

  ]
  ngOnInit(): void {
      this.loadAllDepartment();
  }
  loadAllDepartment(){
    this.DepartmentService.getAll().subscribe((res)=>
    {
      this.rowData = res;
      console.log(res);
    }
    )
  }
}
