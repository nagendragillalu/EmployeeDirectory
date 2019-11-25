import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {EmployeeComponent} from './employee/employee.component';
import { EmployeeDisplayComponent } from './employee-display/employee-display.component';
import { TeamComponent } from './team/team.component';
import { TeamsDisplayComponent } from './teams-display/teams-display.component';
import { EventsComponent } from './events/events.component';
import { EventsFormsComponent } from './forms/events-forms/events-forms.component';
import { EmployeeFormComponent } from './forms/employee-form/employee-form.component';
import { PickDataComponent } from './forms/pick-data/pick-data.component';
import { AnnivarsaryDisplayComponent } from './annivarsary-display/annivarsary-display.component';
import { FindTalentComponent } from './find-talent/find-talent.component';
import { SpocDetailsComponent } from './spoc-details/spoc-details.component';

const routes: Routes = [
  {path: 'employee/:empId', component : EmployeeComponent },
  {path: 'employee', component : EmployeeDisplayComponent },
  {path: 'teams', component: TeamsDisplayComponent},
  {path: 'teams/:teamId', component: TeamComponent},
  {path: 'events', component: EventsComponent},
  {path: 'addevents', component: EventsFormsComponent},
  {path: 'addemployee', component: EmployeeFormComponent},
  {path: 'addpickdata', component: PickDataComponent},
  {path: 'allAnnivarsaries', component: AnnivarsaryDisplayComponent},
  {path: 'findtalent' , component: FindTalentComponent},
  {path: 'spoc', component: SpocDetailsComponent},
  {path: '', redirectTo: 'employee', pathMatch: 'full'},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
