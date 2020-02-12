using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Security.Cryptography;
using BusinessModel;
namespace BLL
{
    public class PhoneBLL
    {

        //public List<PhoneVM> Search(PhoneVM filter, int skip, int take, out int totalCount)
        //{
        //    var uow = new UnitOfWork();
        //    return uow.PhoneRepository.Search(filter, skip, take, out totalCount);
        //}

        //public PhoneVM Get(int id)
        //{
        //    var uow = new UnitOfWork();
        //    var dbModel = uow.PhoneRepository.FirstOrDefault(x => x.Id == id);
        //    return Mapper.Map(dbModel);
        //}

        //public bool Save(PhoneVM model)
        //{
        //    using (var uow = new UnitOfWork())
        //    {
        //        try
        //        {

        //            Phone dbModel = null;
        //            if (model.Id != 0)
        //            {
        //                dbModel = uow.PhoneRepository.FirstOrDefault(x => x.Id == model.Id);
        //                dbModel.Id = model.Id;
        //                dbModel.Firstname = model.Firstname;
        //                dbModel.Lastname = model.Lastname;
        //                dbModel.Mobile = model.Mobile;
        //            }
        //            else
        //            {
        //                dbModel = new Phone()
        //                {
        //                    Id = model.Id,
        //                    Firstname = model.Firstname,
        //                    Lastname = model.Lastname,
        //                    Mobile = model.Mobile
        //                };
        //                uow.PhoneRepository.Add(dbModel);
        //            }
        //            uow.Save();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}
