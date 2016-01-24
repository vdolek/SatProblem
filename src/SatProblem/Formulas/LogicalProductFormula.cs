using System.Collections.Generic;
using System.Linq;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas
{
    public class LogicalProductFormula : IFormula
    {
        public IList<IFormula> Formulas { get; }

        public LogicalProductFormula(IList<IFormula> formulas)
        {
            Formulas = formulas;
        }

        public bool GetValue(Configuration configuraion)
        {
            var result = Formulas.All(x => x.GetValue(configuraion));
            return result;
        }
    }
}