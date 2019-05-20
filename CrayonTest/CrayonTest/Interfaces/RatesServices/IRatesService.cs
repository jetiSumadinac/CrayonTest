using CrayonTest.Models.InputModels;
using CrayonTest.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrayonTest.Interfaces.RatesServices
{
    public interface IRatesService
    {
        Task<ReturnModel> GetRates(InputExchangeDataModel data);
    }
}
