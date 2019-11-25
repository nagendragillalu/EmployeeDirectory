import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EmployeeDisplayComponent } from './employee-display.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { MatMenuModule} from '@angular/material/menu';
import { FormsModule} from '@angular/forms';
import {EmployeeFilterPipe} from './employee-filter.pipe';
import { EmployeeDetailsService } from '../employee-details.service';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';

describe('EmployeeDisplayComponent', () => {
  let component: EmployeeDisplayComponent;
  let fixture: ComponentFixture<EmployeeDisplayComponent>;
  let mockService;
  let dummyEmoloyees;
  beforeEach(async(() => {
    mockService = jasmine.createSpyObj(['getAllEmployees']);
    dummyEmoloyees = [
        {
            employeeId: 1,
            firstName: 'String',
            lastName: 'String',
            dob: new Date(),
            joiningDate: new Date(),
            emailId: 'String',
            photoUrl: 'String',
            role: {role: 'String'}
        }
    ];
    mockService.getAllEmployees.and.returnValue(of(dummyEmoloyees));
    TestBed.configureTestingModule({
      declarations: [ EmployeeDisplayComponent , EmployeeFilterPipe],
      schemas: [ NO_ERRORS_SCHEMA],
      providers : [
          {provide: EmployeeDetailsService, useValue: mockService}
      ],
      imports: [MatMenuModule, FormsModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have search box', () => {
    const searchBox =  fixture.debugElement.query(By.css('#searchbox'));
    expect(searchBox).toBeTruthy();
  });

  it('should have search selection list', () => {
    const searchSelection =  fixture.debugElement.query(By.css('#searchSelection'));
    expect(searchSelection).toBeTruthy();
  });

  it('should list all the employees tiles', () => {
    const empTiles = fixture.debugElement.queryAllNodes(By.css('mat-grid-tile'));
    expect(empTiles.length).toBeGreaterThan(0);
  });

});
