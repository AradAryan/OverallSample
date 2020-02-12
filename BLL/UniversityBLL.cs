using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;
using DAL;


namespace BLL
{
    public class UniversityBLL
    {

        public static List<University> GetAll()
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UniversityRepository.GetAll().OrderBy(x => x.UniversityName).ToList();
            }
        }
        public static List<University> GetByProvince(int provinceId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UniversityRepository.Where(c => c.ProvinceId == provinceId).ToList();
            }
        }

        public static List<Corporate> GetProUniversity(string province)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.Where(u => u.ParentId == 8803 && 
                                                                 u.ClientName != "Lab" && 
                                                                 (String.IsNullOrEmpty(province) || u.Provience == province))
                                                     .GroupBy(x => x.Name)
                                                     .Select(x => x.FirstOrDefault())
                                                     .OrderBy(x => x.Name)
                                                     .ToList();
            }
        }


        public static List<Corporate> GetProNetwork(int UniversityId, string province)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                if (String.IsNullOrEmpty(province))
                {
                    if (UniversityId != 0)
                        return unitofwork.CorporateRepository.Where(u => u.ClientName == "Network" && 
                                                                         u.ParentId == UniversityId)
                                                             .GroupBy(x => x.Name)
                                                             .Select(x => x.FirstOrDefault())
                                                             .OrderBy(x => x.Name)
                                                             .ToList();
                    else
                        return unitofwork.CorporateRepository.Where(u => u.ClientName == "Network").GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                }
                else
                {
                    if (UniversityId != 0)
                        return unitofwork.CorporateRepository.Where(u => u.ClientName == "Network" && u.ParentId == UniversityId && u.Provience == province).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                    else
                        return unitofwork.CorporateRepository.Where(u => u.ClientName == "Network" && u.Provience == province).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                }

            }
        }




        public static List<Corporate> GetProCenter(int NetworkId, 
                                                   int UniversityId, 
                                                   string province)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                if (NetworkId != 0)
                    return unitofwork.CorporateRepository.Where(u => u.ClientName != "Network" && 
                                                                     u.ClientName != "Ministry" && 
                                                                     u.ClientName != "University" && 
                                                                     u.ParentId == NetworkId)
                                                         .GroupBy(x => x.Name)
                                                         .Select(x => x.FirstOrDefault())
                                                         .OrderBy(x => x.Name)
                                                         .ToList();
                else
                {
                    if (UniversityId != 0)
                    {
                        if (String.IsNullOrEmpty(province))
                        {
                            var target = new List<Corporate>();
                            var lastTtarget = new List<Corporate>();
                            var lastLastTtarget = new List<Corporate>();
                            target = unitofwork.CorporateRepository.Where(u => u.ParentId == UniversityId).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                            foreach (var item in target)
                            {
                                lastTtarget.AddRange(unitofwork.CorporateRepository.Where(u => u.ClientName != "Network" && u.ClientName != "Ministry" && u.ClientName != "University" && u.ParentId == item.Id).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList());
                            }
                            return lastTtarget;
                        }
                        else
                        {
                            var target = new List<Corporate>();
                            var lastTtarget = new List<Corporate>();
                            var lastLastTtarget = new List<Corporate>();
                            target = unitofwork.CorporateRepository.Where(u => u.ParentId == UniversityId && u.Provience == province).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                            foreach (var item in target)
                            {
                                lastTtarget.AddRange(unitofwork.CorporateRepository.Where(u => u.ClientName != "Network" && u.ClientName != "Ministry" && u.ClientName != "University" && u.ParentId == item.Id).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList());
                            }
                            return lastTtarget;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(province))
                            return unitofwork.CorporateRepository.Where(u => u.ClientName != "Network" && u.ClientName != "Ministry" && u.ClientName != "University" && u.Provience == province).GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                        else
                        {
                            return unitofwork.CorporateRepository.Where(u => u.ClientName != "Network" && u.ClientName != "Ministry" && u.ClientName != "University").GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).OrderBy(x => x.Name).ToList();
                        }
                    }
                }

            }
        }

        public static List<University> GetFirstInCollecttion(Guid UniversityID)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UniversityRepository.GetMany(x => x.UniversityID == UniversityID).ToList();
            }
        }

        public static University Get(Guid ID)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.UniversityRepository.GetAll().First(m => m.UniversityID == ID);
            }
        }

        //public static List<University> SelectAll()
        //{
        //    using (UnitOfWork unitofwork = new UnitOfWork())
        //    {
        //        return unitofwork.UniversityRepository.GetAll();
        //    }
        //}
    }
}


