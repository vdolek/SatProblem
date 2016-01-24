using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Tests
{
    [TestClass]
    public class FormulaTests
    {
        [TestMethod]
        public void TestLogicalSum()
        {
            var literalFormulas = new IFormula[]
            {
                new LiteralFormula(0),
                new LiteralFormula(1),
                new LiteralFormula(2)
            };

            var formula = new LogicalSumFormula(literalFormulas);

            var conf1 = new Configuration(1L | (1L << 1) | (1L << 2));
            var conf2 = new Configuration(1L | (1L << 1));
            var conf3 = new Configuration(1L);
            var conf4 = new Configuration(0);

            Assert.IsTrue(formula.GetValue(conf1));
            Assert.IsTrue(formula.GetValue(conf2));
            Assert.IsTrue(formula.GetValue(conf3));
            Assert.IsFalse(formula.GetValue(conf4));
        }

        [TestMethod]
        public void TestLogicalProduct()
        {
            var literalFormulas = new IFormula[]
            {
                new LiteralFormula(0),
                new LiteralFormula(1),
                new LiteralFormula(2)
            };

            var formula = new LogicalProductFormula(literalFormulas);

            var conf1 = new Configuration(1L | (1L << 1) | (1L << 2));
            var conf2 = new Configuration(1L | (1L << 1));
            var conf3 = new Configuration(1L);
            var conf4 = new Configuration(0);

            Assert.IsTrue(formula.GetValue(conf1));
            Assert.IsFalse(formula.GetValue(conf2));
            Assert.IsFalse(formula.GetValue(conf3));
            Assert.IsFalse(formula.GetValue(conf4));
        }

        [TestMethod]
        public void TestNegation()
        {
            var literalFormulas = new IFormula[]
            {
                new LiteralFormula(0),
                new LiteralFormula(1),
                new NegateFormula(new LiteralFormula(2))
            };

            var formula = new LogicalProductFormula(literalFormulas);

            var conf1 = new Configuration(1L | (1L << 1) | (1L << 2));
            var conf2 = new Configuration(1L | (1L << 1));
            var conf3 = new Configuration(1L);
            var conf4 = new Configuration(0);

            Assert.IsFalse(formula.GetValue(conf1));
            Assert.IsTrue(formula.GetValue(conf2));
            Assert.IsFalse(formula.GetValue(conf3));
            Assert.IsFalse(formula.GetValue(conf4));
        }
    }
}
