using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;

namespace DAL
{
   public class UniversityRepository:RepositoryBase<University>
    {
       public UniversityRepository(SyndromeDBEntities Context):base(Context)
       {

       }
       //public List<UniversityModel> Get()
       //{
       //    //string StrSql = "exec Sp_GetUniversity";
       //    //var queryResult = _dataContext.Database.SqlQuery<UniversityModel>(StrSql).ToList();
       //    //return queryResult;
       //}
    }
}
