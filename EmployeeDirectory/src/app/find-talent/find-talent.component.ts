import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from '../employee-details.service';
import { Skills } from '../shared/EmployeeData';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-find-talent',
  templateUrl: './find-talent.component.html',
  styleUrls: ['./find-talent.component.css']
})
export class FindTalentComponent implements OnInit {

public skillList: Skills[];
public employeeSkilled: any[];
public searchSkillId: number;
public empCount: number;

  constructor(private skillEmployee: EmployeeDetailsService) { }

  ngOnInit() {
    this.empCount = 1;
    this.skillEmployee.getAllSkills()
    .subscribe(s => this.skillList = s);
  }

  getSkilledEmployee() {
    console.log(this.searchSkillId);
    this.skillEmployee.getSkilledEmployee(this.searchSkillId)
    .subscribe( sEmp => {
      this.employeeSkilled = sEmp;
      this.empCount = this.employeeSkilled.length;
      console.log(this.employeeSkilled);
      console.log(this.empCount);
  });
  }

}
