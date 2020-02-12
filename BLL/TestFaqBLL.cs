using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TestFaqBLL
    {

        public List<FaqVM> SearchFaq(FaqVM faq, int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            var result = uow.TestFaqRepository.SearchFaq(faq, take, skip, out total);
            return result;
        }


        public List<FaqVM> GetFaq()
        {
            var uow = new UnitOfWork();
          return  uow.TestFaqRepository.GetFaq();

        }
        public List<FaqVM> GetFaqByID(int systemId)
        {
            var uow = new UnitOfWork();
            return uow.TestFaqRepository.GetFaq(systemId);

        }

        public bool InsertFaq(FaqVM faq)
        {
            try
            {
                var uow = new UnitOfWork();
                uow.TestFaqRepository.InsertFaq(faq);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteFaq(int id)
        {
            var uow = new UnitOfWork();

            try
            {
                uow.TestFaqRepository.DeleteFaq(id);
                uow.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UnactivateFaq(int id)
        {
            var uow = new UnitOfWork();
            return uow.TestFaqRepository.ChangeActivityOfFaq(id, false);
        }


        public bool ActivateFaq(int id)
        {
            var uow = new UnitOfWork();
            return uow.TestFaqRepository.ChangeActivityOfFaq(id, true);
        }

        public bool EditFaq(FaqVM faq)
        {
            var uow = new UnitOfWork();
            return uow.TestFaqRepository.EditFaq(faq);
        }



        public List<FaqStatistic> GetFaqStatics()
        {
            var uow = new UnitOfWork();
            return uow.TestFaqRepository.GetFaqStatistics();

        }


        public bool InsertFaqState(FaqStatistic statistic)
        {
            var uow = new UnitOfWork();
            try
            {
                uow.TestFaqRepository.InsertFaqStatisticRecord(statistic);
                uow.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
