using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CustomerApp.Model
{
    public class Address: IEntityBase
    {
        static int nextId;
        public int ID { get; private set; }

        public Address()
        {
            ID = Interlocked.Increment(ref nextId);
        }
        /// <summary>
        /// Suite or Apartment number if applicable
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Street Address
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City
        /// TODO: should be from list of cities
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// TODO: Validate state
        /// </summary>
        public string State { get; set; }
    }
}
