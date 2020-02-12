using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class ProSymptomsModel
    {
        public string c { get; set; }
        public string c_date { get; set; }
        public int AdmissionId { get; set; }
        public bool NoItemSelected { get; set; }
    }
    public class ProSymptomsHospitalModel
    {
        public string c { get; set; }
        public string c_date { get; set; }
        public string c_date_finish { get; set; }
        public string txt { get; set; }
        public string AdverseReaction { get; set; }
        public int AdmissionId { get; set; }
        public bool NoItemSelected { get; set; }
    }
    public class ProSymptomsRHospitalModel
    {
        public string c { get; set; }
        public string cAV { get; set; }
        public string c_date { get; set; }
        public string c_dateAV { get; set; }
        public string c_date_finish { get; set; }
        public string c_date_finishAV { get; set; }
        public string txt { get; set; }
        //public string AdverseReaction { get; set; }
        public string AdverseReactionAV { get; set; }
        public int AdmissionId { get; set; }
        public bool NoItemSelected { get; set; }
    }
}
