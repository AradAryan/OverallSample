using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DiseaseAccessRepository : RepositoryBase<DAL.Sp_SearchDisease_Result> ,IDisposable
    {
        public DiseaseAccessRepository(SyndromeDBEntities context)
            : base(context)
        {

        }

        public List<Sp_SearchDisease_Result> SearchDiseaseAccess(int syndromId, int diseaseId, int skip, int take)
        {
            return _dataContext.Sp_SearchDisease(syndromId, diseaseId, skip, take).ToList();
        }

        public List<SpGetDiseasesAccess_Result> GetDiseasesAccess(int diseaseId)
        {
            return _dataContext.SpGetDiseasesAccess(diseaseId).ToList();
        }

        public void AddDiseasesAccess(int PositionId, int diseaseId)
        {
            Position position = _dataContext.Positions.Where(tbl => tbl.Id == PositionId).FirstOrDefault();
            Disease disease = _dataContext.Diseases.Where(tbl => tbl.Id == diseaseId).FirstOrDefault();

            if (position != null && disease != null)
            {
                TblDiseasesAccess diseasesAccess = new TblDiseasesAccess();
                diseasesAccess.DiseasesId = diseaseId;
                diseasesAccess.PositionsId = PositionId;

                int id = _dataContext.TblDiseasesAccesses.Add(diseasesAccess).Id;
                _dataContext.SaveChanges();
            }
        }

        public void RemoveDiseasesAccess(int Id)
        {
            _dataContext.TblDiseasesAccesses.Remove(_dataContext.TblDiseasesAccesses.Where(tbl => tbl.Id == Id).FirstOrDefault());
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
