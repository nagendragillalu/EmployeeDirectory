import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BirthdayTileComponent } from './birthday-tile.component';

describe('BirthdayTileComponent', () => {
  let component: BirthdayTileComponent;
  let fixture: ComponentFixture<BirthdayTileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BirthdayTileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BirthdayTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
