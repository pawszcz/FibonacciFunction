using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionExampleApp
{
    public static class FibonacciFunction
    {
        [FunctionName("FibonacciFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string numberParam = req.Query["number"];
            int number = Convert.ToInt32(numberParam);

            Fibonacci fibonacci = new Fibonacci();

            if (numberParam == null)
            {
                return new BadRequestObjectResult("Proszê umieœciæ parametr number jako query w url'u! e.g.: .../api/FibonacciFunction?number=24");
            }

            try
            {
                int fibonacciResult = fibonacci.calculate(number);
                return (ActionResult)new OkObjectResult($"Fibonacci dla wyrazu {numberParam} to {fibonacci.calculate(number)}");
            } catch (Exception e)
            {
                return new BadRequestObjectResult($"B³êdny parametr! Liczba {numberParam} jest poza zakresem!");
            }
        }
    }
}
