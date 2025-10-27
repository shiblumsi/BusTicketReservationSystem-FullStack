export interface ISeat {
  seatCode: string;
  seatNumber: number;
  status: 'Available' | 'Booked' | 'Sold';
  selected: boolean;
  isBooked: boolean;
  isSold: boolean;
  isAvailable: boolean;
}

export interface ISeatPlan {
  busScheduleId: string;
  seats: ISeat[];
}

export interface IBoardingDropping {
  pointName: string;
}
