import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService extends HttpBaseService {

  constructor(
     http: HttpClient
  ) {
    super(http);
  }



  getServiceDetail(serviceId : string)
  {
    return this.http.get(`${this.apiUrl}/service/${serviceId}`);
  }


}
