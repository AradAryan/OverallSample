using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessModel
{
    public class FaqVM
    {

        public int Id { get; set; }
        public int Row { get; set; }
        public string QustionText { get; set; }
        public string AnswerText { get; set; }
        public string ImageFileName { get; set; }
        public bool Enabled { get; set; }
        public int SystemId { get; set; }


    }
}
