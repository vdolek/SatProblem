using System;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Tests
{
    [TestClass]
    public class BruteForceSolverTests
    {
        [TestMethod]
        public void TestBrutteForce()
        {
            // n = 4 
            // F = (x0 + x2' + x3).(x0' + x1 + x2').(x2 + x3).(x0 + x1 + x2' + x3').(x1' + x2).(x2' + x3') 
            // W = (2, 4, 1, 6)
            // expected solution: {1, 0, 0, 1}, weight: 8

            var formula = new LogicalProductFormula(new IFormula[]
            {
                // (x0 + x2' + x3)
                new LogicalSumFormula(new IFormula[]
                {
                    new LiteralFormula(0),
                    new NegateFormula(new LiteralFormula(2)),
                    new LiteralFormula(3)
                }),
                // (x0' + x1 + x2')
                new LogicalSumFormula(new IFormula[]
                {
                    new NegateFormula(new LiteralFormula(0)),
                    new LiteralFormula(1),
                    new NegateFormula(new LiteralFormula(2)),
                }),
                // (x2 + x3)
                new LogicalSumFormula(new IFormula[]
                {
                    new LiteralFormula(2),
                    new LiteralFormula(3)
                }),
                // (x0 + x1 + x2' + x3')
                new LogicalSumFormula(new IFormula[]
                {
                    new LiteralFormula(0),
                    new LiteralFormula(1),
                    new NegateFormula(new LiteralFormula(2)),
                    new NegateFormula(new LiteralFormula(3)),
                }),
                // (x1' + x2)
                new LogicalSumFormula(new IFormula[]
                {
                    new NegateFormula(new LiteralFormula(1)),
                    new LiteralFormula(2)
                }),
                // (x2' + x3')
                new LogicalSumFormula(new IFormula[]
                {
                    new NegateFormula(new LiteralFormula(2)),
                    new NegateFormula(new LiteralFormula(3))
                })
            });

            Console.WriteLine(formula);

            var instance = new Instance
            {
                Formula = formula,
                Weights = new [] { 2, 4, 1, 6 }
            };

            var solver = new BrutteForceSolver();
            var res = solver.Solve(instance);

            var expectedConfiguration = 1L | (1L << 3);
            Assert.AreEqual(expectedConfiguration, res.Configuration);
            Assert.AreEqual(8, res.Weight);
        }
    }
}
