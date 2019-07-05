import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { CustomerServiceService } from '../customer-service.service';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.scss']
})
export class CustomerCreateComponent implements OnInit {

  constructor(private fb: FormBuilder, private customerService: CustomerServiceService) { }

  customerForm: FormGroup;

  ngOnInit() {
    this.customerForm = this.fb.group({
      'fullname': ['', Validators.required],
      'birthdate': ['', Validators.required],
      'age': ['', Validators.required],
      'addressLine1': ['', Validators.required],
      'addressLine2': ['', Validators.required],
      'city': ['', Validators.required]
    })
  }

  submitForm(){
    if(this.customerForm.valid){
      this.customerService.createCustomer(this.customerForm.value)
    }
  }
}
