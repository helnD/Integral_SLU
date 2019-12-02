using Microsoft.AspNetCore.Http;
using WebApplication.Services.Data;

namespace WebApplication.Services.AdapterService
{
    public interface IAdapterService
    {
        Adapted Adapt(IQueryCollection collection);
    }
}