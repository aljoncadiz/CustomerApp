using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Model
{
    public class Address: EntityBase
    {
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
