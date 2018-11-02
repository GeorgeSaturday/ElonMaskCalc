using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    /// <summary>
    /// Extended Operation
    /// </summary>
    public interface IExtOperation : IOperation
    {

        Guid Uid { get; }
        /// <summary>
        /// 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Count of args
        /// </summary>
       int? ArgCount { get; }


    }
}
