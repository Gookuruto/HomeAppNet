import {
  AuthentiateRequest,
  UsersClient,
} from "./../webApi/api.generated.clients";
import { Injectable } from "@angular/core";

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from "@angular/router";

@Injectable()
export class AuthService {
  API_URL = "http://localhost:5000";
  TOKEN_KEY = "token";

  constructor(
    private http: HttpClient,
    private router: Router,
    private userClient: UsersClient
  ) {}

  get token(): string {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  get isAuthenticated(): boolean {
    const response = !!localStorage.getItem(this.TOKEN_KEY);
    if (response) {
      return response;
    } else {
      this.router.navigate(["/login"]);
      return response;
    }
  }

  logout(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    this.router.navigateByUrl("/login");
  }

  async login(data: AuthentiateRequest): Promise<void> {
    const headers = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        "Cache-Control": "no-cache",
      }),
    };
    const token = await this.userClient.authenticate(data).toPromise();
    localStorage.setItem(this.TOKEN_KEY, token.token);

    this.router.navigateByUrl("/");
  }
  isLoggedIn(): boolean {
    if (this.token == null) {
      return false;
    } else {
      return true;
    }
  }

  getAccount(): any {
    return this.http.get(this.API_URL + "/account");
  }
}
