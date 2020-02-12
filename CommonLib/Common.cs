using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using Itenso.TimePeriod;
using System.Data;
using Sso.UMProxy;

namespace CommonLib
{
    public class Common
    {
        public static SsoUser CurrentUser
        {
            get
            {
                return HttpContext.Current.User as SsoUser;
            }
        }
        public static int CurrentUserID { get; set; }
        public static string CurrentUserShowLabel
        {
            get
            {
                string label = string.Empty;
                var user = CurrentUser;
                if (user == null) return label;
                try
                {
                    var role = CurrentUser.Position;
                    if (role.Value != "")
                    {
                        label = role.Value;
                    }

                }
                catch
                {
                    label = string.Empty;
                }
                return string.Format("{0} [{1}]", user.ShowName, label);
            }
        }

        public static DateTime GetMiladiDate(string PersianDate)
        {
            if (string.IsNullOrEmpty(PersianDate))
                return new DateTime();
            string[] str = GetCorrectFormatdate(PersianDate).Split('/');
            PersianCalendar pd = new PersianCalendar();
            try
            {
                return (pd.ToDateTime(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]), 0, 0, 0, 0));
            }
            catch
            {
                return new DateTime();
            }
        }

        public static string PersianDateWithoutSlash(string PersianDate)
        {
            string[] str = PersianDate.Split('/');
            if (str.Length == 3)
                return str[0] + str[1] + str[2];
            return "";
        }

        public static DateTime GetMiladiDate(string PersianDate, string Hour, string Minute)
        {
            string[] str = PersianDate.Split('/');
            PersianCalendar pd = new PersianCalendar();
            return (pd.ToDateTime(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(Hour), int.Parse(Minute), 0, 0));
        }

        public static long GetMinutes(string time)
        {
            string[] ST = new string[2];
            ST = time.Split(':');
            if (int.Parse(ST[0]) > 23 || int.Parse(ST[1]) > 59)
                return 3000;
            return int.Parse(ST[0]) * 60 + int.Parse(ST[1]);
        }

        public static string GetConverttime(long minute)
        {
            string time;
            int h = (int)minute / 60;
            int min = (int)minute % 60;
            time = h + ":" + min;
            time = GetCorrectFormatTime(time);
            return time;

        }

        public static string GetCorrectFormatTime(string time)
        {
            string[] times = new string[5];
            times = time.Split(':');
            for (int i = 0; i <= 1; i++)
            {
                if (times[i].Length == 1)
                    times[i] = '0' + times[i];
            }
            return times[0] + ':' + times[1];
        }

        public static string GetCorrectFormatdate(string Date)
        {
            string[] dates = new string[5];
            dates = Date.Split('/');
            for (int i = 0; i <= 2; i++)
            {
                if (dates[i].Length == 1)
                    dates[i] = '0' + dates[i];
            }
            return dates[0] + '/' + dates[1] + '/' + dates[2];
        }

        public static string GetTime(DateTime Dt)
        {
            return GetCorrectFormatTime(Dt.Hour + ":" + Dt.Minute);
        }

        public static string GetPersianDate(DateTime DT)
        {
            PersianCalendar pd = new PersianCalendar();
            string Month = pd.GetMonth(DT).ToString();
            string Days = pd.GetDayOfMonth(DT).ToString();
            return pd.GetYear(DT).ToString() + "/" + ((Month.Length < 2) ? "0" + Month : Month) + "/" + ((Days.Length < 2) ? "0" + Days : Days);
        }

        public static DateTime CurrentDateTime()
        {
            return DateTime.Now;
        }

        public static int AgeYear(string BirthDate)
        {
            long age = 0;
            BirthDate = BirthDate.Replace("/", "");
            if (long.TryParse(BirthDate, out age) && BirthDate.Length == 8)
            {
                BirthDate = BirthDate.Insert(4, "/");
                BirthDate = BirthDate.Insert(7, "/");
                DateTime dt = Common.GetMiladiDate(BirthDate);
                DateDiff dateDiff = new DateDiff(dt, Common.CurrentDateTime());
                return dateDiff.Years;
            }
            else
                return (int)age;
        }

        public static int AgeMonth(string BirthDate)
        {
            DateTime birthDate = Common.GetMiladiDate(BirthDate);
            DateDiff dateDiff = new DateDiff(birthDate, Common.CurrentDateTime());
            return dateDiff.Months;
        }

        public static int CurrentUserBranchCode
        {
            get
            {
                var user = CurrentUser;

                if (user == null || !user.HasPermission(Permission.BranchAccess.ToString())) return -1;
                return (int)(long.Parse(user.Corporates.DescendantsAndSelf("l").ToArray()[0].Attribute("i").Value) % 100000); ;
            }
        }
        public static bool CurrentUserHasPermission(Permission p)
        {
            // todo:  بیات: کد موقتی
            return true;

            var user = CurrentUser;
            if (user == null) return false;
            return user.HasPermission(p.ToString());
        }
        public static bool CurrentUserHasRole(UserRole p)
        {
            var user = CurrentUser;
            if (user == null) return false;
            return user.HasPermission(p.ToString());
        }
        public static bool CurrentUserIsInGroup(UserRole group)
        {
            var user = CurrentUser;
            if (user == null) return false;
            return user.IsInGroup(group.ToString());
        }

        public static string GetGreaterDate(DataRowCollection dtc)
        {
            List<long> li = new List<long>();
            for (int i = 0; i < dtc.Count; i++)
            {
                var k = dtc[i]["FinishDate"].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                string result = "";
                for (int b = 0; b < k.Length; b++)
                {
                    if (k[b].Length == 1)
                    {
                        k[b] = "0" + k[b];
                    }
                    result += k[b];
                }
                li.Add(long.Parse(result));
            }
            var result2 = li.Max().ToString();
            return result2.Substring(0, 4) + "/" + result2.Substring(4, 2) + "/" + result2.Substring(6, 2);
        }

        public static string ConvertStringDateToLongDate(string date)
        {
            var k = date.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            for (int b = 0; b < k.Length; b++)
            {
                if (k[b].Length == 1)
                {
                    k[b] = "0" + k[b];
                }
                result += k[b];
            }
            return result.Substring(0, 4) + "/" + result.Substring(4, 2) + "/" + result.Substring(6, 2);
        }


        //public static string GetGreaterDate(string AdmissionDate)
        //{
        //    List<long> li = new List<long>();
        //    for (int i = 0; i < dtc.Count; i++)
        //    {
        //        var k = dtc[i]["FinishDate"].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        //        string result = "";
        //        for (int b = 0; b < k.Length; b++)
        //        {
        //            if (k[b].Length == 1)
        //            {
        //                k[b] = "0" + k[b];
        //            }
        //            result += k[b];
        //        }
        //        li.Add(long.Parse(result));
        //    }
        //    var result2 = li.Max().ToString();
        //}


        public static string ReturnNameAndType(BusinessModel.NameAndType Model)
        {
            if (Model != null)
                return Model.Name.ToString();
            return "--------";
        }




        public static string ReturnString(object p)
        {
            if (p != null)
                return p.ToString();
            return "";
        }

        public static int GetSyndromIdBaseCoded(List<int?> CodeId)
        {
            int syndromId = 0;
            foreach (var item in CodeId)
            {
                switch (item)
                {
                    case 607:
                        syndromId = 2;
                        break;
                    case 608:
                        syndromId = 3;
                        break;
                    case 609:
                        syndromId = 4;
                        break;
                    default:
                        break;
                }
            }

            return syndromId;
        }


        /// <summary>
        /// استانداردسازی تاریخ های شمسی وارد شده در سیستم
        /// </summary>
        /// <param name="persianDate"></param>
        /// <returns></returns>
        public static string NormalizePersianDate(string persianDate)
        {
            if (string.IsNullOrEmpty(persianDate))
                return persianDate;

            if (persianDate.IndexOf('-') != -1)
                persianDate = persianDate.Replace('-', '/');

            var parts = persianDate.Split('/', '\\');
            if (parts.Length != 3)
                return "";

            int year, month, day;
            int.TryParse(parts[0], out year);
            int.TryParse(parts[1], out month);
            int.TryParse(parts[2], out day);

            // اصلاح جای سال و روز برای تاریخ هایی مثل 11/12/1395
            if (year <= 31 && day > 31)
            {
                int temp = day;
                day = year;
                year = temp;
            }

            // برای مواردی که سال به صورت دو رقمی وارد شده است، دو رقم به ابتدای آن اضافه میکنیم.
            // به جای اضافه کردن 13 دو رقم ابتدایی سال جاری را اضافه میکنیم که در سالهای 1400 به بعد به مشکل نخوریم
            if (year.ToString().Length <= 2)
            {
                year += int.Parse(GetPersianDate(DateTime.Now).Substring(0, 2)) * 100;
            }

            return year.ToString("0000") + "/" + month.ToString("00") + "/" + day.ToString("00");
        }
    }
}
