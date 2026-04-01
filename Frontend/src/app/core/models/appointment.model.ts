export interface AppointmentModel {
    id?:number;
    DoctorId:number;
    PatientId:number;
    Status:number;
    AppointmentDate:string;

    DocFullName?:string;
    FullName?:string;
}
