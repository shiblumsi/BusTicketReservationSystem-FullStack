import { TestBed } from '@angular/core/testing';

import { SeatPlanService } from './seat-plan';

describe('SeatPlan', () => {
  let service: SeatPlanService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SeatPlanService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
