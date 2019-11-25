import { Component, OnInit } from '@angular/core';
import { EventServiceService } from '../event-service.service';
import { EventDetails } from '../shared/EventDetails';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  public allEvents: EventDetails[];
  constructor(private eventList: EventServiceService) { }

  ngOnInit() {
    this.eventList.getAllEvents().subscribe(e => this.allEvents = e);
  }

}
