using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CenterVMRepository : RepositoryBase<DAL.Corporate>
    {
        public CenterVMRepository(SyndromeDBEntities Context)
            : base(Context)
        { }
        public IEnumerable<CenterVM> Search(CenterVM filter, int take, int skip, out int total)
        {
            List<CenterVM> list = new List<CenterVM>();
            total = 0;
            ObjectParameter totalCount = new ObjectParameter("totalCount", total.GetType());
            var obje = _dataContext.storp_GetCenters(filter.ProvinceId, filter.UniversityId, filter.CenterId,
                filter.CorporateName, filter.EnName, filter.NationalCode, take, skip, totalCount).ToList();
            foreach (var item in obje)
            {
                var model = new CenterVM()
                {
                    Row = (int) item.Row,
                    CorporateId = (int)item.CorporateId,
                    Province = item.Province,
                    University = item.UniversityCorporateName,
                    CorporateName = item.NetworkCorporateName
                };
                list.Add(model);
            }
            total = (int)totalCount.Value;
            return list;
        }


        public IEnumerable<CorporateUserVM> GetUsers(int corporateId ,CorporateUserVM user, int take, int skip, out int totalCount)
        {
            List<CorporateUserVM> list = new List<CorporateUserVM>();
            totalCount = 0;
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());
            var obje = _dataContext.storp_searchusersofacorporate(corporateId,user.FirstName,user.LastName,
                user.UserName,user.Mobile,user.Email,take,skip,total).ToList();
            foreach (var item in obje)
            {
                var model = new CorporateUserVM()
                {
                    Id = item.Id,
                    Row = (int)item.Row,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    UserName = item.UserName,
                    Mobile = item.Mobile,
                    IsActive = item.IsActive

                };
                list.Add(model);
            }
            totalCount = (int)total.Value;
            return list;
        }

        public CenterVM GetCorporateById(int corporateId)
        {
            var model = new CenterVM();
            var list = _dataContext.storp_getcorporatehierarchy(corporateId).FirstOrDefault();
            //model.CorporateName = list.UniversityCorporateName;
           // model.Province = list.Province;
            return model;
        }

        public void ActiveOrDeactivateUser (int activate , int userid)
        {
            _dataContext.storp_deactiveuser(activate, userid);
        }

        public List<PositionVM> GetPosition()
        {
            var positionList = new List<PositionVM>(); 
            var list = _dataContext.storp_getposition().ToList();
            foreach(var item in list)
            {
                var model = new PositionVM()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                positionList.Add(model);
            }
            return positionList;
        }


        public bool InsertUser(UserVM user)
        {
            try
            {
                _dataContext.storp_insertuser(user.Id, user.PositionId, user.CorporateId, user.FirstName, user.LastName, user.NationalCode, user.Password, user.Mobile,user.Tel,user.Email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UserVM GetUserById(int id)
        {
            var us = _dataContext.Users.FirstOrDefault(u => u.Id == id);
            var user = new UserVM()
            {
                Id = us.Id,
                FirstName = us.FirstName,
                LastName = us.LastName,
                NationalCode = us.Code,
                Password = us.Password,
                Email = us.Email,
                Mobile = us.Mobile,
                Tel = us.Phone,
                PositionId = (int)us.PositionId,
                CorporateId = (int)us.CorporateId
            };
            return user;

        }

    }
}
