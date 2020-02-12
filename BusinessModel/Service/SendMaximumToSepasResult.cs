using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel.Service
{
    public class SendMaximumToSepasResult
    {
        public string CompositionUID { get; set; }

        public string patientUID { get; set; }

        public string ErrorMessage { get; set; }

        public string MessageUID { get; set; }
    }
}
