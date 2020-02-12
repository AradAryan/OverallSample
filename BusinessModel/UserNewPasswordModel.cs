using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class UserNewPasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string AgainNewPassword { get; set; }
    }
}
