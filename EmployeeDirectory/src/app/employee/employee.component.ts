import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from '../employee-details.service';
import { EmployeeData } from '../shared/EmployeeData';
import {ActivatedRoute} from '@angular/router';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  public employeeData: EmployeeData;
  public empId: number;
  public photoURLChange: any;
  constructor(private employee: EmployeeDetailsService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.empId = this.route.snapshot.params['empId'];
    this.employee.getEmployees(this.empId)
    .subscribe(emp => {
      this.employeeData = emp;
      this.photoURLChange = emp.photoUrl + String(emp.employeeId);
  });
  }

}
