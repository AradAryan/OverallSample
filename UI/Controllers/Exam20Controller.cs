using BLL;
using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class Exam20Controller : Controller
    {
        //
        // GET: /Exam20/
        public static List<CorporateExam20> corporates;
        public static List<UserExam20> users;

        public void SetLists()
        {
            users = new List<UserExam20>()
            {
                new UserExam20 {FirstName="امیر " ,LastName="صالحی" , IsActive = true , NationalCode="1210112101" , CorporateId=75  },
                new UserExam20 {FirstName=" محمد" ,LastName="جیگری" , IsActive = true , NationalCode="1234567898" , CorporateId=75  },
                new UserExam20 {FirstName=" علی" ,LastName="مرتضایی" , IsActive = true , NationalCode="1234569877", CorporateId=85  },
                new UserExam20 {FirstName=" رضا" ,LastName="اسدکی" , IsActive = true , NationalCode="1236547569"  , CorporateId=85 },
                new UserExam20 {FirstName=" غلام" ,LastName="محمدی" , IsActive = true , NationalCode="1236547899"  , CorporateId=75 },
            };
            corporates = new List<CorporateExam20>()
            {
                new CorporateExam20{Id = 75,Name="دانشگاه تهران",City ="تهران",Province="تهران", Code=75 },
                new CorporateExam20{Id = 85,Name="دانشگاه شمسی پور",City ="تهران",Province="تهران", Code=85 },
            };

        }
        public ActionResult Index()
        {
            SetLists();
            return View();
        }
        public ActionResult Search(CorporateExam20 filter, int take = 10, int skip = 0)
        {
            int total = 5;

            //UserVMBLL bll = new UserVMBLL();
            //var result = bll.Search(filter, take, skip, out total);
            var result = corporates;//corporates.Where(current => current == filter);
            return Json(new
            {
                Data = result,
                Total = total

            }, JsonRequestBehavior.AllowGet);
        }

    }
}
