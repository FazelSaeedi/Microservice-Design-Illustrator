import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';
import { CreateEventrDto } from '../models/groups/ProjectModels';

@Injectable({
  providedIn: 'root'
})
export class EventService extends HttpBaseService {


  constructor(
     http: HttpClient
  ) {
    super(http);
  }


  getEventDetail(controllerId : string)
  {
    return this.http.get(`${this.apiUrl}/event/${controllerId}`);
  }

  addEvent(dto : CreateEventrDto)
  {
     return this.http.post(`${this.apiUrl}/Event` , dto);
  }

}
