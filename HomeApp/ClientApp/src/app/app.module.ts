import { UsersClient, RecipesClient } from "./webApi/api.generated.clients";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { RecipeListComponent } from "./recipes/recipeList/recipeList.component";
import { HeaderComponent } from "./header/header.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MaterialModule } from "./material-module";
import { LoginComponent } from "./login/login.component";
import { AuthService } from "./services/auth.service";
import { AuthInterceptorService } from "./services/authinjector.service";
import { CanActivateViaAuthGuard } from "./services/authguard";
import { API_BASE_URL } from "./webApi/api.generated.clients";
import { RecipeDetailsComponent } from "./recipes/recipe-details/recipe-details.component";
import { HomeComponent } from "./home/home.component";
import { BillListComponent } from "./bills/bill-list/bill-list.component";
import { BillDetailsComponent } from "./bills/bill-details/bill-details.component";
import { IncomeListComponent } from "./bills/income-list/income-list.component";
import { IncomeBillsMainComponent } from "./bills/income-bills-main/income-bills-main.component";

@NgModule({
  declarations: [
    AppComponent,
    RecipeListComponent,
    HeaderComponent,
    LoginComponent,
    RecipeDetailsComponent,
    HomeComponent,
    BillListComponent,
    BillDetailsComponent,
    IncomeListComponent,
    IncomeBillsMainComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule.forRoot([
      { path: "login", component: LoginComponent },
      { path: "recipe", component: RecipeListComponent },
      { path: "recipedet", component: RecipeDetailsComponent },
      { path: "bills", component: IncomeBillsMainComponent },
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
    RecipesClient,
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
