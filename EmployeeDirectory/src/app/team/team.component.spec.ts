import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EmployeeDetailsService } from '../employee-details.service';
import { TeamComponent } from './team.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';

describe('TeamComponent', () => {
  let component: TeamComponent;
  let fixture: ComponentFixture<TeamComponent>;
  let mockEmployeeDetailService;
  let dummyValue;

  beforeEach(async(() => {
    mockEmployeeDetailService = jasmine.createSpyObj(['getTeam']);
    dummyValue = {
            teamId: 1,
            teamName: 'Team Name 1',
            leadName: 'Lead Name 1',
            teamDiscription: 'Team Discription 1',
            teamEmployees: [{
                role : {roleName: 'sample role'}
            }]
        };
    mockEmployeeDetailService.getTeam.and.returnValue(of(dummyValue));
    TestBed.configureTestingModule({
      declarations: [ TeamComponent ],
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
          {provide: EmployeeDetailsService, useValue: mockEmployeeDetailService},
          {provide: ActivatedRoute,
            useValue: {
                snapshot:
                    {
                        params: [{ teamId: 1 }]
                    }
          }}
        ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it('should get team details for given team ID', () => {
        expect(component.teamEmployees).not.toBeNull();
        expect(component.teamId).not.toEqual(1);
    });

    it ('should render Team ID, Team Name, Team Lead, Team Description', () => {
        const teamData = fixture.debugElement.queryAll(By.css('td'));
        expect(teamData[0].nativeElement.textContent).toBe('Team ID :');
        expect(teamData[1].nativeElement.textContent).toBe('1');
        expect(teamData[2].nativeElement.textContent).toBe('Team Name :');
        expect(teamData[3].nativeElement.textContent).toBe('Team Name 1');
        expect(teamData[4].nativeElement.textContent).toBe('Team Lead :');
        expect(teamData[5].nativeElement.textContent).toBe('Lead Name 1');
        expect(teamData[6].nativeElement.textContent).toBe('Team Description :');
        expect(teamData[7].nativeElement.textContent).toBe('Team Discription 1');
    });

    it('should have Tile saying "Team Name Details" & "Team Name Members"', () => {
        const title = fixture.debugElement.queryAll(By.css('h2'));
        expect(title[0].nativeElement.textContent).toContain(' Details');
        expect(title[1].nativeElement.textContent).toContain(' Members');
    });

    it('should have list of employees in the team', () => {
        expect(component.teamEmployees.teamEmployees.length).toBeGreaterThan(0);
    });

});
