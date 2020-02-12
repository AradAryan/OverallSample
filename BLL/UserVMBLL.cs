using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class UserVMBLL
    {
        public IEnumerable<UserVM> Search(UserVM user ,int take , int skip , out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            var result = uow.UservmRepository.Search(user,take,skip,out total);
            return result;

        }
         
    }
}
