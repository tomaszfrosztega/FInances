using Finances.Infrastructure.DTO;
using Finances.Infrastructure.IServices;
using System;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Services
{
    public interface IUserServices : IService
    {
        Task RegisterAsync(Guid userId,string email, string username, string password);

        Task<UserDTO> GetAsync(string email);

        Task LoginAsync(string email, string password);
    }
}
