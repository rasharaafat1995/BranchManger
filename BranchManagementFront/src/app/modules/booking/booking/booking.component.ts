import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookingService } from '../services/booking.service';
import { Branch } from 'src/app/models/branch.model.model';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  bookingForm: FormGroup;
  branches: Branch[] = [];
  successMessage: string = '';

  constructor(private fb: FormBuilder, private bookingService: BookingService) {
    this.bookingForm = this.fb.group({
      branchId: [null, Validators.required],
      name: ['', [Validators.required, Validators.minLength(3)]],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{11}$')]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  ngOnInit(): void {
    this.bookingService.getBranches().subscribe((data:any) => {
      this.branches = data.branches;
    });
  }

  onSubmit(): void {
    if (this.bookingForm.valid) {
      this.bookingService.bookBranch(this.bookingForm.value).subscribe((response) => {
        this.successMessage = response.message;
        this.bookingForm.reset();
      });
    }
  }
}




