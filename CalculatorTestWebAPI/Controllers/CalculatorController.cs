using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CalculatorTestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        public interface ISimpleCalculator
        {
            int Add(int start, int amount);
            int Subtract(int start, int amount);
            int Multiply(int start, int by);
            float Divide(int start, int by);
        }

        class TextWriterDebug : System.IO.TextWriter
        {
            public override void Write(int result)
            {
                System.Diagnostics.Debug.Write(result);
            }

            public override Encoding Encoding => throw new NotImplementedException();

        }

        class CalculatorFunctions : ISimpleCalculator
        {
            public int Add(int start, int amount)
            {
                Console.WriteLine("Adding...");
                int result = start + amount;
                return result;
            }

            public float Divide(int start, int by)
            {
                Console.WriteLine("Dividing...");
                float result = start / by;
                return result;
            }

            public int Multiply(int start, int by)
            {
                Console.WriteLine("Multipling...");
                int result = start * by;
                return result;
            }

            public int Subtract(int start, int amount)
            {
                Console.WriteLine("Subtracting...");
                int result = start - amount;
                return result;
            }
        }


        [HttpGet(Name = "useCalculator")]
        public IEnumerable<Calculator> Get(int start, int amount, string type)
        {
            CalculatorFunctions calculator = new CalculatorFunctions();

            if (type == "Add")
            {
                return new[] { new Calculator() { result = calculator.Add(start, amount) } };
            }

            if (type == "Divide")
            {
                return new[] { new Calculator() { result = calculator.Divide(start, amount) } };
            }

            if (type == "Multiply")
            {
                return new[] { new Calculator() { result = calculator.Multiply(start, amount) } };
            }

            if (type == "Subtract")
            {
                return new[] { new Calculator() { result = calculator.Subtract(start, amount) } };
            }

            return new[] { new Calculator() { result = 0 } };
        }
    }
}
