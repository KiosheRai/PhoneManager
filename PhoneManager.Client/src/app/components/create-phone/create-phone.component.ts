import { ModalService } from './../../services/modal.service';
import { Component, OnInit } from '@angular/core';
import { PhoneService } from 'src/app/services/phone.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-phone',
  templateUrl: './create-phone.component.html',
  styleUrls: ['./create-phone.component.css']
})
export class CreatePhoneComponent implements OnInit {

  form = new FormGroup({
    name: new FormControl<string>('', [
      Validators.required,
      Validators.maxLength(70)
    ]),
    mobilePhone : new FormControl<string>('', [
      Validators.pattern('^(\\+375+(24|25|29|33|44)+([0-9]){7})$'),
      Validators.required
    ]),
    jobTitle : new FormControl<string>('', [
      Validators.required,
      Validators.maxLength(70)
    ]),
    birthDate : new FormControl<string>('', [
      Validators.required
    ])
  })

  get name(){
    return this.form.controls.name as FormControl
  }
  get mobilePhone(){
    return this.form.controls.mobilePhone as FormControl
  }
  get jobTitle(){
    return this.form.controls.jobTitle as FormControl
  }
  get birthDate(){
    return this.form.controls.birthDate as FormControl
  }

  constructor(private phoneService: PhoneService,
    private modalService: ModalService) { }

  ngOnInit() {
  }

  submit() {
    if(this.form.valid){
      
    this.phoneService.create(
      {
        name: this.form.value.name as string,
        jobTitle: this.form.value.jobTitle as string,
        mobilePhone: this.form.value.mobilePhone as string,
        birthDate: new Date((this.form.value.birthDate as string))
      }).subscribe(() => {
        this.modalService.close()
      })
    }
  }
}
