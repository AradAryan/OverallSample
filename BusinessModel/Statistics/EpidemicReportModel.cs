using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class EpidemicReportModel
    {
        /// <summary>تعداد بستری شده</summary>
        public int TotalCount { get; set; }

        /// <summary>تعداد ویزیت ها</summary>
        public int TotalVisitCount { get; set; }

        #region تعداد

        /// <summary>تعداد زنان</summary>
        public int Female { get; set; }

        /// <summary>تعداد مردان</summary>
        public int Male { get; set; }

        /// <summary>تعداد زنان ایرانی</summary>
        public int IranianFemale { get; set; }

        /// <summary>تعداد مردان ایرانی</summary>
        public int IranianMale { get; set; }

        /// <summary>تعداد زنان غیرایرانی</summary>
        public int ForeignerFemale { get; set; }

        /// <summary>تعداد مردان غیر ایرانی</summary>
        public int ForeignerMale { get; set; }

        /// <summary>تفکیک سنی موارد </summary>
        public List<KeyValuePair<string, int>> GroupedByAge { get; set; }

        /// <summary>تفکیک سنی ایرانی ها </summary>
        public List<KeyValuePair<string, int>> IranianAgeGroups { get; set; }

        /// <summary>تفکیک سنی غیرایرانی ها </summary>
        public List<KeyValuePair<string, int>> ForeignerAgeGroups { get; set; }

        /// <summary>تعداد به تفکیک سندروم</summary>
        public List<KeyValuePair<string, int>> GroupedBySyndrom { get; set; }

        /// <summary>تعداد بیمارستانهای گزارش دهنده</summary>
        public int ReportedHospitalsCount { get; set; }

        public int Iranian { get; set; }

        public int Foreigner { get; set; }

        public List<KeyValuePair<string, int>> MaleAgeGroups { get; set; }

        public List<KeyValuePair<string, int>> FemaleAgeGroups { get; set; }


        #endregion


        #region درصد

        
        /// <summary>درصد زنان</summary>
        public double FemalePercent { get; set; }

        /// <summary>درصد مردان</summary>
        public double MalePercent { get; set; }

        /// <summary>درصد زنان ایرانی</summary>
        public double IranianFemalePercent { get; set; }

        /// <summary>درصد مردان ایرانی</summary>
        public double IranianMalePercent { get; set; }

        /// <summary>درصد زنان غیرایرانی</summary>
        public double ForeignerFemalePercent { get; set; }

        /// <summary>درصد مردان غیر ایرانی</summary>
        public double ForeignerMalePercent { get; set; }

        /// <summary>تفکیک سنی موارد </summary>
        public List<KeyValuePair<string, double>> GroupedByAgePercent { get; set; }

        /// <summary>تفکیک سنی ایرانی ها </summary>
        public List<KeyValuePair<string, double>> IranianAgeGroupsPercent { get; set; }

        /// <summary>تفکیک سنی غیرایرانی ها </summary>
        public List<KeyValuePair<string, double>> ForeignerAgeGroupsPercent { get; set; }

        /// <summary>درصد به تفکیک سندروم</summary>
        public List<KeyValuePair<string, double>> GroupedBySyndromPercent { get; set; }

        public double IranianPercent { get; set; }

        public double ForeignerPercent { get; set; }

        public List<KeyValuePair<string, double>> MaleAgeGroupsPercent { get; set; }

        public List<KeyValuePair<string, double>> FemaleAgeGroupsPercent { get; set; }

        #endregion


    }
}
