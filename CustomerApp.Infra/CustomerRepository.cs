using CustomerApp.Infra.Interface;
using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infra
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IData data): base (data.CustomerList)
        {

        }

        public Customer CreateCustomer(Customer customer)
        {
            return this.Create(customer);
        }

        public void DeleteCustomer(int id)
        {
            this.Delete(id);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return this.FindAll();
        }

        public Customer GetCustomerById(int id)
        {
            return this.FindById(id);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            return this.Update(customer.ID, customer);
        }
    }
}
