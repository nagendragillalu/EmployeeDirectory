import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EmployeeDetailsService } from 'src/app/employee-details.service';

@Component({
  selector: 'app-pick-data',
  templateUrl: './pick-data.component.html',
  styleUrls: ['./pick-data.component.css']
})
export class PickDataComponent implements OnInit {

  public addRoleStatus: any;
  public addDepartmentStatus: any;
  public addTeamStatus: any;
  public addSkillStatus: any;

  public roleForm = new FormGroup({
    roleName : new FormControl('', Validators.required)
  });

  public departmentForm = new FormGroup({
    departmentName : new FormControl('', Validators.required),
    DepartmentDisc : new FormControl('', ),
    DepartHeadName: new FormControl('', )
  });

  public teamForm = new FormGroup({
    teamName : new FormControl('', Validators.required),
    leadName : new FormControl(''),
    teamDicription : new FormControl()
  });

  public skillForm = new FormGroup({
    skillName : new FormControl('', Validators.required)
  });

  public messageForm = new FormGroup({

  });

  constructor(private addlistdata: EmployeeDetailsService) { }

  ngOnInit() {
  }

  saveRole(): any  {
    console.log(this.roleForm.value);
    this.addlistdata.addRole(this.roleForm.value)
    .subscribe(r => this.addRoleStatus = r );
    this.roleForm.reset();
  }

  saveDepartment(): any {
    console.log(this.departmentForm.value);
    this.addlistdata.addDepartment(this.departmentForm.value)
    .subscribe(d => this.addDepartmentStatus = d);
    this.departmentForm.reset();
  }

  saveTeam(): any {
    console.log(this.teamForm.value);
    this.addlistdata.addTeam(this.teamForm.value)
    .subscribe(t => this.addTeamStatus = t);
    this.teamForm.reset();
  }

  saveSkill(): any {
    console.log(this.skillForm.value);
    this.addlistdata.addSkill(this.skillForm.value)
    .subscribe(t => {this.addSkillStatus = t;
    console.log(this.addSkillStatus); });
    this.skillForm.reset();
  }

}
