﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MSGAdmissionRepository:RepositoryBase<MSG_Admission>
    {
        public MSGAdmissionRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
        public void Delete(long AdmissionID)
        {
            SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
            _dataContext.Database.ExecuteSqlCommand("Delete TblMSG_Admission where AdmissionID = @AdmissionID ", id);
        }
    }

}
