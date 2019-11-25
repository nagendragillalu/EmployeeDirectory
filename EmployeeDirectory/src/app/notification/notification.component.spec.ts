import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { GreetingsService } from '../greetings.service';
import { NotificationComponent } from './notification.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';

describe('Notification Component', () => {
  let component: NotificationComponent;
  let fixture: ComponentFixture<NotificationComponent>;
  let mockService;
  let dummyGreetings;
  beforeEach(async(() => {
    mockService = jasmine.createSpyObj(['getAllBday', 'getAllAnniver']);
    dummyGreetings = [
        {
            employeeId: 1,
            fName: 'first',
            lName: 'last',
            greetDate: new Date(),
            eMail: 'emailString',
            twitter: 'twitterString',
            facebook: 'fbString',
            yearCount: '2',
            photoUrl: 'photoURLString'
        }
    ];
    mockService.getAllBday.and.returnValue(of(dummyGreetings));
    mockService.getAllAnniver.and.returnValue(of(dummyGreetings));

    TestBed.configureTestingModule({
      declarations: [ NotificationComponent ],
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
          {provide: GreetingsService, useValue: mockService}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should Display Birthday Cards if Birthday exists', () => {
    const heading = fixture.debugElement.queryAll(By.css('h3'));
    expect(component.birthDayCards).not.toBeNull();
    expect(heading[0].nativeElement.textContent).toContain('Birthday');
  });

  it('should not Display Birthday Cards if Birthday doesnot exists', () => {
    component.birthDayCards = null;
    const heading = fixture.debugElement.queryAll(By.css('h3'));
    expect(component.birthDayCards).toBeNull();
  });

  it('should Display Anniversary Cards if Anniversary exists', () => {
    const heading = fixture.debugElement.queryAll(By.css('h3'));
    expect(component.birthDayCards).not.toBeNull();
    expect(heading[1].nativeElement.textContent).toContain('Anniversaries');
  });

  it('should not Display Anniversary Cards if Anniversary doesnot exists', () => {
    component.birthDayCards = null;
    const heading = fixture.debugElement.queryAll(By.css('h3'));
    expect(component.birthDayCards).toBeNull();
  });

  it('should render carousel', () => {
      const carousel = fixture.debugElement.queryAll(By.css('ng-carousel'));
      expect(carousel).not.toBeNull();
  });
});
