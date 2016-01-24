using System;
using System.Linq;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models
{
    public class EvaluatedConfiguration
    {
        public Instance Instance { get; set; }

        public long Configuration { get; set; }

        public int Weight { get; set; }

        public EvaluatedConfiguration(Instance instance, long configuration, int weight)
        {
            Instance = instance;
            Configuration = configuration;
            Weight = weight;
        }

        public override string ToString()
        {
            var configurationStr = Convert.ToString(Configuration, 2).PadLeft(Instance.VariableCount, '0');
            configurationStr = new string(configurationStr.Reverse().ToArray());

            return $"Weight: {Weight}, Configuration: {configurationStr}";
        }
    }
}