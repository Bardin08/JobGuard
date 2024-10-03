import { Component } from '@angular/core';
import { VacancyFormComponent } from '../vacancy-form/vacancy-form.component';
import { VacancyCheckResultComponent } from '../vacancy-check-result/vacancy-check-result.component';

@Component({
  selector: 'app-vacancy-check-root',
  templateUrl: './vacancy-check-root.component.html',
  styleUrls: ['./vacancy-check-root.component.scss'],
  standalone: true,
  imports: [VacancyFormComponent, VacancyCheckResultComponent]
})
export class VacancyCheckRootComponent {
  checkResult: any;

  onCheckVacancy() {
    this.checkResult = {
      vacancyReal: true,
      companyReal: true,
      checkId: '5e1d53'
    };
  }
}
