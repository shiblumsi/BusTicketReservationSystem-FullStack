import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BusCard } from '../../components/bus-card/bus-card';
import { IApiResponse } from '../../core/models/api-response.dto';
import { IAvailableBus } from '../../core/models/available-bus.dto';
import { BusService } from '../../core/services/bus';

@Component({
  selector: 'app-available-bus',
  standalone: true,
  imports: [CommonModule, BusCard],
  templateUrl: './available-bus.html',
  styleUrls: ['./available-bus.css'],
})
export class AvailableBus implements OnInit {
  departureCity = '';
  arrivalCity = '';
  journeyDate = '';
  availableBuses: IAvailableBus[] = [];
  loading = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private busService: BusService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.departureCity = params['departureCity'] ?? '';
      this.arrivalCity = params['arrivalCity'] ?? '';
      this.journeyDate = params['journeyDate'] ?? '';
      this.loadBuses();
    });
  }

  loadBuses() {
    this.loading = true;
    this.busService
      .getAvailableBuses(this.departureCity, this.arrivalCity, this.journeyDate)
      .subscribe({
        next: (res: IApiResponse<IAvailableBus[]>) => {
          this.loading = false;

          if (res.success) {
            this.availableBuses = res.data ?? [];
            this.toastr.success(res.message || 'Buses loaded successfully');
          } else {
            this.availableBuses = [];
            this.toastr.warning(res.message || 'No buses available');
          }
        },
        error: (err) => {
          this.loading = false;
          console.error('Error loading buses:', err);
          this.toastr.error('Server error occurred');
        },
      });
  }

  selectBus(scheduleId: string) {
    this.router.navigate(['/seat-plan'], {
      queryParams: {
        scheduleId,
        departureCity: this.departureCity,
        arrivalCity: this.arrivalCity,
        journeyDate: this.journeyDate,
      },
    });
  }
}
