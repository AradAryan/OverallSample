using CommonLib;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DiseasesBLL
    {
        public static List<DAL.Disease> GetBySyndromicId(SyndromTypeCode syndCode)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                int synCode = (int)syndCode;
                // var model = unitofwork.DiseaseRepository.GetMany(x => x.SyndromId == synId).ToList();
                var model = unitofwork.DiseaseRepository.Where(x => x.Tbl_Syndromic.Code == synCode).ToList();
                return model;
            }
        }

        // public static List<DAL.Disease> GetBySyndromicId(long synId)
        // {
        //     using (UnitOfWork unitofwork = new UnitOfWork())
        //     {
        //         var model = unitofwork.DiseaseRepository.GetMany(x => x.SyndromId == synId).ToList();
        //         return model;
        //     }
        // }

        public static Disease GetByDiseasesId(long? DiseasesId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                Disease model = unitofwork.DiseaseRepository.GetById(DiseasesId.Value);
                return model;
            }
        }

        public static List<Disease> GetAll()
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
                return unitofwork.DiseaseRepository.GetAll().ToList();
        }

        public static Disease GetByTitle(string item)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
                return unitofwork.DiseaseRepository.GetByName(item);
        }

        public static List<Disease> GetLabSupportedDiseases(int syndromId, int userId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.DiseaseRepository.GetLabSupportedDiseases(syndromId, userId).OrderBy(x => x.DiseasesName).ToList();
            }
        }

        public static List<Disease> GetBySyndromicId(int syndromId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.DiseaseRepository.Where(x => x.SyndromId == syndromId).ToList();
            }
        }
    }
}
