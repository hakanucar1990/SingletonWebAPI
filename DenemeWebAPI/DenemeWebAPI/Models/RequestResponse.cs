using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRatesWebAPI.Models
{
    public class RequestResponse
    {
        public class GetRateRequest
        {
            public string username { get; set; }
            public int rateCode { get; set; }
        }
        public class GetRateResponse
        {
            public int rateCode { get; set; }
            public double rate { get; set; }
        }
        public class SetRateRequest
        {
            public string username { get; set; }
            public int rateCode { get; set; }
            public double rateValue { get; set; }
        }
        public class SetRateResponse
        {
            public int rateCode { get; set; }
            public double rate { get; set; }
        }
    }
}