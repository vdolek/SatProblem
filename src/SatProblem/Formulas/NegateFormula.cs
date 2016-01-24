using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas
{
    public class NegateFormula : IFormula
    {
        public IFormula Formula { get; }

        public NegateFormula(IFormula formula)
        {
            Formula = formula;
        }

        public bool GetValue(Configuration configuraion)
        {
            var res = !Formula.GetValue(configuraion);
            return res;
        }
    }
}