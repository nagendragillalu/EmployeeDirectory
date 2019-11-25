import {TestBed} from '@angular/core/testing';
import {EmployeeDetailsService} from './employee-details.service';
import {HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { EmployeeData } from './shared/EmployeeData';
import { of } from 'rxjs';
import { AuthService } from 'angularx-social-login';

describe('EmployeeDetails Service', () => {
  let service: EmployeeDetailsService;
  let httpMock: HttpTestingController;
  let dummyEmployees: any[];
  let dummyTeams: any[];
  let dummyAuthService;
  const dummyUserAuth = {idToken: 'Google JWT token'};

  beforeEach(() => {
    //dummyAuthService = jasmine.createSpyObj(['']);
   // const dummyAuthService = spyOnProperty(AuthService, 'authState').and.returnValue(of(dummyUserAuth));
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
          EmployeeDetailsService,
          {provide: AuthService, useValue: dummyAuthService}
        ],
    });

    service = TestBed.get(EmployeeDetailsService);
    httpMock = TestBed.get(HttpTestingController);

    dummyEmployees = [
        {
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
        },
        {
          employeeId: 2,
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
      }
      ];

      dummyTeams = [
        {
          teamId: 1,
          teamName: 'Team Name',
          leadName: 'Team Leader Name',
          teamDicription: 'Team Discription'
        }
      ];
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('Get All the Employee List', () => {

    it('should get List of Employee', () => {
        service.getAllEmployees().subscribe(data => {
            expect(data.length).toBeGreaterThan(0);
        });
        const req = httpMock.expectOne(`/api/employee`, 'All the Employees from Backend');
        expect(req.request.method).toBe('GET');
        req.flush(dummyEmployees);
        httpMock.verify();
    });
  });

  describe('Get Single Employee Details for given Employee ID', () => {

    it('should get List of Employee', () => {
        service.getEmployees(2).subscribe(data => {
            expect(typeof(data)).toBe('object');
        });
        const req = httpMock.expectOne(`/api/employee/2`, 'Get single Employee only');
        expect(req.request.method).toBe('GET');
        req.flush(dummyEmployees);
        httpMock.verify();
    });

    it('should  get values of all the properties of Employee object', () => {
      service.getEmployees(2).subscribe(data => {
          expect(data.firstName).not.toBeNull();
          expect(data.lastName).not.toBeNull();
          expect(data.dob).not.toBeNull();
          expect(data.role).not.toBeNull();
          expect(data.role).not.toBeNull();
          expect(data.team).not.toBeNull();
          expect(data.joiningDate).not.toBeNull();
          expect(data.contactDetail).not.toBeNull();
      });
      const req = httpMock.expectOne(`/api/employee/2`, 'Get single Employee only');
      expect(req.request.method).toBe('GET');
      req.flush(dummyEmployees);
      httpMock.verify();
  });

  });


  describe('Get All the Teams List', () => {

    it('should get List of Teams', () => {
        service.getAllTeams().subscribe(data => {
            expect(data.length).toBeGreaterThan(0);
        });
        const req = httpMock.expectOne(`/api/employee/team`, 'All the Teams from Backend');
        expect(req.request.method).toBe('GET');
        req.flush(dummyTeams);
        httpMock.verify();
    });
  });

  describe('Get Single Team Details for given Team ID', () => {

    it('should get List of Teams', () => {
        service.getTeam(2).subscribe(data => {
            expect(typeof(data)).toBe('object');
        });
        const req = httpMock.expectOne(`/api/employee/team/2`, 'Get single Team only');
        expect(req.request.method).toBe('GET');
        req.flush(dummyTeams);
        httpMock.verify();
    });

    it('should  get values of all the properties of Team object', () => {
      service.getTeam(2).subscribe(data => {
          expect(data.teamId).not.toBeNull();
          expect(data.teamName).not.toBeNull();
          expect(data.teamDiscription).not.toBeNull();
          expect(data.leadName).not.toBeNull();
      });
      const req = httpMock.expectOne(`/api/employee/team/2`, 'Get single Team only');
      expect(req.request.method).toBe('GET');
      req.flush(dummyTeams);
      httpMock.verify();
  });

  });

});
