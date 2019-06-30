using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CustomerApp.Model
{
    public class Customer: IEntityBase
    {
        static int nextId;
        public int ID { get; private set; }

        public Customer()
        {
            ID = Interlocked.Increment(ref nextId);
        }
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
