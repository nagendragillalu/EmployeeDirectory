import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterModule} from '@angular/router';
import { TeamsDisplayComponent } from './teams-display.component';
import { EmployeeDetailsService } from '../employee-details.service';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { By } from '@angular/platform-browser';
import { of } from 'rxjs';
import { Team } from '../shared/EmployeeData';


describe('Teams Display Component', () => {
  let component: TeamsDisplayComponent;
  let fixture: ComponentFixture<TeamsDisplayComponent>;
  let mockService;
  let dummyTeams: Team[];

  beforeEach(async(() => {
    mockService = jasmine.createSpyObj(['getAllTeams']);
    dummyTeams  = [
      {
        teamId: 1,
        teamName: 'Team Name',
        leadName: 'Team Leader Name',
        teamDicription: 'Team Discription'
      }
    ];
    TestBed.configureTestingModule({
      declarations: [ TeamsDisplayComponent ],
      providers: [
         {provide: EmployeeDetailsService, useValue: mockService}
        ],
      schemas: [NO_ERRORS_SCHEMA]
    })
    .compileComponents();

  }));

  beforeEach(() => {

    mockService.getAllTeams.and.returnValue(of(dummyTeams));
    fixture = TestBed.createComponent(TeamsDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have Team data', () => {
      expect(component.teamData[0].leadName).toBe('Team Leader Name');
  });

  it('should have Header as "All Teams"', () => {
    expect(fixture.nativeElement.querySelector('h2').textContent).toContain('All Teams');
    });

    it('should render Teams list with team name and Description', () => {
        expect(fixture.nativeElement.querySelector('h3').textContent).toEqual('Team Name');
        expect(fixture.nativeElement.querySelector('p').textContent).toEqual('Team Discription');
    });

    it('Should have links to teams details', () => {
        let deAnchor = fixture.debugElement.queryAll(By.css('a'));
        expect(deAnchor.length).toBeGreaterThan(0);
    });
});
