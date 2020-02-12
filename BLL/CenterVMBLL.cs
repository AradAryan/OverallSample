using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CenterVMBLL
    {
        public IEnumerable<CenterVM> Search(CenterVM filter, int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            IEnumerable<CenterVM> list = uow.CenterVmRepository.Search(filter, take, skip, out total);
            return list;
        }

        public IEnumerable<CorporateUserVM> GetUsersByCorpId(int corporateId, CorporateUserVM user, int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            IEnumerable<CorporateUserVM> list = uow.CenterVmRepository.GetUsers(corporateId, user, take, skip, out total);
            return list;
        }


        public CenterVM GetcorporateByItsCorpId(int corporateId)
        {
            UnitOfWork uow = new UnitOfWork();
            CenterVM item = uow.CenterVmRepository.GetCorporateById(corporateId);
            return item;
        }

        public bool DeactivateUser(int activate , int userId)
        {
            UnitOfWork uow = new UnitOfWork();
            try
            {
                uow.CenterVmRepository.ActiveOrDeactivateUser(activate, userId);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public List<PositionVM> GetPosition()
        {
            UnitOfWork uow = new UnitOfWork();
            return uow.CenterVmRepository.GetPosition();
        } 

        public bool InsertUser(UserVM user)
        {
            var uow = new UnitOfWork();
            return uow.CenterVmRepository.InsertUser(user);
        }

        public UserVM GetUserById(int id)
        {
            var uow = new UnitOfWork();
            return uow.CenterVmRepository.GetUserById(id);
        }
    }
}
