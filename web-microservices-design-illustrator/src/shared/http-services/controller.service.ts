import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';

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


}
