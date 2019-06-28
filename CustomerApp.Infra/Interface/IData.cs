using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infra.Interface
{
    public interface IData
    {
        List<Customer> CustomerList { get; set; }
        List<Address> AddressList { get; set; }
    }
}
