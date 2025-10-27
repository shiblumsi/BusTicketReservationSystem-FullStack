import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IApiResponse } from '../../core/models/api-response.dto';
import { BookingService } from '../../core/services/booking';

@Component({
  selector: 'app-booking-confirmation',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './booking-confirmation.html',
  styleUrls: ['./booking-confirmation.css'],
})
export class BookingConfirmation implements OnInit {
  bookingData: any = null;
  loading = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private bookingService: BookingService,
    private toastr: ToastrService,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      const ticketIds = params['ticketIds']?.split(',') || [];

      if (ticketIds.length === 0) {
        this.toastr.warning('No tickets found. Redirecting to home...');
        this.router.navigate(['/']);
        return;
      }

      this.bookingData = {
        ...history.state.bookingInfo,
        ticketIds,
      };

      console.log('Booking Confirmation Data:', this.bookingData);
    });
  }

  confirmBooking(): void {
    if (!this.bookingData?.ticketIds?.length) {
      this.toastr.warning('No tickets to confirm.');
      return;
    }

    this.loading = true;
    this.http
      .post<{ redirectUrl?: string }>(
        'https://localhost:7113/api/Payment/initiate',
        this.bookingData.ticketIds
      )
      .subscribe({
        next: (res) => {
          this.loading = false;
          console.log('Payment Initiate Response:', res);

          if (res?.redirectUrl) {
            window.location.href = res.redirectUrl;
          } else {
            this.toastr.error('Redirect URL not found in response!');
          }
        },
        error: (err) => {
          this.loading = false;
          console.error('Payment initiation failed:', err);
          this.toastr.error('Failed to initiate payment.');
        },
      });
  }

  cancelBooking(): void {
    if (!this.bookingData?.ticketIds?.length) {
      this.toastr.warning('No tickets to cancel.');
      return;
    }

    this.loading = true;
    this.bookingService.cancelBooking(this.bookingData.ticketIds).subscribe({
      next: (res: IApiResponse<any>) => {
        this.loading = false;
        if (res.success) {
          this.toastr.success(res.message || 'Bookings cancelled successfully!');
          this.router.navigate(['/']);
        } else {
          this.toastr.warning(res.message || 'Failed to cancel bookings.');
        }
      },
      error: (err) => {
        this.loading = false;
        console.error('Error cancelling booking:', err);
        this.toastr.error('Server error occurred while cancelling.');
      },
    });
  }
}
