using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class LoanBLL
    {

        public List<LoanVM> SearchLoan(LoanVM user, int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            var result = uow.LoanRepository.SearchLoan(user, take, skip, out total);
            return result;
        }

        public List<LoanVM> SearchLoanForEtebariUser(LoanVM user, int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            var result = uow.LoanRepository.SearchLoanForEtebariUser(user, take, skip, out total);
            return result;
        }

        public List<LoanVM> SearchLoanForMaaliUser(LoanVM user, int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            var result = uow.LoanRepository.SearchLoanForMaaliUser(user, take, skip, out total);
            return result;
        }

        public ClientVM SearchClient(ClientVM client)
        {
            var uow = new UnitOfWork();
            var result = uow.LoanRepository.GetClient(client);
            return result;
        }


        public bool InsertLoan(LoanVM loanToInsert)
        {
            var uow = new UnitOfWork();
            try
            {
                uow.LoanRepository.InsertLoan(loanToInsert);
                uow.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool EditBoss(int id, bool submit)
        {
            try
            {
                var uow = new UnitOfWork();
                uow.LoanRepository.EditBoss(id, submit);
                uow.Save();
                return true;
            }
            catch
            {
                return false;
            }


        }


        public bool EditEtebari(int id,string tozihat, bool submit)
        {
            try
            {
                var uow = new UnitOfWork();
                uow.LoanRepository.EditEtebari(id,tozihat, submit);
                uow.Save();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool EditMaali(int id,string tozihat, bool submit)
        {
            try
            {
                var uow = new UnitOfWork();
                uow.LoanRepository.EditMaali(id,tozihat, submit);
                uow.Save();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public List<FaqVM> GetFaq()
        {
            var uow = new UnitOfWork();
            return uow.TestFaqRepository.GetFaq();

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

    }
}
