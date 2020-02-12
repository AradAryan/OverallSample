using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Statistics
{
    public class EpidemicMax : EpidemicReportModel
    {
        /// <summary>گروه بندی بر اساس نوع بیماری</summary>
        public List<KeyValuePair<string, int>> GroupedByDisease { get; set; }

        /// <summary>درصد موارد مثبت به تفکیک بیماری</summary>
        public List<KeyValuePair<string, double>> GroupedByDiseasePercent { get; set; }

        /// <summary>تعداد موارد مثبت</summary>
        public int PositiveCount { get; set; }

        /// <summary>تفکیک سنی بیماریها</summary>
        public List<BusinessModel.Statistics.DiseaseGenderAgeGroup> DiseaseAgeGroup { get; set; }

        /// <summary>درصد تفکیک سنی بیماریها</summary>
        public List<BusinessModel.Statistics.DiseaseGenderAgeGroup> DiseaseAgeGroupPercent { get; set; }

        /// <summary>درصد تفکیک سنی بیماریها در همان گروه سنی</summary>
        public List<BusinessModel.Statistics.DiseaseGenderAgeGroup> DiseaseAgeGroupPercentInTheSameAge { get; set; }

        /// <summary>تفکیک جنسیتی بیماریها</summary>
        public List<BusinessModel.Statistics.DiseaseGenderAgeGroup> DiseaseGenderGroup { get; set; }

        /// <summary>درصد تفکیک جنسیتی بیماریها</summary>
        public List<BusinessModel.Statistics.DiseaseGenderAgeGroup> DiseaseGenderGroupPercent { get; set; }

        /// <summary>درصد تفکیک جنسیتی بیماریها در همان جنس</summary>
        public List<BusinessModel.Statistics.DiseaseGenderAgeGroup> DiseaseGenderGroupPercentInTheSameGender { get; set; }

        /// <summary>تعداد موارد نمونه گیری شده</summary>
        public int SampledCount { get; set; }

        /// <summary>تفکیک جنسیتی و سنی بیماریها</summary>
        public List<DiseaseGenderAgeGroup> DiseaseGenderAgeGroup { get; set; }


        /// <summary>درصد تفکیک جنسیتی و سنی بیماریها</summary>
        public List<Statistics.DiseaseGenderAgeGroup> DiseaseGenderAgeGroupPercent { get; set; }

        /// <summary>درصد تفکیک جنسیتی و سنی بیماریها در همان گروه سنی و جنسی</summary>
        public List<Statistics.DiseaseGenderAgeGroup> DiseaseGenderAgeGroupPercentInTheSameGenderAgeGroup { get; set; }

        /// <summary>درصد موارد نمونه گیری شده</summary>
        public double SampledPercent { get; set; }

        /// <summary>تفکیک جنسیتی و سنی بیماریهی موارد فوت شده</summary>
        public List<Statistics.DiseaseGenderAgeGroup> CFR_DiedDiseaseGenderAgeGroup { get; set; }

        /// <summary>تفکیک جنسیتی بیماریهای موارد فوت شده</summary>
        public List<Statistics.DiseaseGenderAgeGroup> CFR_DiedDiseaseGender { get; set; }

        /// <summary>تفکیک سنی بیماریهای موارد فوت شده</summary>
        public List<Statistics.DiseaseGenderAgeGroup> CFR_DiedDiseaseAgeGroup { get; set; }

        /// <summary>میزان کشندگی سندروم به تفکیک جنس و سن</summary>
        public List<AgeGroup> SyndromCFR { get; set; }
    }
}
