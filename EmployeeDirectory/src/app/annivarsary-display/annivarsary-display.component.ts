import { Component, OnInit } from '@angular/core';
import { Greetings } from '../shared/GreetingsData';
import { GreetingsService } from '../greetings.service';
import { NodeCompatibleEventEmitter } from 'rxjs/internal/observable/fromEvent';

@Component({
  selector: 'app-annivarsary-display',
  templateUrl: './annivarsary-display.component.html',
  styleUrls: ['./annivarsary-display.component.css']
})
export class AnnivarsaryDisplayComponent implements OnInit {

  breakpoint: number;
  public anniversaries: Greetings[];
  public bdays: Greetings[];
  annCount: number;
  bdayCount: number;
  constructor(private greetService: GreetingsService) { }

  ngOnInit() {
    this.breakpoint = (window.innerWidth <= 400) ? 2 : 6;

    this.greetService.getAllAnniver(new Date().getMonth() + 1)
    .subscribe(greet => {
      this.anniversaries = greet;
      this.annCount = this.anniversaries.length;
    });

    this.greetService.getAllBday(new Date().getMonth() + 1)
    .subscribe(greet => {
      this.bdays = greet;
      this.bdayCount = this.bdays.length;
    });

  }


  onResize(event) {
    this.breakpoint = (event.target.innerWidth <= 500) ? 2 : 6;
  }
}
