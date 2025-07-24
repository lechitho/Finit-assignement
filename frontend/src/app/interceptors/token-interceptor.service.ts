import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TokenInterceptorService implements HttpInterceptor {
  constructor() {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    request = request.clone({
      setHeaders: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type':  'application/json',
      },
    });

    return next.handle(request).pipe(
      catchError((err) => {
        if (err.status === 401) {
          console.log('unAuthorization')
        }
        const error = err.error.message || err.statusText;
        return throwError(error);
      })
    );
  }
}
