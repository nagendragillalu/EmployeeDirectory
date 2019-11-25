import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuComponent } from './menu.component';

describe('MenuComponent', () => {
  let component: MenuComponent;
  let fixture: ComponentFixture<MenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be create', () => {
    expect(component).toBeTruthy();
  });

  it('should have Directory,Teams,Anniversaries,Find Talent,SPOC option', () => {
      const menuItem = fixture.nativeElement.querySelectorAll('button');
      expect(menuItem[0].textContent).toEqual('Directory');
      expect(menuItem[1].textContent).toEqual('Teams');
      expect(menuItem[2].textContent).toEqual('Events');
      expect(menuItem[3].textContent).toEqual('Anniversaries');
      expect(menuItem[4].textContent).toEqual('Find Talent');
      expect(menuItem[5].textContent).toEqual('SPOC');
  });

  it('should have route to Employees Directory', () => {
    const linkItem = fixture.nativeElement.querySelector('a[routerLink="employee"]');
    expect(linkItem).toBeTruthy();
    });

    it('should have route to Teams', () => {
        const linkItemTeams = fixture.nativeElement.querySelector('a[routerLink="teams"]');
        expect(linkItemTeams).toBeTruthy();
    });

    it('should have route to Events', () => {
        const linkItemEvents = fixture.nativeElement.querySelector('a[routerLink="events"]');
        expect(linkItemEvents).toBeTruthy();
    });

});
