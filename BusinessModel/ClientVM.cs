using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class ClientVM
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustTypeId { get; set; }
        public string NationalCode { get; set; }
        public string  ClientCode { get; set; }

    }
}
