import { IPhone } from './../models/phone';
import { ErrorService } from './error.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { catchError, delay, Observable, retry, tap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  constructor(private http: HttpClient, private errorService: ErrorService) { }

  phones: IPhone[] = []

  getAll(): Observable<IPhone[]> {
    return this.http.get<IPhone[]>('https://localhost:44337/api/Phone')
      .pipe(
        delay(200),
        retry(2),
        tap(phone => this.phones = phone),
        catchError(this.errorHandler.bind(this))
      )
  }

  create(phone: IPhone): Observable<IPhone> {
    this.phones.push(phone)
    return this.http
      .post<IPhone>("https://localhost:44337/api/Phone", phone)
  }

  update(phone: IPhone): Observable<IPhone> {
    let index = this.phones.findIndex(d => d.id === phone.id!)
    this.phones.splice(index, 1)
    this.phones.push(phone)
    console.log(phone);

    return this.http
      .put<IPhone>(`https://localhost:44337/api/Phone`, phone)
  }

  delete(phoneId: string): Observable<void> {
    let index = this.phones.findIndex(d => d.id === phoneId)
    this.phones.splice(index, 1)
    return this.http
      .delete<void>(`https://localhost:44337/api/Phone/${phoneId}`)
  }

  private errorHandler(error: HttpErrorResponse) {
    this.errorService.handle(error.message)
    return throwError(() => error.message)
  }
}
