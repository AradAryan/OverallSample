using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Exam20
{
    public class Exam20UserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long UniversityId { get; set; }
        public int CorporateId { get; set; }
    }
}
