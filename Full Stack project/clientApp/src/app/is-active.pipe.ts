import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'isActive'
})
export class IsActivePipe implements PipeTransform {

  transform(isActive: any, ): string {
    var _active  = Boolean(isActive);
    return _active ? 'Active' : 'InActive';
  }

}
