import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ModalService{

  constructor() {
  }
  isVisibleCreate$ = new BehaviorSubject<boolean>(false)
  isVisibleUpdate$ = new BehaviorSubject<boolean>(false)

  openCreate() {
    this.isVisibleCreate$.next(true)
  }

  openUpdate() {
    this.isVisibleUpdate$.next(true)
  }

  close() {
    this.isVisibleUpdate$.next(false)
    this.isVisibleCreate$.next(false)
  }
}
