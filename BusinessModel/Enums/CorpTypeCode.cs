using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{

    /// <summary>
    /// کد نوع سازمان
    /// </summary>
    public enum CorpTypeCode
    {
        /*
	دانشگاه علوم پزشکی					2
	مرکز بهداشتی درمانی شهری				4
	شبکه بهداشت شهرستان					3
	آزمایشگاه								6
	وزارت بهداشت							1
	بیمارستان								8
	مرکز بهداشتی درمانی شهری روستایی	5
	مرکز بهداشتی درمانی روستایی			7
	پایگاه بهداشت							9
	خانه بهداشت							10
	مدرسه / دانشگاه						11
	زندان									12
	مرکز نظامی								13
	اردوگاه								14
	سایر مراکز تجمعی						15
         * */
        /// <summary>وزارت بهداشت</summary>
        Ministry = 1,

        /// <summary>دانشگاه علوم پزشکی</summary>
        University = 2,

        /// <summary>شبکه بهداشت شهرستان</summary>
        Network = 3,

        /// <summary>مرکز بهداشتی درمانی شهری</summary>
        CityHealthCenter = 4,

        /// <summary>مرکز بهداشتی درمانی شهری روستایی</summary>
        CityAndVillageHealthCenter = 5,

        /// <summary>آزمایشگاه</summary>
        Lab = 6,

        /// <summary>مرکز بهداشتی درمانی روستایی</summary>
        VillageHealthCenter = 7,

        /// <summary>بیمارستان</summary>
        Hospital = 8,

        /// <summary>پایگاه بهداشت</summary>
        HealthStation = 9,

        /// <summary>خانه بهداشت</summary>
        HealthHouse = 10,

        /// <summary>مدرسه / دانشگاه</summary>
        School = 11,

        /// <summary>زندان</summary>
        Jail = 12,

        /// <summary>مرکز نظامی</summary>
        Military = 13,

        /// <summary>اردوگاه</summary>
        Camp = 14,

        /// <summary>سایر مراکز تجمعی</summary>
        Location = 15,
    }
}
