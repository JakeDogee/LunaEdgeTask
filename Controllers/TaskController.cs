using LunaEdgeTask.Models;
using LunaEdgeTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LunaEdgeTask.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var userId = Guid.Parse(User.Identity.Name);
        var tasks = await _taskService.GetTasksForUser(userId);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(TaskItem task)
    {
        var userId = Guid.Parse(User.Identity.Name);
        task.UserId = userId;
        await _taskService.CreateTask(task);
        return Ok(new { message = "Task created successfully" });
    }
}