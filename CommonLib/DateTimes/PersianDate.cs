using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace WPF.Controls.DateTimes
{
    public class PersianDate
    {

        public static DateTime GetMiladiDate(string PersianDate)
        {
            string[] str = PersianDate.Split('/');
            PersianCalendar pd = new PersianCalendar();
            return (pd.ToDateTime(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]), 0, 0, 0, 0));
        }
    }
}
