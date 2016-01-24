using System.Collections.Generic;
using System.Linq;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas
{
    public class LogicalProductFormula : IFormula
    {
        public IList<IFormula> Formulas { get; }

        public LogicalProductFormula(IList<IFormula> formulas)
        {
            Formulas = formulas;
        }

        public bool GetValue(long configuration)
        {
            var result = Formulas.All(x => x.GetValue(configuration));
            return result;
        }

        public override string ToString()
        {
            var str = string.Join("·", Formulas.Select(x => x.ToString()));
            return str;
        }
    }
}