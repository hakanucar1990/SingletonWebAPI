using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DenemeWebAPI.Models
{
    public class ExchangeManager
    {
        private static ExchangeManager _exchangeManager;
        static object _lockObject = new object();
        private static Dictionary<int, double> rates = new Dictionary<int, double>();
        private ExchangeManager()
        {
            if (rates != null)
            {
                rates.Add(978, 10.45);//euro
                rates.Add(840, 8.74);//dolar
                rates.Add(392, 7.01);//yen
                rates.Add(985, 2.24);//zloti
                rates.Add(810, 0.12);//ruble
            }
        }

        public static ExchangeManager CreateAsSingleton()
        {

            lock (_lockObject)
            {
                if (_exchangeManager == null)
                {
                    _exchangeManager = new ExchangeManager();
                }
            }
            return _exchangeManager;
        }
        public KeyValuePair<int, double> GetRate(int rateCode)
        {
            try
            {
                if (rates.ContainsKey(rateCode))
                    return rates.SingleOrDefault(p => p.Key == rateCode);
                else
                {
                    throw new Exception("RateCode not found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("RateCode not found!");
            }

        }

        public KeyValuePair<int, double> SetRate(int rateCode, double rateValue)
        {
            try
            {
                if (rates.ContainsKey(rateCode))
                {
                    rates[rateCode] = rateValue;
                    return rates.SingleOrDefault(p => p.Key == rateCode);
                }
                else
                {
                    throw new Exception("RateCode could not be saved");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("RateCode could not be saved");
            }
        }
    }
}
//rates.Add(978, 10.45);//euro
//            rates.Add(840, 8.74);//dolar
//            rates.Add(392, 7.01);//yen
//            rates.Add(985, 2.24);//zloti
//rates.Add(810, 0.12);//ruble