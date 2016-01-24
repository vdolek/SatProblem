using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Formulas
{
    public interface IFormula
    {
        bool GetValue(Configuration configuraion);
    }
}