using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Providers
{
    public interface IInstaceProvider
    {
        Instance GetInstance(int variableCount);
    }
}
