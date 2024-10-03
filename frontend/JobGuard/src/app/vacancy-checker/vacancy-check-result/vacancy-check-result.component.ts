import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vacancy-check-result',
  templateUrl: './vacancy-check-result.component.html',
  styleUrls: ['./vacancy-check-result.component.scss'],
  standalone: true,
  imports: [CommonModule]
})
export class VacancyCheckResultComponent {
  @Input() result: any;

  constructor(private router: Router) {}

  navigateToDetailedReport() {
    console.log('Navigating to detailed report');
    if (this.result && this.result.checkId) {
      this.router.navigate(['/detailed-report'], {
        queryParams: { checkId: this.result.checkId }
      }).then(
        (success) => console.log('Navigation result:', success),
        (error) => console.error('Navigation error:', error)
      );
    } else {
      console.error('Detailed report URL is not available', this.result);
    }
  }
}
