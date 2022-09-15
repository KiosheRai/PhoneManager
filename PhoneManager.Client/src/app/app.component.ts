import { ModalService } from './services/modal.service';
import { PhoneService } from './services/phone.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'PhoneManager.Client'
  loading = false
  term = ""

  constructor(public phoneService: PhoneService,
    public modalService : ModalService) { }

  ngOnInit(): void {
    this.loading = true
    this.phoneService.getAll().subscribe(()=> {
      this.loading = false
    })
  }
}
