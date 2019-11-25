import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EventServiceService } from 'src/app/event-service.service';
import { EventDetails } from 'src/app/shared/EventDetails';

@Component({
  selector: 'app-events-forms',
  templateUrl: './events-forms.component.html',
  styleUrls: ['./events-forms.component.css']
})
export class EventsFormsComponent implements OnInit {

  public model;
  public eventForm = new FormGroup({
    eventName: new FormControl('', [Validators.maxLength(50),
                                    Validators.minLength(2),
                                    Validators.required]),
    organizer: new FormControl('', [Validators.maxLength(50),
                                    Validators.minLength(2),
                                    Validators.required]),
    eventDiscription: new FormControl('', [Validators.maxLength(50),
                                           Validators.minLength(2),
                                           Validators.required]),
    venu: new FormControl('',  [Validators.maxLength(50),
                                Validators.minLength(2),
                                Validators.required]),
    eventDate: new FormControl('', Validators.required),
    eventFromTime: new FormControl('', Validators.required),
    eventToTime:  new FormControl('', Validators.required),
    eventTimeZone: new FormControl('', Validators.required)
  });

  public returnString: String;

constructor(private eventDetails: EventServiceService) { }

  ngOnInit() {
  }

  onSubmit() {
    console.log(this.eventForm.valid);
    this.eventDetails.addEvents(this.eventForm.value)
    .subscribe(rt => this.returnString = rt );
  }

  onReset() {
    this.eventForm.reset();
  }
}
