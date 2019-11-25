import { Injectable } from '@angular/core';
import { EventDetails } from './shared/EventDetails';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { AuthService, SocialUser } from 'angularx-social-login';
/*
This service is responsible for retrieving all the events,
or a single event Details of the given Event ID.
*/

@Injectable({
  providedIn: 'root'
})
export class EventServiceService {
  public user: SocialUser;

  constructor(private http: HttpClient, private authService: AuthService) {
    // this.headers.set('id_token' , login.user.idToken);
    // console.log(login.user.idToken);
    this.authService.authState.subscribe(user => {
      this.user =  user;
    });
  }


  getAllEvents(): Observable<EventDetails[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
  return this.http.get<EventDetails[]>('api/events', { headers });
  }

  getEvent(eventId: number): Observable<EventDetails> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL: string = '/api/events/' + eventId;
  return this.http.get<EventDetails>(URL, { headers });
}

  addEvents(eventToAdd: any): Observable<String>  {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    return this.http.post<String>('/api/events/add', eventToAdd, { headers });
  }
}
