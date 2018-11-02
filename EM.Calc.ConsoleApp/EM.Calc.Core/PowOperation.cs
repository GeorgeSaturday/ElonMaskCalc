using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.ConsoleApp
{
    public class PowOperation : IOperation

    {
        public string Name => "pow";
    

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute ()
        {
            Result = Operands.Aggregate((a, b) => Math.Pow(a, b));
            return null;
        }
    }
}
