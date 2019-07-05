import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-db-service';

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService implements InMemoryDbService {

  constructor() { }

  createDb(){
    let customers = [
      { id: 1, fullname: 'Aljon Cadiz', birthdate: 'October 4, 1993', Age: 25, AddressLine1: '10th Flr Accralaw Tower', AddressLine2: 'Bonifacio Global City', City: 'Taguig' },
      { id: 2, fullname: 'Joey Banania', birthdate: 'September 25, 1993', Age: 32, AddressLine1: '10th Flr Accralaw Tower', AddressLine2: 'Bonifacio Global City', City: 'Taguig' },
      { id: 3, fullname: 'Julius De Castro', birthdate: 'November 16, 1993', Age: 45, AddressLine1: '10th Flr Accralaw Tower', AddressLine2: 'Bonifacio Global City', City: 'Taguig' }
    ];
    return {customers};
  }
}
