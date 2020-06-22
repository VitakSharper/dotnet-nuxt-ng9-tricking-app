import {Component, OnInit} from '@angular/core';
import {TrickingService} from './_services/tricking.service';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  message: Observable<string>;

  constructor(private trickingService: TrickingService) {
  }

  ngOnInit(): void {
    this.message = this.trickingService.getHomeApi();
  }
}
