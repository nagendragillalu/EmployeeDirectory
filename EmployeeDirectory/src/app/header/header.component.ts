import { Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import { SocialUser } from 'angularx-social-login';




@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {
  @Input() userData: SocialUser;
  @Output() signOut = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  callSignOut() {
    console.log('sign out');
    this.signOut.emit();
  }
}
