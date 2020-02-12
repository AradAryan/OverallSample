using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{
    //public class PhoneRepository : RepositoryBase<Phone>
    //{
    //    public PhoneRepository(SyndromeDBEntities Context)
    //        : base(Context)
    //    {

    //    }

    //    public List<PhoneVM> Search(PhoneVM filter, int skip, int take, out int totalCount)
    //    {
    //        totalCount = 0;
    //        var totalrecords = new ObjectParameter("totalRecords", totalCount.GetType());
    //        var dbResult = _dataContext.spSearchPhone(filter.Firstname, filter.Lastname, filter.Mobile, skip, take, totalrecords).ToList();
    //        totalCount = (int)totalrecords.Value;
    //        List<PhoneVM> result = new List<PhoneVM>();
    //        foreach (var item in dbResult)
    //        {
    //            result.Add(new PhoneVM()
    //            {
    //                Firstname = item.Firstname,
    //                Lastname = item.Lastname,
    //                Id = item.Id,
    //                Mobile = item.Mobile,
    //                Row = (int)item.Row.GetValueOrDefault()
    //            });
    //        }
    //        return result;
    //    }
    //}
}
