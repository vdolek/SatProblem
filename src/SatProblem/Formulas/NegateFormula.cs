namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas
{
    public class NegateFormula : IFormula
    {
        public IFormula Formula { get; }

        public NegateFormula(IFormula formula)
        {
            Formula = formula;
        }

        public bool GetValue(long configuration)
        {
            var res = !Formula.GetValue(configuration);
            return res;
        }

        public override string ToString()
        {
            return $"{Formula}'";
        }
    }
}