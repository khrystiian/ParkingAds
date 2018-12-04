import { Injectable } from '@angular/core';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

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
  url = "https://localhost:44324/api/ad";  // URL to web api
  private handleError: HandleError;

  constructor(private http: HttpClient, httpErrorHandler: HttpErrorHandler) { 
    this.handleError = httpErrorHandler.createHandleError('AdService');
  }

  getAd(): Observable<String[]> {
    debugger;
    return this.http.get<String[]>(this.url)
    .pipe(catchError(this.handleError('getAd', []))
    );
  }
}
