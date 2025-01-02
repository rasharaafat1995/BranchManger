import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Branch } from 'src/app/models/branch.model.model';
import { Booking } from '../../../models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private apiUrl = 'https://localhost:7226/api/booking';

  constructor(private http: HttpClient) { }

  getBranches(): Observable<Branch[]> {
    return this.http.get<Branch[]>(`${this.apiUrl}/branches`);
  }

  bookBranch(booking: Booking): Observable<any> {
    return this.http.post<any>(this.apiUrl, booking);
  }
}
