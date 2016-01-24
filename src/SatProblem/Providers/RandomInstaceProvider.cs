using System;
using System.Collections.Generic;
using System.Linq;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Providers
{
    public class RandomInstaceProvider : IInstaceProvider
    {
        private const int MIN_PRODUCT_LENGTH = 10;
        private const int MAX_PRODUCT_LENGTH = 20;
        private const int MIN_SUM_LENGTH = 2;
        private const int MAX_SUM_LENGTH = 3;
        private const int MIN_WEIGHT = 10;
        private const int MAX_WEIGHT = 50;

        private static Random rand = new Random(0);

        public Instance GetInstance(int variableCount)
        {
            var formula = new LogicalProductFormula(new List<IFormula>());

            var productLenth = rand.Next(MIN_PRODUCT_LENGTH, MAX_PRODUCT_LENGTH + 1);
            for (var i = 0; i < productLenth; i++)
            {
                var sumFormula = new LogicalSumFormula(new List<IFormula>());
                formula.Formulas.Add(sumFormula);

                var sumLength = rand.Next(MIN_SUM_LENGTH, MAX_SUM_LENGTH + 1);
                for (var j = 0; j < sumLength; j++)
                {
                    var literalFormula = new LiteralFormula(rand.Next(variableCount));

                    if (rand.Next(2) == 0)
                    {
                        sumFormula.Formulas.Add(literalFormula);
                    }
                    else
                    {
                        sumFormula.Formulas.Add(new NegateFormula(literalFormula));
                    }
                }
            }

            var instance = new Instance
            {
                Formula = formula,
                Weights = Enumerable.Range(0, variableCount).Select(x => rand.Next(MIN_WEIGHT, MAX_WEIGHT + 1)).ToArray()
            };

            return instance;
        }
    }
}