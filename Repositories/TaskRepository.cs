using LunaEdgeTask.Data;
using LunaEdgeTask.Models;
using LunaEdgeTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunaEdgeTask.Repositories;

public class TaskRepository : IRepository<TaskItem>
{
    private readonly TaskManagementDbContext _context;

    public TaskRepository(TaskManagementDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAll()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskItem> GetById(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task Add(TaskItem entity)
    {
        await _context.Tasks.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TaskItem entity)
    {
        _context.Tasks.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var task = await GetById(id);
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}