import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'abcd1234'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  API_URL: string = '/api/';

  constructor(private http: HttpClient) { }

  getCustomers(){
    return this.http.get(this.API_URL + 'customers', httpOptions);
  }

  getCustomerById(customerId){
    return this.http.get(`${this.API_URL + 'customers'}/${customerId}`, httpOptions);
  }

  updateCustomer(customer: Customer){
    return this.http.put(`${this.API_URL + 'customer'}/${customer.id}`, customer, httpOptions)
  }

  createCustomer(customer: Customer){
    return this.http.post(`${this.API_URL + 'customer'}`, customer, httpOptions)
  }
}
