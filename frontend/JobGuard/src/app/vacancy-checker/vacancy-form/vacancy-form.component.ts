import { Component, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-vacancy-form',
  templateUrl: './vacancy-form.component.html',
  styleUrls: ['./vacancy-form.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class VacancyFormComponent {
  @Output() checkVacancy = new EventEmitter<any>();
  vacancyInput: any;

  onSubmit() {
    if (this.vacancyInput.trim()) {
      this.checkVacancy.emit(this.vacancyInput);
    }
  }
}
