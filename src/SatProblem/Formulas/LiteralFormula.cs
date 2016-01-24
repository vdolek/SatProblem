namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas
{
    public class LiteralFormula : IFormula
    {
        private readonly long variableBitArrayIndex;

        public int VariableIndex { get; }

        public LiteralFormula(int variableIndex)
        {
            VariableIndex = variableIndex;
            variableBitArrayIndex = (1L << VariableIndex);
        }

        public bool GetValue(long configuration)
        {
            var res = configuration & variableBitArrayIndex;
            return res != 0;
        }

        public override string ToString()
        {
            return $"x{VariableIndex}";
        }
    }
}