import { Injectable } from '@angular/core';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Payment } from '../models/Payment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AdService {

  url = "https://localhost:44324/api/";  // URL to web api
  private handleError: HandleError;
  subject: any;

  constructor(private http: HttpClient, httpErrorHandler: HttpErrorHandler) { 
    this.handleError = httpErrorHandler.createHandleError('AdService');
  }

  // getAd(): Observable<String[]> {
  //  // debugger;
  //   return this.http.get<String[]>(this.url+"ad")
  //   .pipe(catchError(this.handleError('getAd', []))
  //   );
  // }

  captureScreen(payment: Payment): Observable<Payment> {
    debugger;
    return this.http.post<Payment>(this.url+"payment", payment, httpOptions)
    .pipe(catchError(this.handleError('captureScreen', payment)));
  }

}
