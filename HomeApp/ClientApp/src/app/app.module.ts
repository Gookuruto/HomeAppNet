import { UsersClient } from "./webApi/api.generated.clients";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { HeaderComponent } from "./header/header.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MaterialModule } from "./material-module";
import { LoginComponent } from "./login/login.component";
import { AuthService } from "./services/auth.service";
import { AuthInterceptorService } from "./services/authinjector.service";
import { CanActivateViaAuthGuard } from "./services/authguard";
import { API_BASE_URL } from "./webApi/api.generated.clients";

@NgModule({
  declarations: [AppComponent, HomeComponent, HeaderComponent, LoginComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule.forRoot([
      { path: "login", component: LoginComponent },
      { path: "", component: HomeComponent },
      { path: "**", redirectTo: "" },
    ]),
    BrowserAnimationsModule,
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useFactory: () => {
        return "http://localhost:62164";
      },
    },
    UsersClient,
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
    CanActivateViaAuthGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
