using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Loan
{
    public static class SimpleInterest
    {
        [FunctionName("SimpleInterest")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string principal = req.Query["principal"];
            string rate = req.Query["rate"];
            string term = req.Query["term"];

            if (string.IsNullOrEmpty(principal) || string.IsNullOrEmpty(rate) || string.IsNullOrEmpty(term))
            {
                return new BadRequestObjectResult("Please provide principal, rate and term on the query string");
            }
            else
            {
                double p = Convert.ToDouble(principal);
                double r = Convert.ToDouble(rate);
                double t = Convert.ToDouble(term);

                double si = (p * r * t);

                string responseMessage = $"Simple Interest for Principal {p}, Rate {r} and Term {t} is {si}";

                return new OkObjectResult(responseMessage);
            }
        }
    }
}
