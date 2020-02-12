using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Service
{
    [Serializable]
    public class MinimumServiceOperationResult
    {
        public bool Succeed { get; set; }
        public int RecordId { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
