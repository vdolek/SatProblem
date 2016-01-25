using System.Collections.Generic;
using System.IO;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Runners
{
    public class AproximationRunner
    {
        private const double INIT_TEMPERATURE = 200d;
        private const double FROZEN_TEMPERATURE = 1d;
        private const double COOLING_COEFICIENT = 0.95;
        private const int EQUILIBRIUM_COEFICIENT = 10;

        public void Run(Instance instance, string fileName)
        {
            var configurations = new List<EvaluatedConfiguration>();

            var solver = new SimulatedAnnealingSolver(INIT_TEMPERATURE, FROZEN_TEMPERATURE, COOLING_COEFICIENT, EQUILIBRIUM_COEFICIENT);
            solver.NewConfiguration += (sender, configuration) => configurations.Add(configuration);
            solver.Solve(instance);

            using (var sw = new StreamWriter(fileName))
            {
                foreach (var evaluatedConfiguration in configurations)
                {
                    sw.WriteLine(evaluatedConfiguration.Weight);
                }

                sw.Close();
            }
        }
    }
}
