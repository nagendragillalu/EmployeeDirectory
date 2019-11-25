import { BrowserModule } from '@angular/platform-browser';
import { NgModule} from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { NotificationComponent } from './notification/notification.component';
import { HeaderComponent } from './header/header.component';
import { EmployeeDisplayComponent } from './employee-display/employee-display.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import {EmployeeFilterPipe} from './employee-display/employee-filter.pipe';
import { ReactiveFormsModule } from '@angular/forms';
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider, FacebookLoginProvider, LinkedInLoginProvider} from 'angularx-social-login';
import { CommonModule} from '@angular/common';
import {
  MatAutocompleteModule,
  MatBadgeModule,
  MatBottomSheetModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatTreeModule,
} from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { EmployeeTileComponent } from './shared/employee-tile/employee-tile.component';
import { BirthdayTileComponent } from './shared/birthday-tile/birthday-tile.component';
import { AniversaryTileComponent } from './shared/aniversary-tile/aniversary-tile.component';
import { EmployeeComponent } from './employee/employee.component';
import { TeamsDisplayComponent } from './teams-display/teams-display.component';
import { TeamComponent } from './team/team.component';
import { EventsComponent } from './events/events.component';
import { LoginComponent } from './login/login.component';
import { EventsFormsComponent } from './forms/events-forms/events-forms.component';
import { EmployeeFormComponent } from './forms/employee-form/employee-form.component';
import { PickDataComponent } from './forms/pick-data/pick-data.component';
import { AnnivarsaryDisplayComponent } from './annivarsary-display/annivarsary-display.component';
import { FindTalentComponent } from './find-talent/find-talent.component';
import { SpocDetailsComponent } from './spoc-details/spoc-details.component';

let config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('1043877580067-nmccan8uk5cusls19r0hu3clm4c912g8.apps.googleusercontent.com')
  },
  // {
  //   id: FacebookLoginProvider.PROVIDER_ID,
  //   provider: new FacebookLoginProvider("Facebook-App-Id")
  // },
  // {
  //   id: LinkedInLoginProvider.PROVIDER_ID,
  //   provider: new LinkedInLoginProvider("LinkedIn-client-Id", false, 'en_US')
  // }
]);

export function provideConfig() {
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    NotificationComponent,
    HeaderComponent,
    EmployeeDisplayComponent,
    EmployeeTileComponent,
    BirthdayTileComponent,
    AniversaryTileComponent,
    EmployeeComponent,
    TeamsDisplayComponent,
    TeamComponent,
    EventsComponent,
    EmployeeFilterPipe,
    LoginComponent,
    EventsFormsComponent,
    EmployeeFormComponent,
    PickDataComponent,
    AnnivarsaryDisplayComponent,
    FindTalentComponent,
    SpocDetailsComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CdkTableModule,
    CdkTreeModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    NgbModule,
    HttpClientModule,
    SocialLoginModule,
  ],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
