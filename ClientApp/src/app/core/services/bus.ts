import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IApiResponse } from '../models/api-response.dto';
import { IAvailableBus } from '../models/available-bus.dto';
@Injectable({
  providedIn: 'root'
})
export class BusService {
  private baseUrl = 'https://localhost:7113/api'

  constructor(private http: HttpClient) {}

  getAvailableBuses(from: string, to: string, journeyDate: string): Observable<IApiResponse<IAvailableBus[]>> {

    const params = new HttpParams()
      .set('from', from)
      .set('to', to)
      .set('journeyDate', journeyDate);

    return this.http.get<IApiResponse<IAvailableBus[]>>(`${this.baseUrl}/Search`, { params });
  }
}

