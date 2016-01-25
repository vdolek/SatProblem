using System;
using System.Linq;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Providers;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Solvers;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Runners
{
    public class CompareRunner
    {
        private const int BATCH_SIZE = 10;

        public void Run(IInstaceProvider instaceProvider, ISolver exactSolver, ISolver solver)
        {
            var sizes = new[] { 10, 15, 20, 22, 25 };
            foreach (var size in sizes)
            {
                RunForSize(instaceProvider, exactSolver, solver, size);
                Console.WriteLine();
            }
        }

        private void RunForSize(IInstaceProvider instaceProvider, ISolver exactSolver, ISolver solver, int variableCount)
        {
            var instances = Enumerable.Range(0, BATCH_SIZE).Select(x => instaceProvider.GetInstance(variableCount)).ToArray();
            var exactResults = instances.AsParallel().AsOrdered().Select(exactSolver.Solve).ToArray();
            var results = instances.Select(solver.Solve).ToArray();

            var zipped = exactResults.Zip(results, (er, r) => new { er, r }).ToArray();
            var hasSolution = zipped.Where(x => x.er.Configuration != 0).ToArray();
            var hasBothSolutions = hasSolution.Where(x => x.r.Configuration != 0).ToArray();

            var relativeDivergences = hasBothSolutions.Select(i => (i.er.Weight - i.r.Weight)/(double) i.er.Weight).ToArray();
            var averageRelativeDivergence = relativeDivergences.Average(x => x);
            var maxRelativeDivergence = relativeDivergences.Max(x => x);
            var notExactSolutions = zipped.Count(x => x.er.Weight != x.r.Weight);
            var solutionNotFound = hasSolution.Length - hasBothSolutions.Length;

            Console.WriteLine($"Variable Count:              {variableCount}");
            Console.WriteLine($"Average Relative Divergence: {averageRelativeDivergence}");
            Console.WriteLine($"Max Relative Divergence:     {maxRelativeDivergence}");
            Console.WriteLine($"Not Exact Solutions:         {notExactSolutions}");
            Console.WriteLine($"Solution Not Found:          {solutionNotFound}");
        }
    }
}
