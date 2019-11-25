import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators,  } from '@angular/forms';
import { EmployeeDetailsService } from 'src/app/employee-details.service';
import { Roles, Department, Team, Skills } from 'src/app/shared/EmployeeData';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  public step = 0;
  public roles: Roles[];
  public departments: Department[];
  public teams: Team[];
  public skills: Skills[];
  public addStatusEmployeeCode: number;

  public employeeForm = new FormGroup({
    firstName : new FormControl('', [Validators.required,
                                    Validators.maxLength(20),
                                    Validators.minLength(2)]),
    lastName : new FormControl('', [Validators.required,
                                    Validators.maxLength(20),
                                    Validators.minLength(2)]),
    dob : new FormControl('', Validators.required),
    joiningDate : new FormControl('', Validators.required),
    emailId : new FormControl('', [Validators.required,
                                   Validators.email]),
    photoUrl : new FormControl(),
    SPOC : new FormControl(),
    role : new FormGroup({
      roleId : new FormControl('', [Validators.required])
    }),
    departmnent : new FormGroup({
      departmentId : new FormControl('', [Validators.required]),
    }),
    team : new FormGroup({
      teamId: new FormControl('', [Validators.required]),
    }),
    contactDetail : new FormGroup({
      mobileOffice: new FormControl('', [Validators.required,
                                        Validators.pattern('^[0-9]*$'),
                                        Validators.maxLength(10)]),
      mobilePersonal: new FormControl('', [Validators.required,
                                          Validators.pattern('^[0-9]*$'),
                                          Validators.maxLength(10)]),
      skypeId: new FormControl('', Validators.maxLength(50)),
      slackId: new FormControl('', Validators.maxLength(50)),
      address: new FormControl('', Validators.maxLength(250)),
      fbLink: new FormControl('', Validators.maxLength(50)),
      twitterLink: new FormControl('', Validators.maxLength(50)),
      gitHubLink: new FormControl('', Validators.maxLength(50)),
      linkdinLink: new FormControl('', Validators.maxLength(50))
    }),
    bio : new FormGroup({
      about: new FormControl('', Validators.required),
      hobbies: new FormControl(),
      interests: new FormControl()
    }),
    employeeSkills : new FormArray([
      this.addSkillFormGroup()
    ])
  });

  constructor(private empService: EmployeeDetailsService) { }

  ngOnInit() {
    this.empService.getAllRoles().subscribe(r => this.roles = r);
    this.empService.getAllTeams().subscribe(t => this.teams = t);
    this.empService.getAllDepartments().subscribe(d => this.departments = d);
    this.empService.getAllSkills().subscribe(s => this.skills = s);
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  prevStep() {
    this.step--;
  }

  addFormGroup() {
    (<FormArray>this.employeeForm.get('employeeSkills')).push(this.addSkillFormGroup());
  }

  addSkillFormGroup(): FormGroup {
    return new FormGroup({
      skillId: new FormControl(''),
      skillLevel: new FormControl('')
    });
  }

  onSubmit() {
    console.log(this.employeeForm.valid);
     this.empService.addEmployee(this.employeeForm.value).subscribe(s => {this.addStatusEmployeeCode = s;
    console.log(this.addStatusEmployeeCode); });
    this.employeeForm.reset();
  }

  onReset() {
    console.log(this.employeeForm.get('contactDetail.mobileOffice').errors.maxlength);
    this.employeeForm.reset();
  }

  addNewEmployee() {
    this.addStatusEmployeeCode = null;
  }

}
