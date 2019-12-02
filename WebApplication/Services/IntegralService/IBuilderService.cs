using WebApplication.Services.Data;

namespace WebApplication.Services.IntegralService
{
    public interface IBuilderService
    {
        Result Build(Adapted lesParameter);
    }
}