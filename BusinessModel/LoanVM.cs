using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class LoanVM
    {
        public int Id { get; set; }
        public int Row { get; set; }

        public string NationalCode { get; set; }
        public string ClientCode { get; set; }
        public Nullable<int> MaaliUserId { get; set; }
        public int LoanTypeId { get; set; }
        public int CustId { get; set; }
        public int CashierId { get; set; }
        public Nullable<long> Amount { get; set; }
        public Nullable<int> GiveBackTime { get; set; }
        public Nullable<bool> BranchBossOK { get; set; }
        public string BranchBossExplain { get; set; }
        public string MaaliUserExplain { get; set; }
        public Nullable<bool> MaaliUserOK { get; set; }
        public Nullable<bool> EtebariUserOK { get; set; }
        public string EtebariUserExplain { get; set; }

    }
}
