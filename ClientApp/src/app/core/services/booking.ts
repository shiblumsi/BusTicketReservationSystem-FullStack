import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IApiResponse } from '../models/api-response.dto';
import { IBookSeatInput, IBookSeatResult } from '../models/book-seat.dto';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  private readonly apiUrl = 'https://localhost:7113/api/booking';

  constructor(private http: HttpClient) {}

  bookSeats(input: IBookSeatInput[]): Observable<IApiResponse<IBookSeatResult>> {
    return this.http.post<IApiResponse<IBookSeatResult>>(`${this.apiUrl}/book`, input);
  }

  confirmBooking(ticketIds: string[]): Observable<IApiResponse<any>> {
    return this.http.post<IApiResponse<any>>(`${this.apiUrl}/confirm`, ticketIds);
  }

  cancelBooking(ticketIds: string[]): Observable<IApiResponse<any>> {
    return this.http.post<IApiResponse<any>>(`${this.apiUrl}/cancel`, ticketIds);
  }
}
