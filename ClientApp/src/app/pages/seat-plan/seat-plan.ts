import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IAvailableBus } from '../../core/models/available-bus.dto';
import { IBoardingDropping, ISeat } from '../../core/models/seat-plan.dto';
import { Booking } from '../../core/services/booking';
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
  aBus!: IAvailableBus;
  seats: ISeat[] = [];

  boadringPoients: IBoardingDropping[] = [];
  droppingPoients: IBoardingDropping[] = [];

  selectedBoardingPoint: string = '';
  selectedDroppingPoint: string = '';

  passengerName: string = '';
  passengerMobile: string = '';

  constructor(
    private route: ActivatedRoute,
    private seatPlan: SeatPlanService,
    private availableBus: BusService,
    private booking: Booking
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.scheduleId = params['scheduleId'] ?? null;
      this.from = params['from'] ?? '';
      this.to = params['to'] ?? '';
      this.journeyDate = params['journeyDate'] ?? '';
    });

    this.loadBusDetails();
    this.loadSeatPlan();
    this.loadBoardingPoient();
    this.loadDroppintPoient();
  }

  loadBoardingPoient() {
    this.seatPlan.getBoardingDroppingPoient(this.from, 'Boarding').subscribe({
      next: (res: any) => {
        this.boadringPoients = res;
        console.log(res);
      },
    });
  }

  loadDroppintPoient() {
    this.seatPlan.getBoardingDroppingPoient(this.to, 'Dropping').subscribe({
      next: (res: any) => {
        this.droppingPoients = res;
        console.log(res);
      },
    });
  }

  loadBusDetails() {
    this.availableBus.availableBuses(this.from, this.to, this.journeyDate).subscribe({
      next: (res: IAvailableBus[]) => {
        this.aBus = res.find((b) => b.scheduleId === this.scheduleId)!;
      },
    });
  }

  loadSeatPlan() {
    if (!this.scheduleId) return;

    this.seatPlan.getSetPlan(this.scheduleId).subscribe({
      next: (res: any) => {
        const rawSeats = Array.isArray(res) ? res : res.seats;

        if (!Array.isArray(rawSeats)) {
          console.error(' Invalid seat data format:', res);
          return;
        }

        const seatsPerRow = 4;
        this.seats = rawSeats.map((s: any, index: number) => {
          const rowIndex = Math.floor(index / seatsPerRow);
          const colIndex = index % seatsPerRow;

          const seatCode = `${String.fromCharCode(65 + rowIndex)}${colIndex + 1}`;
          const seatNumber = rowIndex * seatsPerRow + (colIndex + 1);

          return {
            seatCode, // frontend display
            seatNumber, // backend
            status: s.status === 1 ? 'Booked' : s.status === 2 ? 'Sold' : 'Available',
            selected: false,
            isBooked: s.status === 1,
            isSold: s.status === 2,
          } as ISeat;
        });
      },
      error: (err) => console.error(' Error loading seat plan:', err),
    });
  }

  toggleSeat(seat: ISeat) {
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

  //  Book seats using form input
  bookNow() {
    if (this.selectedSeats.length === 0) {
      alert(' Please select at least one seat!');
      return;
    }

    if (!this.passengerName || !this.passengerMobile) {
      alert(' Please enter passenger name and mobile!');
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

    console.log(' Sending Booking Data:', bookingData);

    this.booking.bookSeats(bookingData).subscribe({
      next: (res) => {
        if (res.success) {
          alert(res.message);
          this.selectedSeats.forEach((s) => {
            s.status = 'Booked';
            s.selected = false;
          });
        } else {
          alert(` ${res.message}`);
        }
      },
      error: (err) => {
        console.error(' Booking failed:', err);
        alert('Something went wrong during booking.');
      },
    });

    this.passengerName = '';
    this.passengerMobile = '';
  }
}
