import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { ApplicationsComponent } from './shared/component/applications/applications.component';

bootstrapApplication(ApplicationsComponent, appConfig).catch((err) =>
  console.error(err)
);
