import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailedReportComponent } from './vacancy-checker/vacancy-detailed-report/vacancy-detailed-report.component';
import { VacancyCheckRootComponent } from './vacancy-checker/vacancy-check-root/vacancy-check-root.component';

export const routes: Routes = [
  { path: '', component: VacancyCheckRootComponent },
  { path: 'detailed-report', component: DetailedReportComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }