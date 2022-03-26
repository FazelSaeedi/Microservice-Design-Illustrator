import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpBaseService } from '../base-services/http-base.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends HttpBaseService {

  constructor(
     http: HttpClient
  ) {
    super(http);
  }


  getAllProjects(){
      return this.http.get(`${this.apiUrl}/Project/GetAll`);
  }



  getProjectDetails(projectId : string)
  {
    return this.http.get(`${this.apiUrl}/Project/${projectId}`);
  }


}
