using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CalculatorTestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimeNumberController : ControllerBase
    {

        public interface PrimeNumber
        {
            int GetPrimeNumber(int iteration);
        }

        class TextWriterDebug : System.IO.TextWriter
        {
            public override void Write(int result)
            {
                System.Diagnostics.Debug.Write(result);
            }

            public override Encoding Encoding => throw new NotImplementedException();

        }

        class PrimeNumberFunctions : PrimeNumber
        {
            public int GetPrimeNumber(int iteration)
            {
                Console.WriteLine("Getting prime number...");
                int num = 1;
                int count = 0;
                int n = iteration;
                while (true)
                {
                    num++;
                    if (isPrime(num))
                    {
                        count++;
                    }
                    if (count == n)
                    {
                        break;
                    }
                }

                return num;
            }
        }


        public static bool isPrime(int number)
        {
            int counter = 0;
            for (int j = 2; j < number; j++)
            {
                if (number % j == 0)
                {
                    counter = 1;
                    break;
                }
            }
            if (counter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        [HttpGet(Name = "PrimeNumber")]
        public IEnumerable<PrimeNum> Get(int iteration)
        {
            PrimeNumberFunctions primeNumber = new PrimeNumberFunctions();
            return new[] { new PrimeNum() { result = primeNumber.GetPrimeNumber(iteration) } };
        }
    }
}
