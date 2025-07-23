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
    const token  = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFkbWluIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiYWRtaW4iLCJleHAiOjMzMjUxMDE1MzU3LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjEzNjU4LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTM2NTgvIn0.AQy6AltyOWKNSsDAUql_1wLWRqo9aEllLKHMlbGWL9k';

    request = request.clone({
      setHeaders: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type':  'application/json',
        Authorization: `Bearer ${token}`,
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
