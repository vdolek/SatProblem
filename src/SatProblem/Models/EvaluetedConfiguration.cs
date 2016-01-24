namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models
{
    public class EvaluatedConfiguration
    {
        public long Configuration { get; set; }

        public int Weight { get; set; }

        public EvaluatedConfiguration(long configuration, int weight)
        {
            Configuration = configuration;
            Weight = weight;
        }
    }
}