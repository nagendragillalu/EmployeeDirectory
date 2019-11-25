import { Component, OnInit } from '@angular/core';
import { Greetings } from '../shared/GreetingsData';
import { GreetingsService } from '../greetings.service';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {

  public birthDayCards: Greetings[];
  public AnniverCards: Greetings[];
  constructor(private greet:  GreetingsService) { }

  ngOnInit() {
    this.greet.getAllBday(new Date().getMonth() + 1)
    .subscribe(bday => this.birthDayCards = bday);

    this.greet.getAllAnniver(new Date().getMonth() + 1)
    .subscribe(AnnDay => this.AnniverCards = AnnDay);
  }

  test() {
    console.log(this.birthDayCards);
    console.log(this.AnniverCards);
  }
}
