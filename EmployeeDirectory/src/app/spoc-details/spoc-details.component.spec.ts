import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpocDetailsComponent } from './spoc-details.component';

describe('SpocDetailsComponent', () => {
  let component: SpocDetailsComponent;
  let fixture: ComponentFixture<SpocDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpocDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpocDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
