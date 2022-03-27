import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { environment } from '../../../src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export abstract class HttpBaseService extends BaseService{

  private _apiUrl : string = '' ;


  constructor(
      protected http: HttpClient,
    ) {
      super();
    }

    protected get apiUrl() : string {
      return this._apiUrl = `${environment.ServicesUrl}/api`;
    }
}
