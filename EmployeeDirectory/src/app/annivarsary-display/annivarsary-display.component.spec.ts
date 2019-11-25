import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnnivarsaryDisplayComponent } from './annivarsary-display.component';

describe('AnnivarsaryDisplayComponent', () => {
  let component: AnnivarsaryDisplayComponent;
  let fixture: ComponentFixture<AnnivarsaryDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnnivarsaryDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnnivarsaryDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
