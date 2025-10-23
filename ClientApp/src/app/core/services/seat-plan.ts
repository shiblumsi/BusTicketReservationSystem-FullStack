import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBoardingDropping, ISeatPlan } from '../models/seat-plan.dto';

@Injectable({
  providedIn: 'root',
})
export class SeatPlanService {
  private apiUrl = 'https://localhost:7113/api/booking';
  constructor(private http: HttpClient) {}

  getSetPlan(busScheduleId: string): Observable<ISeatPlan> {
    return this.http.get<ISeatPlan>(`${this.apiUrl}/${busScheduleId}/seats`);
  }

  getBoardingDroppingPoient(city:string,type:string):Observable<IBoardingDropping[]>{
    return this.http.get<IBoardingDropping[]>(`${this.apiUrl}/boarding-dropping?city=${city}&type=${type}`);
  }
}
