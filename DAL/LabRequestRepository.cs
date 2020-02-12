using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LabRequestRepository : RepositoryBase<RequestLab>
    {
        public LabRequestRepository(SyndromeDBEntities context)
            : base(context)
        {

        }

        public void Update(RequestLab rl)
        {
            var model = _dataContext.RequestLabs.FirstOrDefault(x => x.AdmissionID == rl.AdmissionID);

            //throw new NotImplementedException();
            //  model.AdmissionID = rl.AdmissionID;
            // model.SpecimenType = rl.RequestLabId;
            model.specimenDate = rl.specimenDate;
            model.SpecimenType = rl.SpecimenType;

            _dataContext.SaveChanges();
        }

        public void Delete(long AdmissionID)
        {
            SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
            _dataContext.Database.ExecuteSqlCommand("Delete RequestLab where AdmissionID = @AdmissionID ", id);
        }
    }
}
