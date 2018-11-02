using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    /// <summary>
    /// Operation
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// operands
        /// </summary>
        /// 
        double[] Operands { get; set; }
        /// <summary>
        /// Execute 
        /// </summary>
        /// <returns>Result</returns>
        double? Execute();

        /// <summary>
        /// Result
        /// </summary>
        double? Result { get;  }

        /// <summary>
        /// Для хранения результатов/ последнего результата
        /// </summary>
     //  double? Memory();


    }
}
