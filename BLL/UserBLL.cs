using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Security.Cryptography;
using BusinessModel;
namespace BLL
{
    public class UserBLL
    {
        public static readonly string Salt = "faranam";
        //public static User IsValidUser(string login, string password)
        //{
        //    using (UnitOfWork unitOfWork = new UnitOfWork())
        //    {
        //        return unitOfWork.UserRepository.IsValidUser(login, password);
        //    }
        //}

        public static string HashPassword(string password)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] buffer1 = System.Text.Encoding.ASCII.GetBytes(password + Salt);
            buffer1 = x.ComputeHash(buffer1);
            return System.Text.Encoding.ASCII.GetString(buffer1);
        }

        public static bool ChangePassword(string UserName, string OldPassword, string NewPassword)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                try
                {
                    DAL.User user = unitofwork.UserRepository.GetUserByUserName(UserName);
                    if (user == null)
                        return false;
                    MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
                    byte[] buffer1 = System.Text.Encoding.ASCII.GetBytes(OldPassword + Salt);
                    buffer1 = x.ComputeHash(buffer1);
                    byte[] buffer2 = System.Text.Encoding.ASCII.GetBytes(NewPassword + Salt);
                    buffer2 = x.ComputeHash(buffer2);
                    if (System.Text.Encoding.ASCII.GetString(buffer1) != user.Password)
                        return false;
                    else
                    {
                        Update(user, System.Text.Encoding.ASCII.GetString(buffer2));
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        private static void Update(DAL.User user, string NewPassword)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                DAL.User m_User = unitOfWork.UserRepository.GetById(user.Id);
                m_User.Password = NewPassword;
                unitOfWork.Save();
            }
        }

        public static DAL.User GetUser(string UserName)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UserRepository.Get(m => m.UserName == UserName);
            }
        }

        public static void Add(DAL.User user)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.UserRepository.Add(user);
                unitOfWork.Save();
            }
        }
        public static List<DAL.User> GetData()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.GetAll().ToList();
            }
        }

        public static void Delete(int userId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.UserRepository.DeleteOrDisableUser(userId);
            }
        }

        public static IEnumerable<DAL.User> GetAllUser()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.GetAll();
            }
        }


        public static DAL.User GetById(int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.GetById(Id);
            }
        }

        public static string GetUserCorporateName(int userId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserCorporatesHierarchyRepository.GetUserCorporateName(userId);
            }
        }

        public static List<CenterList_With_UserList_Model> CenterList_With_UserList_BaseOn_FeildOfView(string text, int corporateId, Guid? Universiy, int? Province, int? City)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.CenterList_With_UserList_BaseOn_FeildOfView(text, corporateId).Where(x =>
                    (!Universiy.HasValue || x.UniversityId == Universiy) &&
                    (!Province.HasValue || x.ProvinceId == Province) &&
                    (!City.HasValue || x.CityId == City)

                    ).ToList();
            }
        }

        public static void Update(DAL.User user)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                DAL.User m_User = unitOfWork.UserRepository.GetById(user.Id);
                m_User.LastName = user.LastName;
                //m_User.Priority = user.Priority;
                //m_User.UserName = user.UserName;
                //m_User.UserPass = user.UserPass;
                m_User.Email = user.Email;
                m_User.FirstName = user.FirstName;
                unitOfWork.Save();
            }
        }

        public static void UpdateUserForm(DAL.User user)
        {
            //using (UnitOfWork unitOfWork = new UnitOfWork())
            //{
            //    User m_User = unitOfWork.UserRepository.GetById(user.Id);

            //    m_User.FirstName = user.FirstName;
            //    m_User.LastName = user.LastName;
            //    m_User.Code = user.Code;
            //    m_User.UserName = user.UserName;
            //    m_User.Email = user.Email;
            //    m_User.Mobile = user.Mobile;
            //    m_User.CanWorkAsSupervisor = user.CanWorkAsSupervisor;
            //    m_User.ExpDate = user.ExpDate;
            //    m_User.IsActive = user.IsActive;
            //    m_User.DigitSign = user.DigitSign;
            //    m_User.Description = user.Description;
            //    m_User.PositionId = user.PositionId;
            //    m_User.EmailIsVerified = true;
            //    m_User.IP = user.IP;
            //    m_User.Title = user.Title;
            //    m_User.Telphone = user.Telphone;
            //    m_User.ClientName = user.ClientName;
            //    m_User.FirstDateReg = user.FirstDateReg;
            //    m_User.FirstUserReg = user.FirstUserReg;
            //    m_User.WarningThreshold = user.WarningThreshold;
            //    //     m_User.FirstName = user.FirstName;

            //    unitOfWork.Save();
            //}
        }

        //public static User NextUser(int PriorityId)
        //{
        //    using (UnitOfWork unitOfWork = new UnitOfWork())
        //    {
        //        Priority p = unitOfWork.PriorityRepository.GetNext(PriorityId);
        //        User m_User=null; 
        //        if (p != null)
        //        {
        //            m_User = unitOfWork.UserRepository.GetUser(p.PriorityId);
        //        }
        //        return m_User;
        //    }
        //}
        //public static User GetFirst()
        //{
        //    using (UnitOfWork unitOfWork = new UnitOfWork())
        //    {
        //        return unitOfWork.UserRepository.GetFirst();
        //    }
        //}
        //public static User GetLast()
        //{
        //    using (UnitOfWork unitOfWork = new UnitOfWork())
        //    {
        //        return unitOfWork.UserRepository.GetLast();
        //    }
        //}

        public static UserPositionHierarchy GetUserPositionHierarchy(int userId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var data = unitOfWork.GetUserPositionHierarchy(userId);
                UserPositionHierarchy result = new UserPositionHierarchy();
                if (data.Count > 0)
                {
                    result.ProvinceId = data[data.Count - 1].Id;
                    result.ProvinceName = data[data.Count - 1].Name;
                }
                if (data.Count > 1)
                {
                    result.UniversityId = data[data.Count - 2].Id;
                    result.UniversityName = data[data.Count - 2].Name;
                }
                if (data.Count > 2)
                {
                    result.NetworkId = data[data.Count - 3].Id;
                    result.NetworkName = data[data.Count - 3].Name;
                }
                if (data.Count > 3)
                {
                    result.CenterId = data[data.Count - 4].Id;
                    result.CenterName = data[data.Count - 4].Name;
                }

                return result;
            }
        }

        public static long GetCorporateId(int userId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UserRepository.Where(x => x.Id == userId).Select(x => x.CorporateId).FirstOrDefault();
            }
        }

        public static ProvinceAndCity GetProvinceAndCity(int userId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UserRepository.GetProvinceAndCity(userId);
            }
        }

        internal static UserCorporatesHierarchy GetHierarchy(int userId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UserCorporatesHierarchyRepository.GetByUserId(userId);
            }
        }

        public static List<spSearchUsers_Result> GetCorporateUsers(long corpId, string firstname, string lastname, string username, string mobile, string email, int skip = 0, int take = 10)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UserRepository.GetCorporateUsers(corpId, firstname, lastname, username, mobile, email, skip, take);
            }
        }

        public static UserModel SaveUser(UserModel user)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                #region جلوگیری از تکراری بودن کد ملی

                if (user.Id != 0)
                {
                    var userExists = unitofwork.UserRepository.Any(u => u.UserName == user.Username && u.IsActive && u.Id != user.Id);
                    if (userExists)
                        throw new Exception("کد ملی وارد شده تکراری است");
                }
                else
                {
                    var userExists = unitofwork.UserRepository.Any(u => u.UserName == user.Username && u.IsActive);
                    if (userExists)
                        throw new Exception("کد ملی وارد شده تکراری است");
                }

                #endregion



                if (string.IsNullOrEmpty(user.Password))
                    user.Password = null;
                else
                    user.Password = HashPassword(user.Password);

                // شماره موبایل میبایست با کد کشور شروع شود
                // به این دلیل که هنگام دریافت 
                // minimum
                // از سرور پیامک، شماره تلفن با کد کشور شروع میشود
                if (!string.IsNullOrEmpty(user.Mobile) && !user.Mobile.StartsWith("98"))
                {
                    if (user.Mobile.StartsWith("0"))
                        user.Mobile = user.Mobile.Substring(1);
                    user.Mobile = "98" + user.Mobile;
                }

                return unitofwork.UserRepository.SaveUser(user);
            }
        }

        public static DAL.User GetUserWithItsCorporate(int UserId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var user = unitofwork.UserRepository.GetById(UserId);

                return user;
            }
        }

        public static UserCorporatesHierarchy GetUserCorporats(int userId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UserCorporatesHierarchyRepository.GetByUserId(userId);
            }
        }

        public static UserModel Get(int id)
        {
            var dbUser = GetById(id);
            return Mapper.Map(dbUser);
        }

        public static void Retrieve(int id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var user = unitofwork.UserRepository.FirstOrDefault(x => x.Id == id);
                string username = user.UserName.Replace("p", "");
                // باید چک شود که اگر این کاربر فعال شود، آیا با کاربر دیگری 
                // conflict دارد یا نه
                var otherUser = unitofwork.UserRepository.Any(x => x.Id != id && x.IsActive && x.UserName == username);
                if (otherUser)
                    throw new Exception("امکان بازیابی وجود ندارد. کاربر دیگری با همین کد ملی فعال است");

                user.IsActive = true;
                user.UserName = user.UserName.Replace("p", "");
                unitofwork.Save();
            }
        }

        public static DAL.User GetByUsername(string username)
        {
            return new UnitOfWork().UserRepository.FirstOrDefault(x => x.UserName == username);
        }
    }
}
