using CustomerApp.Infra.Interface;
using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infra
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IData data): base (data.CustomerList)
        {

        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await this.Create(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await this.Delete(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await this.FindAll();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await this.FindById(id);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await this.Update(customer.ID, customer);
        }
    }
}
