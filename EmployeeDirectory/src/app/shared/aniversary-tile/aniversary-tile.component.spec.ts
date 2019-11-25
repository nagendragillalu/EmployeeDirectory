import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AniversaryTileComponent } from './aniversary-tile.component';

describe('AniversaryTileComponent', () => {
  let component: AniversaryTileComponent;
  let fixture: ComponentFixture<AniversaryTileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AniversaryTileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AniversaryTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
