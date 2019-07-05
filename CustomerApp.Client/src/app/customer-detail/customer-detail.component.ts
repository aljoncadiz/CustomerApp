import { Component, OnInit } from '@angular/core';
import { CustomerServiceService } from '../customer-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {

  customer: Customer;

  constructor(private customerService: CustomerServiceService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.customerService.getCustomerById(params.get('id')).subscribe( _customer => {
        this.customer = _customer;
      })
    })
  }

}
