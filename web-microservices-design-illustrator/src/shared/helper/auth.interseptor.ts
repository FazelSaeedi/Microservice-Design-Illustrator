import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpInterceptor, HttpErrorResponse, } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, concatMap, finalize, map, share, take, } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from '@environments/environment';
import { FakeService } from '@shared/services/other-services/fake-backend.service';
import { Alert } from './alert-handler';
import { IdentityService } from '@shared/services/http-services/identity.service';


// ? error mesages dictionary:
enum errorDic {
  "DuplicateOrder" = 'در این روز قبلا سفارشی ثبت شده است',
  "invalid credit cart!" = 'کارتی با این مشخصات یافت نشد',
  "shaba number invalid!" = 'شماره شبا وارد شده صحیح نمی باشد',
  "Not Found" = 'اطلاعاتی یافت نشد',
  "InvalidData" = 'اطلاعات وارد شده صحیح نمی باشد',
  "One or more validation errors occurred." = 'اطلاعات کارت بانکی صحیح نمی باشد',
  "InvalidPhoneNumber" = 'شماره همراه نامعتبر است',
  "invalid_grant" = 'کد وارد شده اشتباه است',
  "Invalid_BirthDate" = 'تاریخ تولد اشتباه است',
  "Value cannot be null. (Parameter 'user')" = 'شماره همراه نامعتبر است',
  "OrderNotFound" = 'سفارش مورد نظر یافت نشد',
  "duplicateCredit" = 'این کارت بانکی قبلا ثبت شده است',
  "CustomerNotFound" = 'کاربر مورد نظر یافت نشد'
}

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private _tokenRefreshObservable: Observable<string> | null;
  constructor(
    private router: Router,
    private identity: IdentityService,
    private backEndFake: FakeService,
  ) { }

  alert: Alert = new Alert();
  msg: string = 'خطای سیستمی';

  intercept(request: HttpRequest<any>, next: HttpHandler): any {
    // ? ignore handling in getting env
    if (request.url == './assets/environments/environment.json')
      return next.handle(request);

    return this.handleAuth(request).pipe(concatMap(req => next.handle(req)), catchError(e => {
      return this.handleAuthError(e)
    }));
  }


  handleAuth(request: HttpRequest<any>): Observable<HttpRequest<any>> {

    return this.getToken()
      .pipe(
        take(1), // This is required to complete the returned observable
        map(tk => this.addTokenToRequest(request, tk)),
      );
  }

  addTokenToRequest(request: HttpRequest<any>, token: string): any {
    if (!token && token != null) {
      return request;
    }

    let headerKeyValue: { [name: string]: string | string[]; } = {};
    headerKeyValue["Authorization"] = `Bearer ${token}`;
    return request.clone({
      setHeaders: headerKeyValue
    });
  }

  getToken(): Observable<string> {
    if (this._tokenRefreshObservable) {
      return this._tokenRefreshObservable;
    }

    let token = localStorage.getItem("access_token");
    if (token) {
      return of(token || "");
    }

    const refresh = localStorage.getItem("refresh_token");
    if (refresh == null || !refresh)
      return of("");
    // Token is expired. Try refreshing
    // this._tokenRefreshObservable = this.refreshTokenService.Refresh()
    this._tokenRefreshObservable = this.identity.refreshToken()
      .pipe(
        map(() => {
          return localStorage.getItem('access_token') || "";
        }),
        catchError((e) => {
          return of(token || "");
        }),
        finalize(() => {
          this._tokenRefreshObservable = null;
        }),
        share(),
      );
    return this._tokenRefreshObservable;
  }

  private handleAuthError(err: HttpErrorResponse): Observable<any> {
    console.log('hi');
    
    const englishErrorMessage = err?.error?.error?.message;
    errorDic[englishErrorMessage] ? this.msg = errorDic[englishErrorMessage] : null;

    // TODO: implement with error standard
    if (err?.error?.error == 'invalid_grant') {
      this.msg = 'کد فعال‌سازی نامعتبر است'
    }
    
    
    if (err.status === 400) {
      console.log(this.msg);
      
      this.alert.fireError('top', this.msg);
      
      // ? Temporary, cuase data retrevaling
      if (englishErrorMessage == 'CustomerNotFound') {
        localStorage.removeItem('refresh_token');
        localStorage.removeItem('access_token');
        this.router.navigate([`/login`]);
      }
      return throwError(err);
    }

    if (err.status == 401) {

      if (localStorage.getItem('access_token')) {
        console.log("Token Expired");
        this.identity.refreshToken().subscribe();
      }
      else {
        localStorage.removeItem('access_token');
        this.router.navigate([`/login`]);
        return throwError(err);
      }
      // }
    }

    if (err.status === 403) {
      this.alert.fireError('top', 'شما اجازه دسترسی به این بخش را ندارید.')
      return throwError(err);
    }

    return throwError(err);


  }


}

