import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from 'src/shared/http-services/event.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {

  constructor(private eventService : EventService , private activatedRoute: ActivatedRoute ) { }

  eventId : any ;
  data : any ;
  header : any[] = [
    {key : 'id' , value : 'id'} ,
    {key : 'name' , value : 'name'},
  ];

  ngOnInit(): void {

    this.activatedRoute.params.subscribe(param => {
      //console.log(param['id']);
      this.eventId = param['id'];
    })

    this.eventService.getEventDetail(this.eventId).subscribe( (response : any) => {
      console.log(response);
      this.data = response.result;
    });

  }

}
