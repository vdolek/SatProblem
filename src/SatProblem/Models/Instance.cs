using System.Collections.Generic;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models
{
    public class Instance
    {
        public int VariableCount => Weights.Count;

        public IList<int> Weights { get; set; }

        public IFormula Formula { get; set; }
    }
}
