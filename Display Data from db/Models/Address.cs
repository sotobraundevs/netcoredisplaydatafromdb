using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Display_Data_from_db.Models
{
    public class Address
    {
        public string AddressID { get; set; }

        public string AddresLine { get; set; }

        public string City { get; set; }

        public string StateProviceID { get; set; }

        public string PostalCode { get; set; }

        public String SpatialLocation { get; set; }
        public string RowID { get; set; }
        public string ModifiedDate { get; set; }
    }
}
