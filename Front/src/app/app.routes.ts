import { Routes } from '@angular/router';
import { ApplicationsComponent } from '../shared/component/applications/applications.component';
export const routes: Routes = [
  {
    path: 'applications',
    component: ApplicationsComponent,
  },
  {
    path: '',
    redirectTo: '/applications',
    pathMatch: 'full',
  },
];
