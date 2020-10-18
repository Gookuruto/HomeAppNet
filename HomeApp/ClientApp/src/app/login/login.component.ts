import { AuthService } from "./../services/auth.service";
import {
  AuthentiateRequest,
  UsersClient,
} from "./../webApi/api.generated.clients";
import { Component, OnInit } from "@angular/core";
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from "@angular/forms";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.form = this.fb.group({
      username: ["", Validators.required],
      password: ["", Validators.required],
    });
  }

  ngOnInit() {}

  async login() {
    const val = this.form.value;
    if (val.username && val.password) {
      const request = new AuthentiateRequest({
        username: val.username,
        password: val.password,
      });
      var result = await this.authService.login(request);
    }
  }
}
