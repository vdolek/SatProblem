using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Helpers;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers
{
    public class BrutteForceSolver : ISolver
    {
        public EvaluatedConfiguration Solve(Instance instance)
        {
            var bestConfiguration = new EvaluatedConfiguration(instance, 0, 0);

            var max = 1L << instance.VariableCount;
            for (var configuation = 0L; configuation < max; configuation++)
            {
                var weight = instance.GetWeight(configuation);

                if (weight > bestConfiguration.Weight)
                {
                    bestConfiguration.Configuration = configuation;
                    bestConfiguration.Weight = weight;
                }
            }

            return bestConfiguration;
        }
    }
}