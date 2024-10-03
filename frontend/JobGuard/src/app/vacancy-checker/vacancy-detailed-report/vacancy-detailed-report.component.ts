import {Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ActivatedRoute} from '@angular/router';
import {VacancyReportService} from './vacancy-detailed-report.service';
import {RedFlag, SeverityLevel, VacancyReport} from "./vacancy-detailed-report.model";
import {MatCardModule} from '@angular/material/card';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatIconModule} from '@angular/material/icon';
import {MatChipsModule} from '@angular/material/chips';
import {MatListModule} from '@angular/material/list';
import {MatLine} from "@angular/material/core";
import {MatProgressSpinner} from "@angular/material/progress-spinner";

@Component({
  selector: 'app-detailed-report',
  standalone: true,
  imports: [CommonModule,
    MatCardModule,
    MatProgressBarModule,
    MatExpansionModule,
    MatIconModule,
    MatChipsModule,
    MatListModule, MatLine, MatProgressSpinner],
  templateUrl: './vacancy-detailed-report.component.html',
  styleUrls: ['./vacancy-detailed-report.component.scss']
})
export class DetailedReportComponent implements OnInit {
  report: VacancyReport | null = null;
  isLoading = true;
  errorMessage: string | null = null;
  readonly SeverityLevel = SeverityLevel;

  constructor(
    private route: ActivatedRoute,
    private reportService: VacancyReportService
  ) {
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const checkId = params['checkId'];
      if (checkId) {
        this.fetchVacancyReport(checkId);
      } else {
        this.errorMessage = 'No check ID provided';
        this.isLoading = false;
      }
    });
  }

  private fetchVacancyReport(checkId: string) {
    this.reportService.getVacancyReport(checkId).subscribe({
      next: (data: VacancyReport) => {
        this.report = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Failed to load the vacancy report. Please try again later.';
        this.isLoading = false;
        console.error(error);
      }
    });
  }

  get isHighRisk(): boolean {
    return this.report?.fraudRiskScore ? this.report.fraudRiskScore > 70 : false;
  }

  get severityColorClass(): string {
    if (!this.report?.fraudRiskScore) return 'error';
    if (this.report.fraudRiskScore >= 70) return 'error';
    if (this.report.fraudRiskScore >= 40) return 'warning';
    return 'success';
  }

  get companyVerificationStatus(): string {
    return this.report?.companyVerified ? 'Verified Company' : 'Unverified Company';
  }

  get companyVerificationClass(): string {
    return this.report?.companyVerified ? 'success' : 'warning';
  }

  get redFlags(): RedFlag[] {
    return this.report?.redFlags ?? [];
  }

  get highRiskRedFlags(): RedFlag[] {
    return this.report?.redFlags.filter(flag =>
      flag.severity === SeverityLevel.High
    ) ?? [];
  }

  getIconForSeverity(severity: SeverityLevel): string {
    switch (severity) {
      case SeverityLevel.Critical:
        return 'error';
      case SeverityLevel.High:
        return 'warning';
      case SeverityLevel.Medium:
        return 'info';
      default:
        return 'help';
    }
  }

  getSeverityClass(severity: SeverityLevel): string {
    switch (severity) {
      case SeverityLevel.Critical:
        return 'critical';
      case SeverityLevel.High:
        return 'high';
      case SeverityLevel.Medium:
        return 'medium';
      default:
        return 'low';
    }
  }

  getRedFlagsBySeverity(severity: SeverityLevel): RedFlag[] {
    return this.report?.redFlags.filter(flag => flag.severity === severity) ?? [];
  }
}
