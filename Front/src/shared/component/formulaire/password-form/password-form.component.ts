import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from '../../../services/apiService';
import { IApplication } from '../../../models/application.model';

@Component({
  selector: 'app-password-form',
  templateUrl: './password-form.component.html',
  styleUrls: ['./password-form.component.css'],
})
export class PasswordFormComponent implements OnInit {
  passwordForm: FormGroup | undefined;
  applications: IApplication[] = [];
  applicationTypes = ['Grand public', 'Professionnelle'];

  constructor(private fb: FormBuilder, private apiService: ApiService) {}

  ngOnInit(): void {
    this.initForm();
    this.loadApplications();
  }

  initForm() {
    this.passwordForm = this.fb.group({
      accountName: ['', [Validators.required, Validators.minLength(3)]],
      application: ['', Validators.required],
      appType: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(10)]],
    });
  }

  loadApplications() {
    this.apiService.get<IApplication>('applications').subscribe({
      next: (data) => {
        //this.applications = data;
      },
      error: (err) => {
        console.error('Erreur lors du chargement des applications', err);
      },
    });
  }

  onSubmit() {
    if (this.passwordForm) {
      const formValues = this.passwordForm.value;
      const newPassword = {
        accountName: formValues.accountName,
        idApplication: formValues.application,
        type: formValues.appType,
        libelle: formValues.password,
      };

      /*this.apiService.post('passwords', newPassword).subscribe({
        next: () => {
          this.passwordForm.reset();
        },
        error: (err) => {
          console.error("Erreur lors de l'ajout du mot de passe", err);
        },
      });
    } 
    else {*/
      console.log('Le formulaire est invalide');
    }
  }
}
