using WebApplication.Services.Data;

namespace WebApplication.Services.IntegralService
{
    public interface IIntegralBuilderService
    {
        double Build(Adapted integralParameter);
    }
}