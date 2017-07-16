using Finances.Infrastructure.DTO;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Services
{
    public interface IUserServices
    {
        Task RegisterAsync(string email, string username, string password);

        Task<UserDTO> GetAsync(string email);
    }
}
