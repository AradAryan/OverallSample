using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class SyndromicBLL
    {
        public static List<Syndromic> GetAll()
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.SyndromicRepository.GetAll().ToList();
            }
        }

        public static IEnumerable<BusinessModel.SyndromicModel> Get()
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.SyndromicRepository.GetAll()
                                                     .Select(item => Mapper.Map(item))
                                                     .OrderBy(x => x.SyndromicId)
                                                     .ToList();
            }
        }

        public static List<Syndromic> GetAllLabSyndrom()
        {
            using (UnitOfWork un = new UnitOfWork())
            {
                return un.SyndromicRepository.GetMany(x => x.IsIncludedInLab == true).ToList();
            }
        }

        public static List<Disease> GetRelatedDissies(int Id)
        {
            using (UnitOfWork un = new UnitOfWork())
            {
                var model = un.SyndromicRepository.Get(x => x.SyndromicId == Id).Diseases.ToList();
                return model;
            }
        }

        public static Syndromic GetByTitle(string item)
        {
            using (UnitOfWork un = new UnitOfWork())
                return un.SyndromRegisterRepository.GetByTitle(item);
        }

    }
}
