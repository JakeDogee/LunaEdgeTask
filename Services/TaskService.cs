using LunaEdgeTask.Models;
using LunaEdgeTask.Repositories.Interfaces;

namespace LunaEdgeTask.Services;

public class TaskService
{
    private readonly IRepository<TaskItem> _taskRepository;

    public TaskService(IRepository<TaskItem> taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskItem>> GetTasksForUser(Guid userId)
    {
        return await _taskRepository.GetAll()
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task<TaskItem> GetTaskById(Guid userId, Guid taskId)
    {
        var task = await _taskRepository.GetById(taskId);
        if (task.UserId == userId)
        {
            return task;
        }
        return null;
    }

    public async Task CreateTask(TaskItem task)
    {
        await _taskRepository.Add(task);
    }

    public async Task UpdateTask(TaskItem task)
    {
        await _taskRepository.Update(task);
    }

    public async Task DeleteTask(Guid taskId)
    {
        await _taskRepository.Delete(taskId);
    }
}