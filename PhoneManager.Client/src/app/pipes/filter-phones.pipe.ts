import { IPhone } from './../models/phone';

import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterProducts'
})
export class FilterPhonesPipe implements PipeTransform {

  transform(phones: IPhone[], search: string): IPhone[] {
    if (search.length === 0) return phones
    return phones.filter(p=>
      p.name
      .toLowerCase()
      .includes(search.toLowerCase()));
  }

}
