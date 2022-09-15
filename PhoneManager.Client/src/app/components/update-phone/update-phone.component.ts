import { IPhone } from './../../models/phone';
import { ModalService } from './../../services/modal.service';
import { PhoneService } from 'src/app/services/phone.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-update-phone',
  templateUrl: './update-phone.component.html',
  styleUrls: ['./update-phone.component.css']
})
export class UpdatePhoneComponent implements OnInit {

  @Input() phone: IPhone

  form = new FormGroup({
    name: new FormControl<string>('', [
      Validators.required,
      Validators.maxLength(70)
    ]),
    mobilePhone: new FormControl<string>('', [
      Validators.pattern('^(\\+375+(24|25|29|33|44)+([0-9]){7})$'),
      Validators.required
    ]),
    jobTitle: new FormControl<string>('', [
      Validators.required,
      Validators.maxLength(70)
    ]),
    birthDate: new FormControl<string>('', [
      Validators.required
    ])
  })

  get name() {
    return this.form.controls.name as FormControl
  }
  get mobilePhone() {
    return this.form.controls.mobilePhone as FormControl
  }
  get jobTitle() {
    return this.form.controls.jobTitle as FormControl
  }
  get birthDate() {
    return this.form.controls.birthDate as FormControl
  }

  constructor(private phoneService: PhoneService,
    public modalService: ModalService) { }

  ngOnInit() {
  }

  submit() {
    if (this.form.valid) {

      this.phoneService.update(
        {
          id: this.phone.id! as string,
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
