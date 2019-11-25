import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsComponent } from './events.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { EventServiceService } from '../event-service.service';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';


describe('Events Component', () => {
  let component: EventsComponent;
  let fixture: ComponentFixture<EventsComponent>;
  let mockService;
  let dummyEvent;
  beforeEach(async(() => {
    mockService = jasmine.createSpyObj(['getAllEvents']);
    dummyEvent = [
        {
            eventId: 1,
            venu: 'String',
            eventDate: new Date(),
            eventFromTime: new Date(),
            eventToTime: new Date(),
            eventTimeZone: 'String',
            organizer: 'String',
            eventName: 'String',
            eventPhotoURL: 'String',
            eventDiscription: 'String'
        }
    ];
    mockService.getAllEvents.and.returnValue(of(dummyEvent));
    TestBed.configureTestingModule({
      declarations: [ EventsComponent ],
      providers: [
          {provide: EventServiceService, useValue: mockService }
        ],
      schemas: [NO_ERRORS_SCHEMA],
    })
    .compileComponents();

  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have list of events ', () => {
      const eventList  =  fixture.debugElement.queryAllNodes(By.css('#eventsBox'));
      expect(eventList.length).toBeGreaterThan(0);
  });

  it('should have dropdown accordion', () => {
      const accordion = fixture.debugElement.query(By.css('mat-accordion'));
      expect(accordion).toBeTruthy();
  });

  it('should show all the Event object properties', () => {
      expect(component.allEvents[0].eventId).toBeTruthy();
      expect(component.allEvents[0].venu).toBeTruthy();
      expect(component.allEvents[0].eventDate).toBeTruthy();
      expect(component.allEvents[0].eventFromTime).toBeTruthy();
      expect(component.allEvents[0].eventToTime).toBeTruthy();
      expect(component.allEvents[0].eventTimeZone).toBeTruthy();
      expect(component.allEvents[0].organizer).toBeTruthy();
      expect(component.allEvents[0].eventName).toBeTruthy();
      expect(component.allEvents[0].eventPhotoURL).toBeTruthy();
      expect(component.allEvents[0].eventDiscription).toBeTruthy();
  });

});
