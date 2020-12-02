using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportsWebApp.Data;
using ReportsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ReportsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksDbContext tasksDbContext;

        public TasksController(TasksDbContext context)
        {
            tasksDbContext = context;
        }

        //Create task
        [Authorize]
        [HttpPost]
        public ActionResult Post([FromBody] TaskRequest request)
        {
            Guid user = Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var task = new UserTask()
            {
                Date = request.Date,
                Comment = request.Comment,
                AccountId = user
            };
            try
            {
                StatusType status = (StatusType)Enum.Parse(typeof(StatusType), request.Status);
                task.Status = status;
                tasksDbContext.Add(task);
                tasksDbContext.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [HttpGet("{taskId}")]
        public ActionResult<TaskResponce> Get(int taskId)
        {
            var task = tasksDbContext.UserTasks.SingleOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                return new ObjectResult(
                    new TaskResponce()
                    {
                        TaskNumber = task.Date.ToString("yyyyMMdd") + "-" + task.TaskId.ToString("D4"),
                        Status = task.Status.ToString(),
                        Date = task.Date,
                        Comment = task.Comment
                    });
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<TaskResponce>> Get()
        {
            Guid user = Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
           
            var tasks = tasksDbContext.UserTasks.Where(u => u.AccountId == user).ToList();
            if (tasks != null)
            {
                List<TaskResponce> result = new List<TaskResponce>();
                foreach(var task in tasks)
                {
                    result.Add(new TaskResponce()
                    {
                        TaskNumber = task.Date.ToString("yyyyMMdd") + "-" + task.TaskId.ToString("D4"),
                        Date = task.Date,
                        Status = task.Status.ToString(),
                        Comment = task.Comment
                    });
                }
                return new ObjectResult(result);
            }
            return NotFound();
        }
    }

}
