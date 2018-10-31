using EM.Calc.ConsoleApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.Core
{
    public class Calc
    {
        /// <summary>
        /// Operations
        /// </summary>
        
        public IList<IOperation> Operations { get; set; }
        public Calc()
        {
            Operations = new List<IOperation>();
            

            var dlllist = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");

            foreach (var dll in dlllist)
            {
                //Получить сборку по указанному пути 
                Assembly asm = Assembly.LoadFile(dll);
                // загрузить все типы из сборки
                var types = asm.GetTypes();
                //перебираем все классы в сборке
                foreach (var item in types)
                {
                    //  если класс реализаует заданный интерфейс
                    if (item.GetInterface("IOperation") != null)
                    {
                        //добавляем в операции экземпляр данного класса
                        var instanse = Activator.CreateInstance(item);
                        var operation = instanse as IOperation;
                        if (operation != null)
                        {
                            Operations.Add(operation);
                        }
                    }
                }         
            }  
        }

        public double? Execute(string operName, double[] values)
        {
             foreach (var item in Operations)
             {
                 if (item.Name == operName)
                 {
                     item.Operands = values;
                     item.Execute();
                     return item.Result;
                 }
             }
             return null;
        }
    
   
        [Obsolete("Не используйте это, есть же Execute")]
        #region
        public double Sum(double[] args)
        {
            return args.Sum();
        }

        public double Pow(double[] args)
        {
            return args.Aggregate((a, b) => Math.Pow(a, b));
        }

        public double Sub(double[] args)
        {
            return args.Aggregate((a, b) => a - b);
        }

        public double Piu(double[] args)
        {
            return args.Aggregate((a, b) => a * b);
        }

        public double New(double[] args)
        {
            return Double.PositiveInfinity;
        }
        # endregion
    }
}
