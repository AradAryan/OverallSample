using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class RiskBLL
    {
        public List<RiskVM> SearchRisk( int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            var result = uow.CtrRiskRepository.GetRisks(take, skip, out total);
            return result;
        }
        public List<RiskVM> GetRisksByCashierId( int id,int take, int skip, out int total)
        {
            UnitOfWork uow = new UnitOfWork();
            var result = uow.CtrRiskRepository.GetRisksByCashierId(id,take, skip, out total);
            return result;
        }
        public bool InsertRisk(RiskVM risk)
        {
            var uow = new UnitOfWork();
            try
            {
                uow.CtrRiskRepository.InsertRisk(risk);
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
