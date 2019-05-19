using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrayonTest.Models.OutputModels
{
    public class ReturnModel
    {
        public ReturnModel(double average, double minExchangeRate, double maxExchangeRate, DateTime dateOnMinRate, DateTime dateOnMaxRate)
        {
            AverageValue = average;
            MinExchangeRate = minExchangeRate;
            MaxExchangeRate = maxExchangeRate;
            DateOnMaxRate = dateOnMaxRate;
            DateOnMinRate = dateOnMinRate;
        }
        public double AverageValue { get; set; }
        public double MinExchangeRate { get; set; }
        public Double MaxExchangeRate { get; set; }
        public DateTime DateOnMinRate { get; set; }
        public DateTime DateOnMaxRate { get; set; }
    }
}
