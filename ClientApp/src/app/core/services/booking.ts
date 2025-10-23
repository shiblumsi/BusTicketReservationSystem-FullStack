import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBookSeatInput, IBookSeatResult } from '../models/book-seat.dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Booking {
  private apiUrl = 'https://localhost:7113/api/booking';
  constructor(private http: HttpClient) {}

  bookSeats(input: IBookSeatInput[]): Observable<IBookSeatResult> {
    return this.http.post<IBookSeatResult>(`${this.apiUrl}/book`, input);
  }
}
