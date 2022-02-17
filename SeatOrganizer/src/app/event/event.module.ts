import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventDetailsComponent } from './event-details/event-details.component';
import { EventListComponent } from './event-list/event-list.component';
import { EventService } from './event.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [EventDetailsComponent, EventListComponent],
  imports: [
    CommonModule, FormsModule, HttpClientModule, BrowserModule
  ], providers: [EventService],
  exports: [EventDetailsComponent]

})
export class EventModule { }
