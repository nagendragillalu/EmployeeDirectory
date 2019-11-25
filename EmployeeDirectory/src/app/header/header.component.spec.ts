import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderComponent } from './header.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { By } from '@angular/platform-browser';
import { by } from 'protractor';
import { SocialUser } from 'angularx-social-login';

describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderComponent ],
      schemas: [NO_ERRORS_SCHEMA]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have Site title as "EMployee Directory"', () => {
     const header = fixture.debugElement.query(By.css('h1'));
     expect(header.nativeElement.textContent).toBe('Employee Directory');
  });

  it('should have site image', () => {
      const siteimage = fixture.debugElement.query(By.css('#siteimage'));
      expect(siteimage).not.toBeNull();
  });

  it('should not show user avatar, Name and sign out when not logged in', () => {
     component.userData = null;
     console.log(component.userData);
     const userIcon  = fixture.debugElement.query(By.css('mat-icon'));
     console.log(userIcon);
     expect(userIcon).toBeNull();
  });

  it('should show user avatar, Name and sign out when user logged in', () => {
    const user = new SocialUser();
    user.firstName = 'some name';
    component.userData = user;
    console.log(component.userData);
    const userIcon  = fixture.debugElement.queryAllNodes(By.css('.inset'));
    console.log(userIcon);
    expect(userIcon).not.toBeNull();
   });

});
