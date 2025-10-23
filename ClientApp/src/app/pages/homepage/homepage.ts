import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './homepage.html',
  styleUrls: ['./homepage.css']
})
export class Homepage {
  from = '';
  to = '';
  journeyDate = '';

  constructor(private router: Router) {}

  searchBuses() {
    if (!this.from || !this.to || !this.journeyDate) {
      alert('Please fill all fields');
      return;
    }

    this.router.navigate(['/available-bus'], {
      queryParams: { from: this.from, to: this.to, journeyDate: this.journeyDate }
    });
  }
}
