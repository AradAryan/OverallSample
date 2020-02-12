using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace DAL
{
    public class MainAccess
    {



        private NewUserManagementEntities _um;
        public NewUserManagementEntities UMDb
        {
            get
            {
                //Windows application
                if (HttpContext.Current == null)
                {
                    if (_um == null)
                        _um = new NewUserManagementEntities();
                    return _um;
                }

                //Web application
                var context = HttpContext.Current.Items["ObjectContext"] as NewUserManagementEntities;
                if (context == null)
                {
                    context = new NewUserManagementEntities();
                    HttpContext.Current.Items.Add("ObjectContext", context);
                }

                return context as NewUserManagementEntities;
            }
        }
       
        

    }
}
