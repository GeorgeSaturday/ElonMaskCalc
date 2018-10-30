using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Calc.Tests
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            //arrange
            var calc = new Core.Calc();
            var sum = 11;
            var sub = 5;
            var exp = 16;

            //act
            var resultsum = calc.Sum(new[] { 5.4, 3.3, 2.3 });
            var resultsub = calc.Substraction(new[] { 10.9, 3.5, 2.4 });
            var resultexp = calc.Exponentiation(new[] { 2.0, 2, 2 });
            //assert
            Assert.AreEqual(sum, resultsum);
            Assert.AreEqual(sub, resultsub);
            Assert.AreEqual(exp, resultexp);


        }
    }
}
