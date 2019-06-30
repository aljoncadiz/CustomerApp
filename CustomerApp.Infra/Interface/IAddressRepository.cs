using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infra.Interface
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddress();

        Task<Address> GetAddressById(int id);

        Task<Address> UpdateAddress(Address address);

        Task<Address> CreateAddress(Address address);

        Task DeleteAddress(int id);
    }
}
