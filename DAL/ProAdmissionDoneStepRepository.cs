using BusinessModel;
using CommonLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProAdmissionDoneStepRepository : RepositoryBase<ProAdmissionDoneStep>
    {
        public ProAdmissionDoneStepRepository(SyndromeDBEntities Context)
            : base(Context)
        {
        }

        public void StepDone(int proAdmissionId, int userId, long stepId, bool skipped)
        {
            // find done step record
            var doneSteps = Where(x => x.ProAdmissionId == proAdmissionId).ToList();
            var record = doneSteps.FirstOrDefault(x => x.StepId == stepId);
            if (record == null)
            {
                record = new ProAdmissionDoneStep()
                {
                    Date = CommonLib.Common.NormalizePersianDate(CommonLib.Common.GetPersianDate(DateTime.Now)),
                    ProAdmissionId = proAdmissionId,
                    StepId = stepId,
                    Skipped = skipped,
                    UserId = userId
                };
                Add(record);
            }
            else
            {
                record.UserId = userId;
                record.Skipped = skipped;
            }
            this._dataContext.SaveChanges();
        }
    }
}


