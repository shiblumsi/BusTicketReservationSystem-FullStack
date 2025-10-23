import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BusService {
  private baseUrl = 'https://localhost:7113/api/search'
  constructor(private http: HttpClient) {}

  availableBuses(from: string, to: string, journeyDate: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}?from=${from}&to=${to}&journeyDate=${journeyDate}`);
  }
}
