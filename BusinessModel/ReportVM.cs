using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
   public class ReportVM
    {
       public int Row { get; set; }

    //   public int Id { get; set; }

       public string Univercity { get; set; }
       public string City { get; set; }

       public string Syndromic { get; set; }

       public int Count { get; set; }

    }
   public class ReportVM2
   {
       public int Row { get; set; }

       //   public int Id { get; set; }       
       public int university { get; set; }
       public int province { get; set; }

       public int syndromId { get; set; }
       public int syndromCount { get; set; }

       public int CenterId { get; set; }

   }
}
