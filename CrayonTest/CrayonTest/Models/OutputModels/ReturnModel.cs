using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrayonTest.Models.OutputModels
{
    public class ReturnModel
    {
        public double AverageValue { get; set; }
        public double MinExchangeRate { get; set; }
        public Double MaxExchangeRate { get; set; }
        public DateTime DateOnMinRate { get; set; }
        public DateTime DateOnMaxRate { get; set; }
    }
}
