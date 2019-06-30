using CustomerApp.Infra.Interface;
using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infra
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(IData data): base(data.AddressList)
        {

        }
        public Task<Address> CreateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddress(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAddressById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await this.FindAll();
        }

        public Task<Address> UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
