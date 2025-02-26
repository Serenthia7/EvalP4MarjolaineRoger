import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../../services/applicationService';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.component.html',
  styleUrls: ['./applications.component.css'],
})
export class ApplicationsComponent implements OnInit {
  applications: any[] = [];
  errorMessage: string = '';

  constructor(private applicationService: ApplicationService) {}

  ngOnInit(): void {
    this.loadApplications();
  }

  loadApplications(): void {
    this.applicationService.getApplications().subscribe(
      (data) => {
        this.applications = data;
      },
      (error) => {
        this.errorMessage = 'Erreur lors du chargement des applications!';
      }
    );
  }
}
