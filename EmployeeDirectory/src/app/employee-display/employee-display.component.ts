import { Component, OnInit } from '@angular/core';
//import {MatCardModule} from '@angular/material/card';
import { EmployeeDetailsService } from '../employee-details.service';
import {EmployeeDetails} from './EmployeeDetails';

@Component({
  selector: 'app-employee-display',
  templateUrl: './employee-display.component.html',
  styleUrls: ['./employee-display.component.css']
})
export class EmployeeDisplayComponent implements OnInit {

  public _employee_list: EmployeeDetails[];
  public searchBy: string;
  public searchString: String;
  breakpoint: number;
  constructor(private empDetails: EmployeeDetailsService) { }

  ngOnInit() {
    this.empDetails.getAllEmployees()
    .subscribe(emp => this._employee_list = emp);

    this.breakpoint = (window.innerWidth <= 400) ? 2 : 6;
  }

  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 500) ? 2 : 6;
  }

  byEmployeeId(): void {
      this.searchBy = 'Please Enter Employee ID';
  }

  byFirstName(): void {
    this.searchBy = 'Please Enter First Name';
  }

  byLastName(): void {
    this.searchBy = 'Please Enter Last Name';
  }

}
