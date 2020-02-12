using BLL;
using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class UsersController:BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(UserVM filter ,int take=10 , int skip=0)
        {
            int total = 5;
            //var list = new List<UserVM>()
            //{
            //    new UserVM {FirstName="امیر " ,LastName="صالحی" , IsActive = true , NationalCode="1210112101"  },
            //    new UserVM {FirstName=" محمد" ,LastName="جیگری" , IsActive = true , NationalCode="1234567898"  },
            //    new UserVM {FirstName=" علی" ,LastName="مرتضایی" , IsActive = true , NationalCode="1234569877"  },
            //    new UserVM {FirstName=" رضا" ,LastName="اسدکی" , IsActive = true , NationalCode="1236547569"  },
            //    new UserVM {FirstName=" غلام" ,LastName="محمدی" , IsActive = true , NationalCode="1236547899"  },
            //};
            //var result = list/*.Where(a => a.FirstName.Contains(filter.FirstName)).ToList()*/;
            UserVMBLL bll = new UserVMBLL();
            var result = bll.Search(filter, take, skip, out total);
            return Json(new {
                Data = result,
                Total = total

            }, JsonRequestBehavior.AllowGet);
        }
        

    }
}