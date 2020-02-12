using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LoanRepository : RepositoryBase<FAQTest>
    {
        public LoanRepository(SyndromeDBEntities Context)
    : base(Context)
        { }

        public List<LoanVM> SearchLoan(LoanVM user, int take, int skip, out int totalCount)
        {
            var list = new List<LoanVM>();
            totalCount = 0;
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());
            var items = _dataContext.storp_Crtbl_SearchLoan(user.NationalCode, user.ClientCode, user.CashierId, take, skip, total).ToList();
            foreach (var item in items)
            {
                var model = new LoanVM
                {
                    Id = item.id,
                    Row = (int)item.Row,
                    CustId = item.CustId,
                    CashierId = item.CashierId,
                    ClientCode = item.CUSTNO,
                    NationalCode = item.SHMELI,
                    LoanTypeId = item.LoanTypeId,
                    Amount = item.Amount,
                    GiveBackTime = item.GiveBackTime,
                    MaaliUserId = item.MaaliUserId,
                    BranchBossOK = item.BranchBossOK,
                    BranchBossExplain = item.BranchBossExplain,
                    MaaliUserOK = item.MaaliUserOK,
                    MaaliUserExplain = item.MaaliUserExplain,
                    EtebariUserOK = item.EtebariUserOK,
                    EtebariUserExplain = item.EtebariUserExplain
                };
                list.Add(model);
            }

            return list;
        }

        public ClientVM GetClient(ClientVM client)
        {

            var user = _dataContext.Crtbl_CustInfo.FirstOrDefault(u => u.SHMELI == client.NationalCode || u.CUSTNO == client.ClientCode);
            var customer = new ClientVM()
            {
                id = user.id,
                FirstName = user.FirstNameCon,
                LastName = user.LastNameCon,
                CustTypeId = user.CustTypeId,
                ClientCode = user.CUSTNO,
                NationalCode = user.SHMELI
            };
            return customer;

        }


        public void InsertLoan(LoanVM loanToInsert)
        {
            var loan = new Crtbl_Loan()
            {
                CustId = loanToInsert.CustId,
                Amount = loanToInsert.Amount,
                LoanTypeId = loanToInsert.LoanTypeId,
                GiveBackTime = loanToInsert.GiveBackTime,
                CashierId = loanToInsert.CashierId
            };
            _dataContext.Crtbl_Loan.Add(loan);

        }


        public void EditBoss(int id, bool submit)
        {
            var loan = _dataContext.Crtbl_Loan.SingleOrDefault(l => l.id == id);
            if (loan != null)
            {
                loan.BranchBossOK = submit;

            }

        }


        public void EditEtebari(int id,string tozihat,bool submit)
        {
            var loan = _dataContext.Crtbl_Loan.SingleOrDefault(l => l.id == id);
            if (loan != null)
            {
                loan.EtebariUserExplain = tozihat;
                loan.EtebariUserOK = submit;

            }

        }


        public void EditMaali(int id, string tozihat, bool submit)
        {
            var loan = _dataContext.Crtbl_Loan.SingleOrDefault(l => l.id == id);
            if (loan != null)
            {
                loan.MaaliUserExplain = tozihat;
                loan.MaaliUserOK = submit;

            }

        }



        public List<LoanVM> SearchLoanForEtebariUser(LoanVM user, int take, int skip, out int totalCount)
        {
            var list = new List<LoanVM>();
            totalCount = 0;
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());
            var items = _dataContext.storp_Crtbl_SearchLoanForEtebariUser(user.NationalCode, user.ClientCode, user.CashierId, take, skip, total).ToList();
            foreach (var item in items)
            {
                var model = new LoanVM
                {
                    Id = item.id,
                    Row = (int)item.Row,
                    CustId = item.CustId,
                    CashierId = item.CashierId,
                    ClientCode = item.CUSTNO,
                    NationalCode = item.SHMELI,
                    LoanTypeId = item.LoanTypeId,
                    Amount = item.Amount,
                    GiveBackTime = item.GiveBackTime,
                    MaaliUserId = item.MaaliUserId,
                    BranchBossOK = item.BranchBossOK,
                    BranchBossExplain = item.BranchBossExplain,
                    MaaliUserOK = item.MaaliUserOK,
                    MaaliUserExplain = item.MaaliUserExplain,
                    EtebariUserOK = item.EtebariUserOK,
                    EtebariUserExplain = item.EtebariUserExplain
                };
                list.Add(model);
            }

            return list;
        }


        public List<LoanVM> SearchLoanForMaaliUser(LoanVM user, int take, int skip, out int totalCount)
        {
            var list = new List<LoanVM>();
            totalCount = 0;
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());
            var items = _dataContext.storp_Crtbl_SearchLoanForMaaliUser(user.NationalCode, user.ClientCode, user.CashierId, take, skip, total).ToList();
            foreach (var item in items)
            {
                var model = new LoanVM
                {
                    Id = item.id,
                    Row = (int)item.Row,
                    CustId = item.CustId,
                    CashierId = item.CashierId,
                    ClientCode = item.CUSTNO,
                    NationalCode = item.SHMELI,
                    LoanTypeId = item.LoanTypeId,
                    Amount = item.Amount,
                    GiveBackTime = item.GiveBackTime,
                    MaaliUserId = item.MaaliUserId,
                    BranchBossOK = item.BranchBossOK,
                    BranchBossExplain = item.BranchBossExplain,
                    MaaliUserOK = item.MaaliUserOK,
                    MaaliUserExplain = item.MaaliUserExplain,
                    EtebariUserOK = item.EtebariUserOK,
                    EtebariUserExplain = item.EtebariUserExplain
                };
                list.Add(model);
            }

            return list;
        }

        //        public List<FaqVM> GetFaq(int systemId)
        //        {

        //            var list = new List<FaqVM>();
        //            List<FAQTest> items = _dataContext.FAQTests.Where(l => l.SystemId == systemId).ToList();
        //            foreach (var item in items)
        //            {
        //                list.Add(new FaqVM()
        //                {
        //                    Id = item.Id,
        //                    QustionText = item.QuestionText,
        //                    AnswerText = item.AnswerText,
        //                    ImageFileName = item.ImageFileName,
        //                    Enabled = item.Enabled,
        //                    SystemId = item.SystemId
        //                });
        //            }

        //            return list;
        //        }


        //        public List<FaqVM> GetFaq()
        //        {

        //            var list = new List<FaqVM>();
        //            List<FAQTest> items = _dataContext.FAQTests.ToList();
        //            foreach (var item in items)
        //            {
        //                list.Add(new FaqVM()
        //                {
        //                    Id = item.Id,
        //                    QustionText = item.QuestionText,
        //                    AnswerText = item.AnswerText,
        //                    ImageFileName = item.ImageFileName,
        //                    Enabled = item.Enabled,
        //                    SystemId = item.SystemId
        //                });
        //            }

        //            return list;
        //        }
        //        public void InsertFaq(FaqVM faq)
        //        {
        //            _dataContext.storp_insertorupdatefaq(faq.Id, faq.SystemId, faq.Enabled, faq.QustionText, faq.AnswerText, faq.ImageFileName);
        //        }

        //        public void DeleteFaq(int id)
        //        {
        //                var faq = _dataContext.FAQTests.FirstOrDefault(f => f.Id == id);
        //                _dataContext.FAQTests.Remove(faq);
        //        }

        //        public bool ChangeActivityOfFaq(int id,bool enabled)
        //        {

        //            try
        //            {
        //                _dataContext.storp_changeactivityoffaq(id, enabled);
        //                return true;
        //            }
        //            catch
        //            {
        //                return true;
        //            }
        //        }

        //        public bool EditFaq(FaqVM faq)
        //        {

        //            try
        //            {
        //                _dataContext.storp_editfaq(faq.Id, faq.QustionText, faq.AnswerText, faq.ImageFileName, faq.Enabled, faq.SystemId);

        //                return true;
        //            }
        //            catch
        //            {
        //                return true;
        //            }
        //        }

    }
}
