using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Model
{
    public class Customer: EntityBase
    {
        /// <summary>
        /// Customer's FirstName & LastName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Age 
        /// TODO Auto calculate from BirthDate?
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// AddressList 
        /// </summary>
        public IEnumerable<Address> AddressList { get; set; }
    }
}
