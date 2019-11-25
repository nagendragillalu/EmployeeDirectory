import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from '../employee-details.service';

@Component({
  selector: 'app-spoc-details',
  templateUrl: './spoc-details.component.html',
  styleUrls: ['./spoc-details.component.css']
})
export class SpocDetailsComponent implements OnInit {

  public spocList: any[];
  constructor(private employeeDetails: EmployeeDetailsService) { }

  ngOnInit() {
    this.employeeDetails.getALLSpoc()
    .subscribe(spoc => this.spocList = spoc);
  }

}
