using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}
