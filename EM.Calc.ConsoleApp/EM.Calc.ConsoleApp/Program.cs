using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var calc = new Core.Calc();
            string[] keywords = { "sub", "pow", "exit" };
           
            while (true)
            {
               
                string[] input = Console.ReadLine().Split(' ');
                int n = input.Length;
                double[] operands =  new double[n-1];
                double j;
 
                for (int i = 1; i < n; i++)
                {
                   if (double.TryParse(input[i], out j))
                    {
                        operands[i - 1] = j;
                    }              
                    
                }

                switch (input[0])
                {
                    case "sub":
                        {
                            try
                            {
                                Console.WriteLine(calc.Substraction(operands));
                            }
                            catch
                            {
                                Console.WriteLine("invalid syntax");
                            }
                            
                        }
                        break;

                    case "pow":
                        {
                            try
                            {                               
                                Console.WriteLine(calc.Exponentiation(operands));
                            }
                            catch
                            {
                                Console.WriteLine("invalid syntax");
                            }

                        }
                        break;
                    case "exit":
                        {
                            Environment.Exit(0);
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Invalid command");
                        }
                        break;
                }
                
            }

        }
    }
}
