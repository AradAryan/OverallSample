using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class UserVM
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CorporateId { get; set; }
    }
}
