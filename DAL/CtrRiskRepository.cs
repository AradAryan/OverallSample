using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CtrRiskRepository : RepositoryBase<FAQTest>
    {
        public CtrRiskRepository(SyndromeDBEntities Context)
    : base(Context)
        { }



        public List<RiskVM> GetRisks(int take , int skip , out int totalCount) {
            totalCount = 0;
            var result = new List<RiskVM>();
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());
            var x = _dataContext.storp_Ctr_SearchRisk(take, skip, total);
            foreach(var y in x)
            {
                result.Add(new RiskVM
                {
                    Row = (int)y.Row,
                    id = y.id,
                    CashierId = y.CashierId,
                    RiskId =y.RiskId,
                    FirstName =y.FirstName,
                    LastName = y.LastName,
                    NationalCode = y.NationalCode,
                    CustomerCode = y.CustomerCode,
                    Description = y.Description

                });

            }
            totalCount = (int)total.Value;
            return result;
        }

        public void InsertRisk(RiskVM y)
        {
            var risk = new Ctr_Risk()
            {
                id = y.id,
                CashierId = y.CashierId,
                RiskId = y.RiskId,
                FirstName = y.FirstName,
                LastName = y.LastName,
                NationalCode = y.NationalCode,
                CustomerCode = y.CustomerCode,
                Description = y.Description
            };
            _dataContext.Ctr_Risk.Add(risk);

        }



        public List<RiskVM> GetRisksByCashierId(int id,int take, int skip, out int totalCount)
        {
            totalCount = 0;
            var result = new List<RiskVM>();
            ObjectParameter total = new ObjectParameter("total", totalCount.GetType());
            var x = _dataContext.storp_Ctr_SearchRiskByCashierId(id,take, skip, total);
            foreach (var y in x)
            {
                result.Add(new RiskVM
                {
                    Row = (int)y.Row,
                    id = y.id,
                    CashierId = y.CashierId,
                    RiskId = y.RiskId,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    NationalCode = y.NationalCode,
                    CustomerCode = y.CustomerCode,
                    Description = y.Description

                });

            }
            totalCount = (int)total.Value;
            return result;
        }

    }
}
