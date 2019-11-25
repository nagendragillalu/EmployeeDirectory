import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AuthService } from 'angularx-social-login';
import { LoginComponent } from './login.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { of } from 'rxjs';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let mockAuthService;
  let dummyUser;
  beforeEach(async(() => {

    mockAuthService = jasmine.createSpyObj(['signInWithGoogle', 'signOut']);
    const spy = spyOnProperty(mockAuthService, 'authState').and.returnValue(of(dummyUser));
    dummyUser = {};
    mockAuthService.signInWithGoogle.and.returnValue(of(dummyUser));
    mockAuthService.signOut.and.returnValue(of(dummyUser));

    TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
          {provide: AuthService, useValue: mockAuthService}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    component.user = dummyUser;
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
