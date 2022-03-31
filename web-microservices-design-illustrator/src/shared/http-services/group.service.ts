import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';
import { HttpClient } from "@angular/common/http";
import { TServiceResult } from '../helper/t-service-result';
import { createGroupDto } from '../models/groups/GroupModels';
import { Observable } from 'rxjs/internal/Observable';

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


  addGroup(dto : createGroupDto) : Observable<TServiceResult<string>>
  {
    return this.http.post<TServiceResult<string>>(`${this.apiUrl}/Group` , dto );
  }


  deleteGroup(id : string)
  {
    return this.http.delete<TServiceResult<string>>(`${this.apiUrl}/Group/${id}`);
  }

}
