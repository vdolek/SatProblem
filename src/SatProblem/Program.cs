using System;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Providers;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRandomInstanceGenerator();
            Test1();
        }

        private static void TestRandomInstanceGenerator()
        {
            var generator = new RandomInstaceProvider();
            var instance = generator.GetInstance(5);

            Console.WriteLine(instance.Formula);
        }

        private static void Test1()
        {
            var generator = new RandomInstaceProvider();
            var instance = generator.GetInstance(20);
            Console.WriteLine(instance.Formula);

            var brutteForceSolver = new BrutteForceSolver();
            var simulatedAnnealingSolver = new SimulatedAnnealingSolver();

            var solution1 = brutteForceSolver.Solve(instance);
            var solution2 = simulatedAnnealingSolver.Solve(instance);
            Console.WriteLine(solution1);
            Console.WriteLine(solution2);
        }
    }
}
