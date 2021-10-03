using DenemeWebAPI.Models;
using ExchangeRatesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static ExchangeRatesWebAPI.Models.RequestResponse;

namespace ExchangeRatesWebAPI.Controllers
{
    public class ExchangeRatesController : ApiController
    {
        public ExchangeRatesController()
        {

        }

        public string Get()
        {
            return "true";
        }
        [HttpPost]
        [Route("GetRate")]
        public GetRateResponse GetRate([FromBody] GetRateRequest request)
        {
            GetRateResponse response = new GetRateResponse();
            try
            {
                ExchangeManager exchangeManager = ExchangeManager.CreateAsSingleton();
                var rate = exchangeManager.GetRate(request.rateCode);
                response.rate = rate.Value;
                response.rateCode = rate.Key;
                return response;
            }
            catch (Exception ex)
            {
                response.rate = -1;
                response.rateCode = -1;
                return response;
            }
            finally
            {
                response = null;
            }
        }

        [HttpPost]
        [Route("SetRate")]
        public SetRateResponse SetRate([FromBody] SetRateRequest request)
        {
            SetRateResponse response = new SetRateResponse();
            try
            {
                ExchangeManager exchangeManager = ExchangeManager.CreateAsSingleton();
                var rate = exchangeManager.SetRate(request.rateCode, request.rateValue);
                response.rate = rate.Value;
                response.rateCode = rate.Key;
                return response;
            }
            catch (Exception ex)
            {
                response.rate = -1;
                response.rateCode = -1;
                return response;
            }
            finally
            {
                response = null;
            }
        }
    }
}