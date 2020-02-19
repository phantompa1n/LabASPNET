using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameAPP.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public string Login { get; set; }

        public int Lvl { get; set; }

        public int PlayerId { get; set; }

        public int StepCount { get; set; }
    }
}