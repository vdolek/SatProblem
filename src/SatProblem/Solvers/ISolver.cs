using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers
{
    public interface ISolver
    {
        EvaluatedConfiguration Solve(Instance instance);
    }
}
