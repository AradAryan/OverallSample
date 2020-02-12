using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class DeathOrDischargeVM
    {
        /// <summary>شناسه اطلاعات</summary>
        public int AdmissionId { get; set; }

        /// <summary>بیمار فوت کرده است</summary>
        public bool Died { get; set; }

        /// <summary>بیمار ترخیص شده است</summary>
        public bool Discharged { get; set; }

        /// <summary>بیمار بستری است</summary>
        public bool Stayed { get; set; }

        /// <summary>شناسه محل فوت بیمار</summary>
        public int DeathLocationId { get; set; }

        /// <summary>تاریخ فوت بیمار</summary>
        public string DeathDate { get; set; }

        /// <summary>شناسه وضعیت ترخیص</summary>
        public int DischargeStatusId { get; set; }
        
        /// <summary>تاریخ ترخیص</summary>
        public string DischargeDate { get; set; }
    }
}
