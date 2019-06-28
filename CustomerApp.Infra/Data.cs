using CustomerApp.Infra.Interface;
using CustomerApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Infra
{
    public class Data: IData
    {
        private static List<Customer> _customerList = new List<Customer>();

        private static List<Address> _addressList = new List<Address>();

        public Data()
        {

        }

        public List<Customer> CustomerList
        {
            get { return _customerList;  }
            set
            {
                _customerList = value;
            }
        }

        public List<Address> AddressList
        {
            get { return _addressList; }
            set
            {
                _addressList = value;
            }
        }
    }
}
