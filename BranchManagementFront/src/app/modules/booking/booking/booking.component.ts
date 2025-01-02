import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  constructor() { }

  ngOnInit(): void { }

  bookBranch(branchId: number): void {
    // Logic to book a branch
    alert(`Branch with ID ${branchId} has been booked!`);
  }
}
