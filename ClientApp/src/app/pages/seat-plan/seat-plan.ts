import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IApiResponse } from '../../core/models/api-response.dto';
import { IAvailableBus } from '../../core/models/available-bus.dto';
import { IBoardingDropping, ISeat, ISeatPlan } from '../../core/models/seat-plan.dto';
import { BookingService } from '../../core/services/booking';
import { BusService } from '../../core/services/bus';
import { SeatPlanService } from '../../core/services/seat-plan';

@Component({
  selector: 'app-seat-plan',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './seat-plan.html',
  styleUrls: ['./seat-plan.css'],
})
export class SeatPlan implements OnInit {
  scheduleId: string | null = null;
  from = '';
  to = '';
  journeyDate = '';

  availableBus!: IAvailableBus;
  seats: ISeat[] = [];

  boardingPoints: IBoardingDropping[] = [];
  droppingPoints: IBoardingDropping[] = [];

  selectedBoardingPoint = '';
  selectedDroppingPoint = '';

  passengerName = '';
  passengerMobile = '';

  loading = false;

  constructor(
    private route: ActivatedRoute,
    private seatPlanService: SeatPlanService,
    private busService: BusService,
    private bookingService: BookingService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.scheduleId = params['scheduleId'] ?? null;
      this.from = params['from'] ?? '';
      this.to = params['to'] ?? '';
      this.journeyDate = params['journeyDate'] ?? '';

      this.loadBusDetails();
      this.loadSeatPlan();
      this.loadBoardingPoints();
      this.loadDroppingPoints();
    });
  }

  loadBoardingPoints(): void {
    this.seatPlanService.getBoardingDroppingPoints(this.from, 'Boarding').subscribe({
      next: (res: IApiResponse<IBoardingDropping[]>) => {
        if (res.success) {
          this.boardingPoints = res.data ?? [];
        }
      },
      error: (err) => console.error('Error loading boarding points:', err),
    });
  }

  loadDroppingPoints(): void {
    this.seatPlanService.getBoardingDroppingPoints(this.to, 'Dropping').subscribe({
      next: (res: IApiResponse<IBoardingDropping[]>) => {
        if (res.success) {
          this.droppingPoints = res.data ?? [];
        }
      },
      error: (err) => console.error('Error loading dropping points:', err),
    });
  }

  loadBusDetails(): void {
    this.busService.getAvailableBuses(this.from, this.to, this.journeyDate).subscribe({
      next: (res: IApiResponse<IAvailableBus[]>) => {
        if (res.success) {
          this.availableBus = res.data?.find((b) => b.scheduleId === this.scheduleId)!;
        }
      },
      error: (err) => console.error('Error loading bus details:', err),
    });
  }

  loadSeatPlan(): void {
    if (!this.scheduleId) return;

    this.loading = true;
    this.seatPlanService.getSeatPlan(this.scheduleId).subscribe({
      next: (res: IApiResponse<ISeatPlan>) => {
        this.loading = false;
        if (!res.success || !res.data) {
          this.toastr.warning(res.message || 'No seat data found');
          return;
        }

        const rawSeats = res.data.seats;
        const seatsPerRow = 4;

        this.seats = rawSeats.map((s: any, index: number) => {
          const rowIndex = Math.floor(index / seatsPerRow);
          const colIndex = index % seatsPerRow;

          const seatCode = `${String.fromCharCode(65 + rowIndex)}${colIndex + 1}`;
          const seatNumber = rowIndex * seatsPerRow + (colIndex + 1);

          const statusText =
            s.status === 1
              ? 'Booked'
              : s.status === 2
              ? 'Sold'
              : s.status === 3
              ? 'Cancelled'
              : 'Available';

          return {
            seatCode,
            seatNumber,
            status: statusText,
            selected: false,
            isBooked: s.status === 1,
            isSold: s.status === 2,
          } as ISeat;
        });
      },
      error: (err) => {
        this.loading = false;
        console.error('Error loading seat plan:', err);
        this.toastr.error('Failed to load seat plan');
      },
    });
  }

  toggleSeat(seat: ISeat): void {
    if (seat.status === 'Booked' || seat.status === 'Sold') return;
    seat.selected = !seat.selected;
  }

  get selectedSeats(): ISeat[] {
    return this.seats.filter((s) => s.selected);
  }

  get selectedSeatCode(): string {
    return this.selectedSeats.map((s) => s.seatCode).join(', ');
  }

  get seatRows(): ISeat[][] {
    const rows: ISeat[][] = [];
    const seatsPerRow = 4;
    for (let i = 0; i < this.seats.length; i += seatsPerRow) {
      rows.push(this.seats.slice(i, i + seatsPerRow));
    }
    return rows;
  }

  bookNow(): void {
    if (this.selectedSeats.length === 0) {
      this.toastr.warning('Please select at least one seat!', 'Warning');
      return;
    }

    if (!this.passengerName || !this.passengerMobile) {
      this.toastr.warning('Please enter passenger name and mobile!', 'Warning');
      return;
    }

    const bookingData = this.selectedSeats.map((seat) => ({
      busScheduleId: this.scheduleId!,
      seatNumber: seat.seatNumber,
      passengerName: this.passengerName,
      passengerMobile: this.passengerMobile,
      droppingPoint: this.selectedDroppingPoint,
      boardingPoint: this.selectedBoardingPoint,
    }));

    this.bookingService.bookSeats(bookingData).subscribe({
      next: (res: IApiResponse<any>) => {
        if (res.success) {
          this.toastr.success(res.message || 'Seat booked successfully!', 'Success');

          const bookingInfo = {
            passengerName: this.passengerName,
            passengerMobile: this.passengerMobile,
            from: this.from,
            to: this.to,
            journeyDate: this.journeyDate,
            selectedSeatCode: this.selectedSeatCode,
            selectedBus: this.availableBus,
            ticketIds: res.data?.ticketIds ?? [],
          };

          this.router.navigate(['/booking-confirmation'], {
            queryParams: { ticketIds: bookingInfo.ticketIds.join(',') },
            state: { bookingInfo },
          });
        } else {
          this.toastr.warning(res.message || 'Booking failed');
        }
      },
      error: (err) => {
        console.error('Booking error:', err);
        this.toastr.error('Booking request failed. Try again.');
      },
    });
  }
}
