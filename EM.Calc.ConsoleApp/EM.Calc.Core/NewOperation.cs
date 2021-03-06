﻿using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.ConsoleApp
{
    public class NewOperation : IOperation

    {
        public string Name => "new";


        public double[] Operands { get; set; }

        public double? Result { get; private set; }

        public double? Execute()
        {
            Result = Double.PositiveInfinity;
            return Result;
        }
    }
}
