import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IApiResponse } from '../models/api-response.dto';
import { IBoardingDropping, ISeatPlan } from '../models/seat-plan.dto';

@Injectable({
  providedIn: 'root',
})
export class SeatPlanService {
  private readonly apiUrl = 'https://localhost:7113/api/booking';

  constructor(private http: HttpClient) {}

  getSeatPlan(busScheduleId: string): Observable<IApiResponse<ISeatPlan>> {
    return this.http.get<IApiResponse<ISeatPlan>>(`${this.apiUrl}/${busScheduleId}/seats`);
  }

  getBoardingDroppingPoints(
    city: string,
    type: string
  ): Observable<IApiResponse<IBoardingDropping[]>> {
    const params = new HttpParams().set('city', city).set('type', type);
    return this.http.get<IApiResponse<IBoardingDropping[]>>(`${this.apiUrl}/boarding-dropping`, {
      params,
    });
  }
}
