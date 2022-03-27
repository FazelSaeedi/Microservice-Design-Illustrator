import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';

@Injectable({
  providedIn: 'root'
})
export class PageService extends HttpBaseService {
  [x: string]: any;


  constructor(
     http: HttpClient
  ) {
    super(http);
  }

  getPageDetail(controllerId : string)
  {
    return this.http.get(`${this.apiUrl}/page/${controllerId}`);
  }

}
