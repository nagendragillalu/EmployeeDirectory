import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Greetings } from './shared/GreetingsData';
import { AuthService, SocialUser } from 'angularx-social-login';

@Injectable({
  providedIn: 'root'
})
export class GreetingsService {

  public user: SocialUser;
    constructor(private http: HttpClient, private authService: AuthService) {
    this.authService.authState.subscribe(user => this.user =  user);
  }

  getAllBday(bdayMonth: number): Observable<Greetings[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL: string = '/api/greetings/bday/' + bdayMonth;
    return this.http.get<Greetings[]>(URL, {headers});
  }

  getAllAnniver(AnniverMonth: number): Observable<Greetings[]> {
    const headers = new HttpHeaders().set('id_token', this.user.idToken);
    const URL: string = '/api/greetings/anniversary/' + AnniverMonth;
    return this.http.get<Greetings[]>(URL, {headers});
  }
}
