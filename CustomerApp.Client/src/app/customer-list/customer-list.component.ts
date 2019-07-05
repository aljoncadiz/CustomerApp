import { Component, OnInit } from '@angular/core';
import { CustomerServiceService } from '../customer-service.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {

  customers: Customer[] = [];

  constructor(private customerService: CustomerServiceService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe( (result: Customer[]) => {
      this.customers = result;
    })
  }
}
