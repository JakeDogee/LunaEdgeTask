using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LunaEdgeTask.Models;
using LunaEdgeTask.Repositories.Interfaces;

namespace LunaEdgeTask.Services;

public class UserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task RegisterUser(User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        await _userRepository.Add(user);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepository.GetAll()
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}