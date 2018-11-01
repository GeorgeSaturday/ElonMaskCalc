using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.ConsoleApp
{
    public class MulOperation : IOperation

    {
        public string Name => "mul";
    

        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute ()
        {
            Result = Operands.Aggregate((a, b) => a * b);
            return null;
        }
    }
}
