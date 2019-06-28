using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infra.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomer();

        Task<Customer> GetCustomerById(int id);

        Task<Customer> UpdateCustomer(Customer customer);

        Task<Customer> CreateCustomer(Customer customer);

        Task DeleteCustomer(int id);
    }
}
