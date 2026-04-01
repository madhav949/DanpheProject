import { Routes } from '@angular/router';
import { PatientDetail } from './features/patients/patient-detail/patient-detail';
import { Appointment } from './core/services/appointment';
import { Doctor } from './core/services/doctor';
import { Department } from './core/services/department';
import { AppointmentList } from './features/appointments/appointment-list/appointment-list';
import { DoctorList } from './features/doctors/doctor-list/doctor-list';
import { DepartmentList } from './features/departments/department-list/department-list';

export const routes: Routes = [
    {
        path:'patient',
        component:PatientDetail
    },
    {
        path:'appointment',
        component:AppointmentList
    },
    {
        path:'doctors',
        component: DoctorList
    },
    {
        path:'departments',
        component:DepartmentList
    }
    

];
