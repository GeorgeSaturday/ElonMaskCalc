using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.ConsoleApp
{
    class Program
    {
        //[DllImport("LukoilCalcFinance.dll")]
        //static extern string Name();

        //[DllImport("LukoilCalcFinance.dll")]
        //static extern double? Execute();

        static void Main(string[] args)
        {
            double[] values;          
            var calc = new Core.Calc();
            string operands, operation;

            while (true)
            {
                string[] operations = calc.Operations
                .Select(o => o.Name)
                .ToArray();

                if (args.Length == 0)
                {
                    Console.WriteLine("Operation list: ");

                    foreach (var item in operations)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("Enter operation: ");
                    operation = Console.ReadLine();

                    Console.WriteLine("Enter operands (use space): ");
                    operands = Console.ReadLine();
                    values = ConvertToDouble(
                        operands.Split(new[] { " ", ";" }, StringSplitOptions.RemoveEmptyEntries)
                    );
                }
                else
                {
                    operation = args[0].ToLower();
                    values = ConvertToDouble(args, 1);
                }

                var result = calc.Execute(operation, values);
                Console.WriteLine(result);
            }
            
        }

        static double[] ConvertToDouble(string[] args, int start = 0)
        {
            return args.ToList()
                .Skip(start)
                .Select(Convert.ToDouble)
                .ToArray();
        }

    }
}
