using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

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

        public bool GetValue(Configuration configuraion)
        {
            var res = configuraion.State & variableBitArrayIndex;
            return res != 0;
        }
    }
}