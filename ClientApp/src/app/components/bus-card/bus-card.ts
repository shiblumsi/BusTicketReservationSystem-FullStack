import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IAvailableBus } from '../../core/models/available-bus.dto';



@Component({
  selector: 'app-bus-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './bus-card.html',
  styleUrls: ['./bus-card.css'],
})
export class BusCard {
  @Input() availableBus!: IAvailableBus;
  @Output() busSelected = new EventEmitter<string>();

  selectBus() {
    this.busSelected.emit(this.availableBus.scheduleId);
  }
}
