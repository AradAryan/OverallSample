using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class FaqStatsVM
    {
        public int id { get; set; }
        public int Row { get; set; }
        public int SystemId { get; set; }
        private string _systemName;
        public string SystemName
        {
            get
            {
                if (SystemId == 1)
                {
                    _systemName = "وزارت بهداشت";
                }
                else if (SystemId == 2)
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

        public Nullable<int> UserId { get; set; }
        public string Ip_Port { get; set; }
        public Nullable<System.DateTime> SeenTime { get; set; }
    }
}
