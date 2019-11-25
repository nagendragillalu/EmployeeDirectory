import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FindTalentComponent } from './find-talent.component';

describe('FindTalentComponent', () => {
  let component: FindTalentComponent;
  let fixture: ComponentFixture<FindTalentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FindTalentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FindTalentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
