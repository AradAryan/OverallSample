using BusinessModel;
using System.Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserVMRepository : RepositoryBase<UserVM>
    {
        public UserVMRepository(SyndromeDBEntities Context)
            : base(Context)
        { }


        public IEnumerable<UserVM> Search(UserVM user,int take, int skip, out int totalCount)
        {

            List<UserVM> users = new List<UserVM>();
            totalCount = 0;
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());

            var list = _dataContext.storp_searchuser(user.FirstName, user.LastName, user.NationalCode, take, skip, total).ToList();
            foreach (var item in list)
            {
                var model = new UserVM()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    NationalCode = item.Code,
                    IsActive = item.IsActive,
                    Row = (int)item.Row
                };
                users.Add(model);
            }
            totalCount = (int)total.Value;
            return users;

        }
    }
}
