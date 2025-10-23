import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableBus } from './available-bus';

describe('AvailableBus', () => {
  let component: AvailableBus;
  let fixture: ComponentFixture<AvailableBus>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AvailableBus]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvailableBus);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
