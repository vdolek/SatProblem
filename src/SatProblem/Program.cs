using System;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Providers;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Runners;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRandomInstanceGenerator();
            //Test1();
            CompareExperiment();
            //AproximationExperiment();
        }

        #region Tests

        private static void TestRandomInstanceGenerator()
        {
            var generator = new RandomInstanceProvider();
            var instance = generator.GetInstance(5);

            Console.WriteLine(instance.Formula);
        }

        private static void Test1()
        {
            var generator = new RandomInstanceProvider();
            var instance = generator.GetInstance(25);
            Console.WriteLine(instance.Formula);

            var brutteForceSolver = new BrutteForceSolver();
            var simulatedAnnealingSolver = new SimulatedAnnealingSolver();

            var solution1 = brutteForceSolver.Solve(instance);
            var solution2 = simulatedAnnealingSolver.Solve(instance);
            Console.WriteLine(solution1);
            Console.WriteLine(solution2);
        }

        #endregion

        #region Compare Experiment

        private static void CompareExperiment()
        {
            const int baseInitTemperature = 100;
            const int baseFrozenTemperature = 1;
            const double baseCoolingCoef = 0.9;
            const int baseEquilibriumCoef = 2;

            {
                Console.WriteLine("By start temperature");
                Console.WriteLine("---------------------------------------------------");
                var initTemperatures = new[] { 50, 100, 200, 500 };
                foreach (var initTemperature in initTemperatures)
                {
                    RunSimulatedAnnealingForConfiguration(initTemperature, baseFrozenTemperature, baseCoolingCoef, baseEquilibriumCoef);
                }
            }

            {
                Console.WriteLine("By frozen temperature");
                Console.WriteLine("---------------------------------------------------");
                var frozenTemperatures = new[] { 1, 5, 10, 20 };
                foreach (var frozenTemperature in frozenTemperatures)
                {
                    RunSimulatedAnnealingForConfiguration(baseInitTemperature, frozenTemperature, baseCoolingCoef, baseEquilibriumCoef);
                }
            }

            {
                Console.WriteLine("By cooling coeficient");
                Console.WriteLine("---------------------------------------------------");
                var coolingCoefs = new[] { 0.8, 0.85, 0.9, 0.95 };
                foreach (var coolingCoef in coolingCoefs)
                {
                    RunSimulatedAnnealingForConfiguration(baseInitTemperature, baseFrozenTemperature, coolingCoef, baseEquilibriumCoef);
                }
            }

            {
                Console.WriteLine("By equilibrium coeficient");
                Console.WriteLine("---------------------------------------------------");
                var equilibriumCoefs = new[] { 2, 5, 10, 15 };
                foreach (var equilibriumCoef in equilibriumCoefs)
                {
                    RunSimulatedAnnealingForConfiguration(baseInitTemperature, baseFrozenTemperature, baseCoolingCoef, equilibriumCoef);
                }
            }
        }

        private static void RunSimulatedAnnealingForConfiguration(double initTemperature, double frozenTemperature, double coolingCoeficient, int equilibriumCoeficient)
        {
            Console.WriteLine($"Init temperature:       {initTemperature}");
            Console.WriteLine($"Frozen temperature:     {frozenTemperature}");
            Console.WriteLine($"Cooling coeficient:     {coolingCoeficient}");
            Console.WriteLine($"Equilibrium coeficient: {equilibriumCoeficient}");
            Console.WriteLine();

            var instanceProvider = new RandomInstanceProvider();
            var exactSolver = new BrutteForceSolver();
            var simulatedAnnealingSolver = new SimulatedAnnealingSolver(initTemperature, frozenTemperature, coolingCoeficient, equilibriumCoeficient);

            var runner = new CompareRunner();
            runner.Run(instanceProvider, exactSolver, simulatedAnnealingSolver);
            Console.WriteLine();
        }

        #endregion

        #region

        private static void AproximationExperiment()
        {
            var instanceProvider = new RandomInstanceProvider();
            var runner = new AproximationRunner();

            var sizes = new[] { 10, 20, 30, 40, 50, 60 };

            foreach (var size in sizes)
            {
                Console.WriteLine($"Running size {size}.");
                var instance = instanceProvider.GetInstance(size);
                runner.Run(instance, $"{size}.txt");
                Console.WriteLine($"Done.");
                Console.WriteLine();
            }
        }

        #endregion
    }
}
