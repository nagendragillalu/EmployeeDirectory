import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeDetails } from './employee-display/EmployeeDetails';
import { HttpClient } from '@angular/common/http';
import { EmployeeData, Team, Roles, Department, Skills,  } from './shared/EmployeeData';
import { map } from 'rxjs/operators';
import {TeamEmployees} from './shared/TeamEmployees';
import { HttpHeaders } from '@angular/common/http';
import { SocialUser, AuthService } from 'angularx-social-login';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {

  public teamDetails: Observable<TeamEmployees>;
  public user: SocialUser;

  constructor(private http: HttpClient, private authService: AuthService) {
    this.authService.authState.subscribe(user => this.user =  user);
   }

  getAllEmployees(): Observable<EmployeeData[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    return this.http.get<EmployeeData[]>('/api/employee', {headers});
  }

  getEmployees(empId: number): Observable<EmployeeData> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL: string = '/api/employee/' + empId;
    return this.http.get<EmployeeData>(URL, {headers});
  }

  getAllTeams(): Observable<Team[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    return this.http.get<Team[]>('/api/employee/team', {headers});
  }

  getTeam(teamId: number): Observable<TeamEmployees> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL: string = '/api/employee/team/' + teamId;
    this.teamDetails = this.http.get<TeamEmployees>(URL, {headers});
    return this.teamDetails;
  }

  getAllRoles(): Observable<Roles[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/getroles';
    return this.http.get<Roles[]>(URL, {headers});
  }

  getAllDepartments(): Observable<Department[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/department';
    return this.http.get<Department[]>(URL, {headers});
  }

  getAllSkills(): Observable<Skills[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/allskills';
    return this.http.get<Skills[]>(URL, {headers});
  }

  addEmployee(employeeData: any): Observable<number> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/add';
    return this.http.post<number>(URL, employeeData, {headers});
  }

  addTeam(teamData: any ): Observable<number> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/addTeam';
    return this.http.post<number>(URL, teamData, {headers});
  }

  addDepartment(departData: any): Observable<number> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/addDepartment';
    return this.http.post<number>(URL, departData, {headers});
  }

  addRole(roleData: any): Observable<number>  {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/addRole';
    return this.http.post<number>(URL, roleData, {headers});
  }

  addSkill(skillData: any): Observable<number> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/addSkill';
    return this.http.post<number>(URL, skillData, {headers});
  }

  getSkilledEmployee(skillID: number): Observable<any>  {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/skilledEmployee/' + skillID;
    return this.http.get<any>(URL, {headers});
  }

  getALLSpoc (): Observable<any> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL = '/api/employee/getspoc';
    return this.http.get<any>(URL, {headers});
  }
}
