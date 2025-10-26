export interface IAvailableBus {
  scheduleId: string;
  busId: string;
  companyName: string;
  busName: string;
  journeyDate: string;
  startTime: string;
  arrivalTime: string;
  seatsLeft: number;
  price: number;
  totalSeat: number;
  type: string;
}
