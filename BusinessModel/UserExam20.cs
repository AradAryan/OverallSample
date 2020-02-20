using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class UserExam20
    {
        public int Id { get; set; }
        public int CorporateId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }

    }
}
