using System.Linq;
using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Helpers
{
    public static class InstanceExtesions
    {
        public static int GetWeight(this Instance instance, long configuration)
        {
            var res = instance.Formula.GetValue(configuration);

            if (!res)
            {
                return 0;
            }

            var weight = instance.Weights.Where((x, idx) => (configuration & (1L << idx)) != 0).Sum();
            return weight;
        }

        public static EvaluatedConfiguration EvaluateConfiguration(this Instance instance, long configuration)
        {
            var weight = instance.GetWeight(configuration);
            var res = new EvaluatedConfiguration(instance, configuration, weight);
            return res;
        }
    }
}
