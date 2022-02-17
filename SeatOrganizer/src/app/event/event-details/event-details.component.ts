import { Component, OnInit } from '@angular/core';
import { EventService } from '../event.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.scss']
})
export class EventDetailsComponent implements OnInit {

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    debugger
    this.eventService.getEvent(5).subscribe(data => {
      debugger
      alert(data);
    })
  }


}
