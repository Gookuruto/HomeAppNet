import { Injectable, Injector } from "@angular/core";
import { HttpInterceptor } from "@angular/common/http";
import { AuthService } from "./auth.service";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { Router } from "@angular/router";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from "@angular/common/http";

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private router: Router, private injector: Injector) {}

  intercept(req, next): Observable<HttpEvent<any>> {
    const authService = this.injector.get(AuthService);
    const authRequest = req.clone({
      // tslint:disable-next-line:max-line-length
      headers: req.headers.set("Authorization", "Bearer " + authService.token),
    });
    debugger;

    return next.handle(authRequest).pipe(
      tap(
        () => {},
        (err: any) => {
          if (err instanceof HttpErrorResponse) {
            if (err.status !== 401) {
              return;
            }
            this.router.navigate(["login"]);
          }
        }
      )
    );
  }
}
