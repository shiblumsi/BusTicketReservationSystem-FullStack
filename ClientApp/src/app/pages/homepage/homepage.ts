import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './homepage.html',
  styleUrls: ['./homepage.css'],
})
export class Homepage {
  departureCity = '';
  arrivalCity = '';
  journeyDate = '';

  constructor(private router: Router, private toastr: ToastrService) {}

  searchBuses() {
    if (!this.departureCity || !this.arrivalCity || !this.journeyDate) {
      this.toastr.error('Please fill all fields', 'Error');
      return;
    }
    const today = new Date();
    const selectedDate = new Date(this.journeyDate);
    today.setHours(0, 0, 0, 0);
    selectedDate.setHours(0, 0, 0, 0);

    if (selectedDate < today) {
      this.toastr.warning('Journey date cannot be in the past', 'Warning');
      return;
    }

    this.router.navigate(['/available-bus'], {
      queryParams: {
        departureCity: this.departureCity,
        arrivalCity: this.arrivalCity,
        journeyDate: this.journeyDate,
      },
    });
  }
}
