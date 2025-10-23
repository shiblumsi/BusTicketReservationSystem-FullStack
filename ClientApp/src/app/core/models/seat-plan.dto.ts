export interface ISeat {
  seatCode: string; // frontend
  seatNumber: number; // backend
  status: 'Available' | 'Booked' | 'Sold';
  selected?: boolean;
  isBooked?: boolean;
  isSold?: boolean;
}

export interface ISeatPlan {
  busScheduleId: string;
  seats: ISeat[];
}

export interface IBoardingDropping {
  pointName: string;
}
