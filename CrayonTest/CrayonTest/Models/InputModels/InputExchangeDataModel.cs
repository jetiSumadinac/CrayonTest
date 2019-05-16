using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrayonTest.Models.InputModels
{
    public class InputExchangeDataModel
    {
        public string BaseCurr { get; set; }
        public string TargetCurr { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}
