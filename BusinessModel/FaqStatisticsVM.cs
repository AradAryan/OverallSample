using System;
using System.Collections.Generic;
using System.Linq;


namespace BusinessModel
{
    public class FaqStatisticsVM
    {
        public int Id { get; set; }
        public int Row { get; set; }

        private string _systemName;
        public string SystemName
        {
            get {
                if (Id == 1)
                {
                    _systemName = "وزارت بهداشت";
                }
                else if (Id == 2)
                {
                    _systemName = "بانک آینده";

                }
                else
                {
                    _systemName = "بانک ملت";
                }
                return _systemName;
            }   
            
        }
        public int Count { get; set; }
        public List<FaqStatsVM> Statistics { get; set; }

    }
}
