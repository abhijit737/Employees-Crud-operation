import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})

export class EmployeesListComponent implements OnInit {

  
  employees: Employee[]=[
  // {
  //  id:"c705cd8b-0297-441c-af5b-102620816a70",
  //   name:'Akash Kumar',
  //   email:"akashkumar@gmail.com",
  //   phone:7567452145,
  //   salary:48000,
  //   department:"Computer Science"
  // },
  // {
  //   id:"c705cd8b-0297-441c-af5b-102620816a70",
  //    name:'Vikas Mane',
  //    email:"vikasmane@gmail.com",
  //    phone:7563452145,
  //    salary:45000,
  //    department:"Computer Science"
  //  },
  //  {
  //   id:"c705cd8b-0297-441c-af5b-102620816a70",
  //    name:'Rakesh Sharma',
  //    email:"rakeshsharma@gmail.com",
  //    phone:7556752145,
  //    salary:42000,
  //    department:"Computer Science"
  //  }
  ];
//employee: any;

  //DI
  constructor(private employeesService: EmployeesService){


  }

  // metohd to show data on main page
 

  ngOnInit(): void {
    this.employeesService.getAllEmployees()
    .subscribe({
      next:(employees)=>{
        // console.log(employees);

        this.employees=employees;
      },
    error: (response)=>
    {
      console.log(response);
    }
    })

//  //   this.employees.push()

//     throw new Error('Method not implemented.');
//   }

 }
// function subscribe(arg0: { next: (employees: any) => void; }) {
//   throw new Error('Function not implemented.');
 }