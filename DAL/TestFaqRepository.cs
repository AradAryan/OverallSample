using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TestFaqRepository : RepositoryBase<FAQTest>
    {
        public TestFaqRepository(SyndromeDBEntities Context)
    : base(Context)
        { }

        public List<FaqVM> SearchFaq(FaqVM faq, int take, int skip, out int totalCount)
        {
            var list = new List<FaqVM>();
            totalCount = 0;
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());
           var items = _dataContext.storp_searchfaq(faq.QustionText,faq.AnswerText,faq.SystemId,take,skip,total).ToList();
            foreach (var item in items)
            {
                list.Add(new FaqVM()
                {
                    Id = item.Id,
                    Row = (int)item.Row,
                    QustionText = item.QuestionText,
                    AnswerText = item.AnswerText,
                    ImageFileName = item.ImageFileName,
                    Enabled = item.Enabled,
                    SystemId = item.SystemId
                });
            }
            totalCount = (int)total.Value;
            return list;
        }

        public List<FaqVM> GetFaq(int systemId)
        {

            var list = new List<FaqVM>();
            List<FAQTest> items = _dataContext.FAQTests.Where(l => l.SystemId == systemId).ToList();
            foreach (var item in items)
            {
                list.Add(new FaqVM()
                {
                    Id = item.Id,
                    QustionText = item.QuestionText,
                    AnswerText = item.AnswerText,
                    ImageFileName = item.ImageFileName,
                    Enabled = item.Enabled,
                    SystemId = item.SystemId
                });
            }

            return list;
        }


        public List<FaqVM> GetFaq()
        {

            var list = new List<FaqVM>();
            List<FAQTest> items = new List<FAQTest>();
            //_dataContext.FAQTests.ToList();
            items.Add(new FAQTest {
                QuestionText="متن سوال",
                AnswerText = "پاسخ",
                ImageFileName="",
                Enabled=true,
                SystemId=10,
                Id=10,
            });
            foreach (var item in items)
            {
                list.Add(new FaqVM()
                {
                    Id = item.Id,
                    QustionText = item.QuestionText,
                    AnswerText = item.AnswerText,
                    ImageFileName = item.ImageFileName,
                    Enabled = item.Enabled,
                    SystemId = item.SystemId
                });
            }

            return list;
        }
        public void InsertFaq(FaqVM faq)
        {
            _dataContext.storp_insertorupdatefaq(faq.Id, faq.SystemId, faq.Enabled, faq.QustionText, faq.AnswerText, faq.ImageFileName);
        }

        public void DeleteFaq(int id)
        {
                var faq = _dataContext.FAQTests.FirstOrDefault(f => f.Id == id);
                _dataContext.FAQTests.Remove(faq);
        }

        public bool ChangeActivityOfFaq(int id,bool enabled)
        {

            try
            {
                _dataContext.storp_changeactivityoffaq(id, enabled);
                return true;
            }
            catch
            {
                return true;
            }
        }

        public bool EditFaq(FaqVM faq)
        {

            try
            {
                _dataContext.storp_editfaq(faq.Id, faq.QustionText, faq.AnswerText, faq.ImageFileName, faq.Enabled, faq.SystemId);

                return true;
            }
            catch
            {
                return true;
            }
        }



        public List<FaqStatistic> GetFaqStatistics()
        {
            return _dataContext.FaqStatistics.ToList();
        }


        public void InsertFaqStatisticRecord(FaqStatistic statistic)
        {
            _dataContext.FaqStatistics.Add(statistic);
        }
    }
}
