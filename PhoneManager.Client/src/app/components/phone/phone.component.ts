import { ModalService } from './../../services/modal.service';
import { PhoneService } from 'src/app/services/phone.service';
import { IPhone } from './../../models/phone';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-phone',
  templateUrl: './phone.component.html',
  styleUrls: ['./phone.component.css']
})
export class PhoneComponent implements OnInit {

  @Input() phone : IPhone

  constructor(private phoneService: PhoneService, public modalService: ModalService) { }

  ngOnInit() {
  }

  delete(id: string){
    this.phoneService.delete(id).subscribe()
  }
}
