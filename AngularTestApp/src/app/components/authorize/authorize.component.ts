import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthorizeService } from '../../services/authorize.service';

@Component({
  selector: 'app-authorize',
  imports: [ReactiveFormsModule],
  templateUrl: './authorize.component.html',
  styleUrl: './authorize.component.scss'
})
export class AuthorizeComponent implements OnInit {

  myFormRegister: FormGroup;
  myFormLogin: FormGroup;
  myFormJWT: FormGroup;
  retreivedData: any;

  private authorizeService : AuthorizeService 
  

  constructor(private authService: AuthorizeService ) {

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

    this.myFormJWT = new FormGroup({
      jason_web_token: new FormControl(),
    });

    
  }

  onSubmitRegister(form: FormGroup) {
    
    //console.log('Valid?', form.valid); // true or false
    //console.log('UserName', form.value.username);
    //console.log('Password', form.value.password);

    this.authorizeService.register(form.value.username, form.value.password ).subscribe( (retrieveddata) => { console.log(this.retreivedData);  } );

  }

  onSubmitLogin(form: FormGroup) {

    this.authorizeService.register(form.value.username_login, form.value.password_login ).subscribe( (retrieveddata) => { sessionStorage.setItem('JasonWebToken', JSON.stringify(retrieveddata)); } );

  }





}


