import { ModalService } from './../../services/modal.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  @Input() title: string | undefined

  constructor(public modalService : ModalService) { }

  ngOnInit() {
  }

}
