import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BusCard } from '../../components/bus-card/bus-card';
import { BusService } from '../../core/services/bus';
import { IAvailableBus } from '../../core/models/available-bus.dto';

@Component({
  selector: 'app-available-bus',
  standalone: true,
  imports: [CommonModule, BusCard],
  templateUrl: './available-bus.html',
  styleUrls: ['./available-bus.css'],
})
export class AvailableBus implements OnInit {
  from = '';
  to = '';
  journeyDate = '';
  buses: IAvailableBus[] = [];

  constructor(private route: ActivatedRoute, private router: Router, private aBus: BusService) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.from = params['from'] ?? '';
      this.to = params['to'] ?? '';
      this.journeyDate = params['journeyDate'] ?? '';
      this.loadBuses();
    });
  }

  loadBuses() {

    this.aBus.availableBuses(this.from, this.to, this.journeyDate).subscribe({
      next: (res: any) => {
        console.log('API Response:', res);
        this.buses = res;
      },
      error: (err) => {
        console.error('Error loading buses:', err);
      },
    });
  }

  selectBus(scheduleId: string) {
    this.router.navigate(['/seat-plan'], {
      queryParams: { scheduleId:scheduleId, from: this.from, to: this.to, journeyDate: this.journeyDate },
    });
  }
}
