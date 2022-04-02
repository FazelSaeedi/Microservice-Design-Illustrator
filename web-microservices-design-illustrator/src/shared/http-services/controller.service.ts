import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';
import { CreateControllerDto } from '../models/groups/ProjectModels';

@Injectable({
  providedIn: 'root'
})
export class ControllerService  extends HttpBaseService {


  constructor(
     http: HttpClient
  ) {
    super(http);
  }


  getControllerDetail(controllerId : string)
  {
    return this.http.get(`${this.apiUrl}/Controller/${controllerId}`);
  }


  addController(dto : CreateControllerDto)
  {
    return this.http.post(`${this.apiUrl}/Controller` , dto);
  }

}
