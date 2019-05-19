using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrayonTest.Models.OutputModels
{
    public class ResponseRatesModel
    {
        public string Base { get; set; }
        public DateTime Start_at { get; set; }
        public DateTime End_at { get; set; }
        public Dictionary<DateTime, Dictionary<string, double>> Rates { get; set; }
    }
}
