using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    public class Calc
    {
        public double Sum(double[] args)
        {
            return args.Sum();
        }

        public double Substraction(double[] args)
        {
            double result;
            int n = args.Length;
            result = args[0];
            for (int i = 1; i < n; i++)
            {
                result = result - args[i];
            }
            return (result);
        }

        public double Exponentiation(double[] args)
        {
            double result;
            int n = args.Length;
            result = args[0];
            for (int i = 1; i < n; i++)
            {
                result = Math.Pow(result, args[i]);
            }
            return (result);
        }
    }
}
