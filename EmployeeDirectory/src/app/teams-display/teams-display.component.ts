import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from '../employee-details.service';
import { Team } from '../shared/EmployeeData';
import {ActivatedRoute} from '@angular/router';
@Component({
  selector: 'app-teams-display',
  templateUrl: './teams-display.component.html',
  styleUrls: ['./teams-display.component.css']
})
export class TeamsDisplayComponent implements OnInit {

  public teamData: Team[];
  constructor(private teamEmployee: EmployeeDetailsService) { }

  ngOnInit() {
    this.teamEmployee.getAllTeams()
    .subscribe(team => this.teamData = team);
  }

}
