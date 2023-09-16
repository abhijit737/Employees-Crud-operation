import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs/internal/Observable';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl:string = environment.baseApiUrl;

  constructor( private http: HttpClient) { }

  // new method to talk with dot net 6 webAPI
  getAllEmployees(): Observable<Employee[]>{

    return  this.http.get<Employee[]>(this.baseApiUrl +'/api/employee');



  }


  // service to add form  and talk to api  
addEmployee(addEmployeeRequest: Employee):Observable<Employee>{
addEmployeeRequest.id='00000000-0000-0000-0000-000000000000'
 return this.http.post<Employee>(this.baseApiUrl +'/api/employee',addEmployeeRequest); 

}

getEmployee(id:string):Observable<Employee>{
 return this.http.get<Employee>(this.baseApiUrl+'/api/employee/'+id);
}


updateEmployee(id:string, updateEmployeeRequest: Employee):Observable<Employee>{
return this.http.put<Employee>(this.baseApiUrl+'/api/employee/'+id,updateEmployeeRequest);
}



deleteEmployee(id:string):Observable<Employee>{
  return this.http.delete<Employee>(this.baseApiUrl + '/api/employee/' + id);


}

}