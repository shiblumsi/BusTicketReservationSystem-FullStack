import { Routes } from '@angular/router';
import { AvailableBus } from './pages/available-bus/available-bus';
import { Homepage } from './pages/homepage/homepage';
import { SeatPlan } from './pages/seat-plan/seat-plan';
import { BookingConfirmation } from './pages/booking-confirmation/booking-confirmation';

export const routes: Routes = [
  { path: '', component: Homepage },
  { path: 'available-bus', component: AvailableBus },
  { path: 'seat-plan', component: SeatPlan },
  { path: 'booking-confirmation', component: BookingConfirmation },
];
