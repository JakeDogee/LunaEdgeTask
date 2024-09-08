using LunaEdgeTask.Data;
using LunaEdgeTask.Models;
using LunaEdgeTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunaEdgeTask.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly TaskManagementDbContext _context;

    public UserRepository(TaskManagementDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task Add(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var user = await GetById(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}