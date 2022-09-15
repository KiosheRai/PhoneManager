import { UpdatePhoneComponent } from './components/update-phone/update-phone.component';
import { CreatePhoneComponent } from './components/create-phone/create-phone.component';
import { ModalComponent } from './components/modal/modal.component';
import { FilterPhonesPipe } from './pipes/filter-phones.pipe';
import { GlobalErrorComponent } from './components/global-error/global-error.component';
import { PhoneComponent } from './components/phone/phone.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    PhoneComponent,
    GlobalErrorComponent,
    FilterPhonesPipe,
    ModalComponent,
    CreatePhoneComponent,
    UpdatePhoneComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
