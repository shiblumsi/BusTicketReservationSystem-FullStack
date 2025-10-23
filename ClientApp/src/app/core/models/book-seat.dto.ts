export interface IBookSeatInput {
  busScheduleId: string;
  seatNumber: number;
  passengerName: string;
  passengerMobile: string;
  boardingPoint: string;
  droppingPoint: string;
}

export interface IBookSeatResult {
  success: boolean;
  message: string;
}
