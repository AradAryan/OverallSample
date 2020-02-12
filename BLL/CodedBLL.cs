using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
   public class CodedBLL
    {
       public static List<Coded> GetAll(string CodeType)
       {
           using (UnitOfWork unitofwork=new UnitOfWork())
           {
               return unitofwork.CodedRepository.Where(m => m.CodeType == CodeType).ToList();
           }
       }
       public static List<Coded> GetAll()
       {
           using (UnitOfWork unitofwork = new UnitOfWork())
           {
               return unitofwork.CodedRepository.GetAll().ToList();
           }
       }
    }
}
