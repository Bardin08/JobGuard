// vacancy-report.service.ts
import {inject, Injectable} from '@angular/core';
import {HttpClient, provideHttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {VacancyReport} from './vacancy-detailed-report.model';

@Injectable({
  providedIn: 'root'
})
export class VacancyReportService {

  private apiUrl = 'http://localhost:5000/vacancies/report'; // Replace with your API endpoint

  constructor(private http: HttpClient) {
  }

  getVacancyReport(checkId: string): Observable<VacancyReport> {
    const url = `${this.apiUrl}?checkId=${checkId}`;
    return this.http.get<VacancyReport>(url);
  }
}
