using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrayonTest.Models.OutputModels
{
    public class ResponseRatesModel
    {
        public string Base { get; set; }
        //public List<Dictionary<DateTime, List<Dictionary<string, double>>>> Rates { get; set; } //TODO: Nooo way mate, just an idea
        public Dictionary<DateTime, Dictionary<string, double>> Rates { get; set; }
        //public int MyProperty { get; set; }

    }
}
