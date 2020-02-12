using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class Txt{
        public string Text { get; set; }
    }

   public class CorporateInfo
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string latinName { get; set; }
        public string desc { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
        public bool IsEdit { get; set; }
        public Txt[] DiseasesMultiSelect { get; set; }
        public Txt[] SyndromicMultiSelect { get; set; } 
   }
}
