using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.BusinessLogic.Interface
{
    public interface ICustomerBusinessLogic
    {
        Task<IEnumerable<Customer>> GetCustomersList();

        Task<Customer> GetCustomer(int id);

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer> UpdateCustomer(Customer customer);

        Task DeleteCustomer(int id);
    }
}
