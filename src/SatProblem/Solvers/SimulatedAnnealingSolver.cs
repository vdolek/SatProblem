using System;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Helpers;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers
{
    public class SimulatedAnnealingSolver : ISolver
    {
        private static readonly Random rand = new Random(0);

        private readonly double initTemperature = 200d;
        private readonly double frozenTemperature = 1d;
        private readonly double coolingCoeficient = 0.95;
        private readonly int equilibriumCoeficient = 10;

        public SimulatedAnnealingSolver()
        {
        }

        public SimulatedAnnealingSolver(double initTemperature, double frozenTemperature, double coolingCoeficient, int equilibriumCoeficient)
        {
            this.initTemperature = initTemperature;
            this.frozenTemperature = frozenTemperature;
            this.coolingCoeficient = coolingCoeficient;
            this.equilibriumCoeficient = equilibriumCoeficient;
        }

        public EvaluatedConfiguration Solve(Instance instance)
        {
            var currentConfiguration = new EvaluatedConfiguration(instance, 0, 0);
            var bestConfiguration = currentConfiguration;

            for (var temperature = initTemperature; IsFrozen(temperature); temperature *= coolingCoeficient)
            {
                currentConfiguration = bestConfiguration; // it is good to go back to best result sometimes

                OnNewConfiguration(currentConfiguration);

                for (var innerCycle = 0; Equilibrium(instance, innerCycle); ++innerCycle)
                {
                    currentConfiguration = GetNextConfiguration(instance, temperature, currentConfiguration);
                    
                    if (currentConfiguration.Weight > bestConfiguration.Weight)
                    {
                        bestConfiguration = currentConfiguration;
                    }
                }
            }

            OnNewConfiguration(bestConfiguration);
            return bestConfiguration;
        }

        private bool IsFrozen(double temperature)
        {
            var res = temperature > frozenTemperature;
            return res;
        }

        private bool Equilibrium(Instance instance, int innerCycle)
        {
            var res = innerCycle < (equilibriumCoeficient * instance.VariableCount);
            return res;
        }

        private EvaluatedConfiguration GetNextConfiguration(Instance instance, double temperature, EvaluatedConfiguration currentConfiguration)
        {
            // get random state (only fitting in knapsack)
            var newConfiguration = GetRandomConfiguration(instance, currentConfiguration);

            // when new state is better
            if (newConfiguration.Weight > currentConfiguration.Weight)
            {
                return newConfiguration;
            }
            else // when new state is worse
            {
                var random = rand.NextDouble();
                var delta = currentConfiguration.Weight - newConfiguration.Weight;
                var useWorse = random < Math.Exp(-delta / temperature);
                return useWorse ? newConfiguration : currentConfiguration;
            }
        }

        private EvaluatedConfiguration GetRandomConfiguration(Instance instance, EvaluatedConfiguration currentConfiguration)
        {
            var variableIndex = rand.Next(instance.VariableCount);
            var variableBitArray = 1L << variableIndex;
            var newConfiguration = currentConfiguration.Configuration ^ variableBitArray;
            var newWeight = instance.GetWeight(newConfiguration);
            return new EvaluatedConfiguration(instance, newConfiguration, newWeight);
        }

        public event EventHandler<EvaluatedConfiguration> NewConfiguration;

        protected virtual void OnNewConfiguration(EvaluatedConfiguration e)
        {
            NewConfiguration?.Invoke(this, e);
        }
    }
}
