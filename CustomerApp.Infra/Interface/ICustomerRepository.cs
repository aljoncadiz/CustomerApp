using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infra.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer();

        Customer GetCustomerById(int id);

        Customer UpdateCustomer(Customer customer);

        Customer CreateCustomer(Customer customer);

        void DeleteCustomer(int id);
    }
}
