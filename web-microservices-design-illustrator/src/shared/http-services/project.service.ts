import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpBaseService } from '../base-services/http-base.service';
import { TServiceResult } from '../helper/t-service-result';
import { CreateProjectDto } from '../models/groups/ProjectModels';

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

  addProject(dto : CreateProjectDto) : Observable<TServiceResult<string>>
  {
    return this.http.post<TServiceResult<string>>(`${this.apiUrl}/Project` , dto );
  }


   deleteProject(id : string)
   {
     return this.http.delete<TServiceResult<string>>(`${this.apiUrl}/Project/${id}`);
   }

}
