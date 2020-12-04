import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class StaffApiService {

  constructor(private http: HttpClient) { }

  private baseUrl = "https://localhost:44377/api/Staff";
  private httpOption = {
    headers: new HttpHeaders({ 'Content-type': 'application/json' })
  };

  getStaffs(staffType: string): Observable<any> {
    const url = `${this.baseUrl}?type=${staffType}`
    return this.http.get<any>(url)
      .pipe(
        tap(_ => console.log('Loaded')),
        catchError(this.handleError<any>('get Staff'))

      );
  }

  addStaff(staff: any): Observable<any> {
    return this.http.post(this.baseUrl, staff, this.httpOption)
      .pipe(
        tap(_ => console.log('Staff added')),
        catchError(this.handleError<any>('add Staff'))

      );
  }

  deleteStaff(staffId: string): Observable<any> {
    const url = `${this.baseUrl}/${staffId}`;
    return this.http.delete<any>(url)
      .pipe(
        tap(_ => console.log('Staff Deleted')),
        catchError(this.handleError<any>('delete staff'))
      );
  }
  
  getStaffById(staffId: string): Observable<any> {
    const url = `${this.baseUrl}/${staffId}`;
    return this.http.get<any>(url)
      .pipe(
        tap(_ => console.log('Fetched staff')),
        catchError(this.handleError<any>('get staff'))
      );
  }

  editStaff(staffId: string, staff: any): Observable<any> {
    const url = `${this.baseUrl}/${staffId}`;
    return this.http.put<any>(url, staff, this.httpOption)
      .pipe(
        tap(_ => console.log('Updated')),
        catchError(this.handleError<any>('edit staff'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }

}
