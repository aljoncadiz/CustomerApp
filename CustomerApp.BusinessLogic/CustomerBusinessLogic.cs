using CustomerApp.BusinessLogic.Interface;
using CustomerApp.Infra.Interface;
using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.BusinessLogic
{
    public class CustomerBusinessLogic : ICustomerBusinessLogic
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessLogic(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await this._customerRepository.CreateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await this._customerRepository.DeleteCustomer(id);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await this._customerRepository.GetCustomerById(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersList()
        {
            return await this._customerRepository.GetAllCustomer();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await this._customerRepository.UpdateCustomer(customer);
        }
    }
}
