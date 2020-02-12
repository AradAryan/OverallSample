using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
   public class BasicDataBLL
    {
       public static List<BasicData> GetByBasicDataType(CommonLib.BasicDataTypeCode basicDataTypeCode)
       {
           using (UnitOfWork unitofwork=new UnitOfWork())
           {
               long _basicDataTypeCode = (long)basicDataTypeCode;
               return unitofwork.BasicDataRepository.Where(x => x.BasicDataType.Code == _basicDataTypeCode).ToList();
           }
       }

       public static BasicData GetByBasicDataTypeAndCode(CommonLib.BasicDataTypeCode basicDataTypeCode, long code)
       {
           using (UnitOfWork unitofwork = new UnitOfWork())
           {
               long _basicDataTypeCode = (long)basicDataTypeCode;
               return unitofwork.BasicDataRepository.Where(x => x.BasicDataType.Code == _basicDataTypeCode && x.Code == code).FirstOrDefault();
           }
       }

       public static long GetIdByBasicDataTypeAndCode(CommonLib.BasicDataTypeCode basicDataTypeCode, long code)
       {
           using (UnitOfWork unitofwork = new UnitOfWork())
           {
               long _basicDataTypeCode = (long)basicDataTypeCode;
               var item = unitofwork.BasicDataRepository.Where(x => x.BasicDataType.Code == _basicDataTypeCode && x.Code == code).FirstOrDefault();
               if (item == null)
                   return 0;
               return item.Id;
           }
       }

       public static BasicData Get(long id)
       {
           using (UnitOfWork unitofwork = new UnitOfWork())
           {
               return unitofwork.BasicDataRepository.GetById(id);
           }
       }
    }
}
