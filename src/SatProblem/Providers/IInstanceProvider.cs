using Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Models;

namespace Cz.Volek.CVUT.FIT.MIPAA.SatProblem.Providers
{
    public interface IInstanceProvider
    {
        Instance GetInstance(int variableCount);
    }
}
