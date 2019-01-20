using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoListApi.Models;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoListController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/todolist
        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        // GET: api/todolist/1
        [HttpGet("{id}")]
        public ActionResult<Task> GetTask(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // POST: api/todolist
        [HttpPost]
        public ActionResult<Task> PostTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // PUT: api/todolist/1
        [HttpPut("{id}")]
        public IActionResult PutTask(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/todolist/1
        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return task;
        }
    }
}