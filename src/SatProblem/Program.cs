using System;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Providers;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRandomInstanceGenerator();
        }

        private static void TestRandomInstanceGenerator()
        {
            var generator = new RandomInstaceProvider();
            var instance = generator.GetInstance(5);

            Console.WriteLine(instance.Formula);
        }
    }
}
