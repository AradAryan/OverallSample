using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(SyndromeDBEntities Context)
            : base(Context) { }
        public User GetByPeriority(int priority)
        {
            SqlParameter id = new SqlParameter("Priority", priority);
            var person = _dataContext.Database.SqlQuery<User>("SELECT * from tbl_User where Priority = @Priority ", id).ToList();
            if (person.Count > 0)
            {
                return person[0];
            }
            else
            {
                return null;
            }
        }

        public User GetUser(string CellPhone)
        {
            var User = from codes in _dataContext.Users
                       where codes.Mobile == CellPhone
                       select codes;
            return User.FirstOrDefault();
        }

        public User GetUserByUserName(string username)
        {
            var User = from codes in _dataContext.Users
                       where codes.UserName == username
                       select codes;
            return User.FirstOrDefault();
        }

        public List<CenterList_With_UserList_Model> CenterList_With_UserList_BaseOn_FeildOfView(string text, int corporateId)
        {
            bool? SpecialCenterType = null;
            using (UnitOfWork uw = new UnitOfWork())
            {
                SpecialCenterType = uw.CenterTypeRepository.GetCorparateCenterType(corporateId);
            }

            if (SpecialCenterType.HasValue)
            {
                if (SpecialCenterType.Value == true)
                {
                    return _dataContext.Get_Special_CenterList_with_UserList_ForRegisterUser_BasedOnFieldOfView(text, corporateId, 1000000000).ToList();
                }
                else
                {
                    return _dataContext.GetCenterList_with_UserList_ForRegisterUser_BasedOnFieldOfView(text, corporateId, 1000000000).ToList();
                }
            }
            else
            {
                return _dataContext.GetCenterList_with_UserList_ForRegisterUser_BasedOnFieldOfView(text, corporateId, 1000000000).ToList();
            }


        }

        public string GetNameById(int id)
        {
            return Where(x => x.Id == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
        }

        public long GetCorporateIdByUserId(int userId)
        {
            return Where(x => x.Id == userId).Select(x => x.CorporateId).FirstOrDefault();
        }

        public BusinessModel.ProvinceAndCity GetProvinceAndCity(int userId)
        {
            var item = _dataContext.spGetProvinceAndCity(userId).FirstOrDefault();
            return Mapper.Map(item);
        }

        public BusinessModel.UserCorporateInfo GetCorporateInfo(int userId)
        {
            var item = _dataContext.spGetUserCorporateInfo(userId).FirstOrDefault();
            return Mapper.Map(item);
        }

        public List<spSearchUsers_Result> GetCorporateUsers(long corpId, string firstname, string lastname, string username, string mobile, string email, int skip, int take)
        {
            return _dataContext.spSearchUsers(corpId, firstname, lastname, username, mobile, email, skip, take).ToList();
        }

        public BusinessModel.UserModel SaveUser(BusinessModel.UserModel user)
        {
            var result = _dataContext.spSaveUser(user.Id, user.CorporateId, user.Username, user.Password, user.Firstname, user.Lastname, user.Mobile, user.Phone, user.Email, user.PositionId).FirstOrDefault();
            return Mapper.Map(result);
        }

        public void DeleteOrDisableUser(int userId)
        {
            _dataContext.DeleteOrDisableUser(userId);
        }
    }
}
