using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class MaxRespiratory
    {
        /// <summary>تعداد بستری شده</summary>
        public int AdmitedCount { get; set; }

        /// <summary>تعداد موارد نمونه گیری شده</summary>
        public int TotalSampledCount { get; set; }

        /// <summary>تعداد زنان</summary>
        public int Female { get; set; }

        /// <summary>تعداد مردان</summary>
        public int Male { get; set; }

        /// <summary>تفکیک سنی موارد بستری شده</summary>
        public List<KeyValuePair<string, int>> GroupedByAge { get; set; }

        /// <summary>تعداد بیمارستانهای گزارش دهنده</summary>
        public int ReportedHospitalsCount { get; set; }

        /// <summary>تعداد موارد مثبت</summary>
        public int PositiveItemsCount { get; set; }

        /// <summary>تعداد موارد فوت شده</summary>
        public int DiedCount { get; set; }

        /// <summary>تعداد موارد فوت شده با آزمایش مثبت</summary>
        public int DiedCountWithPositiveResult { get; set; }

        /// <summary>موارد مثبت</summary>
        public List<KeyValuePair<string, double>> GroupedByVirus { get; set; }

        /// <summary>موارد فوت شده با آزمایش مثبت</summary>
        public List<KeyValuePair<string, double>> DiedGroupedByVirus { get; set; }

        /// <summary>موارد مثبت به تفکیک سنی</summary>
        public List<KeyValuePair<string, int>> PositiveGroupedByAge { get; set; }

        /// <summary>موارد مثبت فوت شده به تفکیک سنی</summary>
        public List<KeyValuePair<string, int>> DiedPositiveGroupedByAge { get; set; }

        /// <summary>موارد فوت شده به تفکیک سنی</summary>
        public List<KeyValuePair<string, int>> DiedGroupedByAge { get; set; }


        /// <summary>بیماری زمینه ای به تفکیک سن</summary>
        public List<AgeGroup> MedicalHistoryGroups { get; set; }

        /// <summary>بیماری زمینه ای به تفکیک سن - موارد مثبت</summary>
        public List<AgeGroup> PositiveMedicalHistoryGroups { get; set; }

        /// <summary>بیماری زمینه ای به تفکیک سن - موارد فوت شده</summary>
        public List<AgeGroup> DiedMedicalHistoryGroups { get; set; }

        /// <summary>بیماری زمینه ای به تفکیک سن - موارد فوت شده مثبت</summary>
        public List<AgeGroup> DiedPositiveMedicalHistoryGroups { get; set; }

        /// <summary>عوارض به تفکیک سن</summary>
        public List<AgeGroup> ComplicationGroups { get; set; }

        /// <summary>عوارض به تفکیک سن - موارد مثبت</summary>
        public List<AgeGroup> PositiveComplicationGroups { get; set; }

        /// <summary>عوارض به تفکیک سن - موارد فوت شده</summary>
        public List<AgeGroup> DiedComplicationGroups { get; set; }

        /// <summary>عوارض به تفکیک سن - موارد فوت شده مثبت</summary>
        public List<AgeGroup> DiedPositiveComplicationGroups { get; set; }
    }
}
