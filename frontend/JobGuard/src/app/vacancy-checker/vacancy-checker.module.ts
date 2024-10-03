import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { VacancyFormComponent } from './vacancy-form/vacancy-form.component';
import { VacancyCheckResultComponent } from './vacancy-check-result/vacancy-check-result.component';
import { VacancyCheckRootComponent } from './vacancy-check-root/vacancy-check-root.component';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatChipsModule } from '@angular/material/chips';
import {provideHttpClient} from "@angular/common/http";

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    VacancyFormComponent,
    VacancyCheckResultComponent,
    VacancyCheckRootComponent,
    MatCardModule,
    MatDividerModule,
    MatChipsModule
  ],
  exports: [VacancyCheckRootComponent],
})
export class VacancyCheckerModule { }
