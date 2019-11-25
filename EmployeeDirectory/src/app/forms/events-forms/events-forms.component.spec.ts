import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsFormsComponent } from './events-forms.component';

describe('EventsFormsComponent', () => {
  let component: EventsFormsComponent;
  let fixture: ComponentFixture<EventsFormsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EventsFormsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventsFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
