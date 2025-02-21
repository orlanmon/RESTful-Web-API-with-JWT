import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthorizeService } from '../../services/authorize.service';
import { RegisteredUser } from '../../shared/models/RegisteredUser';
import { FormsModule } from '@angular/forms';
import { JWT } from '../../shared/models/JWT';

@Component({
  selector: 'app-authorize',
  imports: [ReactiveFormsModule, FormsModule],
  templateUrl: './authorize.component.html',
  styleUrl: './authorize.component.scss'
})
export class AuthorizeComponent implements OnInit {

  myFormRegister: FormGroup;
  myFormLogin: FormGroup;
  registeredUser: RegisteredUser;
  jSONWebToken: string;
  registerStatus: string;

  private authorizeService: AuthorizeService


  constructor(private authService: AuthorizeService) {

    this.authorizeService = authService;

  }

  ngOnInit() {

    this.myFormRegister = new FormGroup({
      username: new FormControl(),
      password: new FormControl()
    });

    this.myFormLogin = new FormGroup({
      username_login: new FormControl(),
      password_login: new FormControl()
    });

  }

  onSubmitRegister(form: FormGroup) {

    //console.log('Valid?', form.valid); // true or false
    //console.log('UserName', form.value.username);
    //console.log('Password', form.value.password);

    this.authorizeService.register(form.value.username, form.value.password)
    .subscribe((registeredUser) => { 
      this.registeredUser = registeredUser; 
      console.log(this.registeredUser); 
      this.registerStatus = "Success"; 
    });

  }

  onSubmitLogin(form: FormGroup) {

    this.authorizeService.login(form.value.username_login, form.value.password_login)
      .subscribe((jwt) => {
        sessionStorage.setItem('JasonWebToken', jwt.jSONWebToken);
        this.jSONWebToken = jwt.jSONWebToken;
        console.log(jwt.jSONWebToken);
      });

  }

}


