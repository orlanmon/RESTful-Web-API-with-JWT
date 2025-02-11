import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component'; 
import { InvokeWebAPIComponent } from './components/invoke-web-api/invoke-web-api.component';
import { AuthorizeComponent } from './components/authorize/authorize.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'auth',
    component: AuthorizeComponent
  },
  {
    path: 'invokewebapi',
    component: InvokeWebAPIComponent
  }
];

