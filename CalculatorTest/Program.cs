using System;
using System.Text;

namespace CalculatorTest
{
    internal class Program
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

        class Calculator : ISimpleCalculator
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
                int result = start / by;
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


        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Calculator calculator = new Calculator();
            TextWriterDebug textWriter = new TextWriterDebug();
            int result = 0;
            result = calculator.Add(1, 1);
            textWriter.Write(result);

            result = (int)calculator.Divide(1, 1);
            textWriter.Write(result);

            result = calculator.Multiply(1, 1);
            textWriter.Write(result);

            result = calculator.Subtract(1, 1);
            textWriter.Write(result);


            Console.WriteLine("End");

            Console.ReadLine();

        }
    }
}
