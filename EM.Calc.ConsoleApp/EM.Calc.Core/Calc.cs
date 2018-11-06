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
        /// Операции
        /// </summary>/// 
        /// <param name="path">Путь до сторонних библиотек с операциями</param>
        public IList<IOperation> Operations { get; set; }
      
        public Calc() : this("")
        {

        }

        public Calc(string path) 
        {
            Operations = new List<IOperation>();

            if (string.IsNullOrWhiteSpace(path))
            {
                path = Environment.CurrentDirectory;
            }

            else
            {
                LoadOperations(Assembly.GetExecutingAssembly());
            }

            //var dllFiles = Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly);
            //foreach (var file in dllFiles)
            //{
            //    LoadOperations(Assembly.LoadFrom(file));
            //}

        }

        private void LoadOperations(Assembly assembly)
        {
            // загрузить все типы из сборки
            var types = assembly.GetTypes();

            var needType = typeof(IOperation);

            // перебираем все классы в сборке
            foreach (var item in types.Where(t => t.IsClass && !t.IsAbstract))
            {
                var interfaces = item.GetInterfaces();

                // если класс реализаует заданный интерфейс
                if (interfaces.Contains(needType))
                {
                    //добавляем в операции экземпляр данного класса
                    var instance = Activator.CreateInstance(item);

                    var operation = instance as IOperation;
                    if (operation != null)
                    {
                        Operations.Add(operation);
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


        #region Old
        [Obsolete("Не используйте это, есть же Execute")]

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
