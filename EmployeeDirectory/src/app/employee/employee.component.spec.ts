import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeComponent } from './employee.component';
import {MatDividerModule} from '@angular/material/divider';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { EmployeeDetailsService } from '../employee-details.service';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;
  let mockService;
  let dummyEmployeeData;
  beforeEach(async(() => {
      mockService = jasmine.createSpyObj(['getEmployees']);
      dummyEmployeeData ={
            employeeId: 1,
            firstName: 'FirstName',
            lastName: 'LastName',
            dob: new Date(),
            joiningDate: new Date(),
            emailId: 'Email String',
            photoUrl: 'Url link of Employee Photo',
            role: {roleName: 'Manager'},
            departmnent: {departmnetName: 'Department Name'},
            team: {teamName: 'Team Name', teamLeader: 'Team Leader'},
            contactDetail: {mobNumber: 123456789, skypeId: 'Skype ID'},
            bio: {about: 'Self Intro', hobbies: 'Employee Hobbies'},
            employeeSkills: [{}, {}, {}]
        };
      mockService.getEmployees.and.returnValue(of(dummyEmployeeData));
    TestBed.configureTestingModule({
      declarations: [ EmployeeComponent ],
      imports: [MatDividerModule],
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
          {provide: EmployeeDetailsService, useValue: mockService},
          {provide: ActivatedRoute, useValue: {
            snapshot:
                {
                    params: [{ empId: 1 }]
                }
            }
           }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have header with employee first name', () => {
    const titleName = fixture.debugElement.query(By.css('h2'));
    expect(titleName.nativeElement.textContent).toContain('FirstName');
  });
});
