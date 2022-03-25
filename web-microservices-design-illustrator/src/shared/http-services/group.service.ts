import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';
import { HttpClient } from "@angular/common/http";
import { TServiceResult } from '../helper/t-service-result';

@Injectable({
  providedIn: 'root'
})
export class GroupService extends HttpBaseService {



  constructor(
     http: HttpClient
  ) {
    super(http);
  }


  getAllGroups()
  {
      return this.http.get(`${this.apiUrl}/Group/GetAll`);
  }


}
