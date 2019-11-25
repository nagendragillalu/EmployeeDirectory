import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from '../employee-details.service';
import { TeamEmployees } from '../shared/TeamEmployees';
import {ActivatedRoute} from '@angular/router';
@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  teamEmployees: TeamEmployees;
  teamId: number;

  constructor(private team: EmployeeDetailsService,
              private route: ActivatedRoute) { }

ngOnInit() {
  this.teamId = this.route.snapshot.params['teamId'];
  this.team.getTeam(this.teamId)
  .subscribe(te => {
      this.teamEmployees = te;
     //console.log(this.teamEmployees);
     //console.log(this.teamEmployees.teamId);
    });

  }

}
