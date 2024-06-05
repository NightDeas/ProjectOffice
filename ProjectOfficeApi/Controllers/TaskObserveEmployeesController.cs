using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOffice.DataBase.Entities;

namespace ProjectOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskObserveEmployeesController : ControllerBase
    {
        private readonly Context _context;

        public TaskObserveEmployeesController(Context context)
        {
            _context = context;
        }

        // GET: api/TaskObserveEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskObserveEmployee>>> GetTaskObserveEmployees()
        {
          if (_context.TaskObserveEmployees == null)
          {
              return NotFound();
          }
            return await _context.TaskObserveEmployees.ToListAsync();
        }

        // GET: api/TaskObserveEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskObserveEmployee>> GetTaskObserveEmployee(int id)
        {
          if (_context.TaskObserveEmployees == null)
          {
              return NotFound();
          }
            var taskObserveEmployee = await _context.TaskObserveEmployees.FindAsync(id);

            if (taskObserveEmployee == null)
            {
                return NotFound();
            }

            return taskObserveEmployee;
        }

        // PUT: api/TaskObserveEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskObserveEmployee(int id, TaskObserveEmployee taskObserveEmployee)
        {
            if (id != taskObserveEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskObserveEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskObserveEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskObserveEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskObserveEmployee>> PostTaskObserveEmployee(TaskObserveEmployee taskObserveEmployee)
        {
          if (_context.TaskObserveEmployees == null)
          {
              return Problem("Entity set 'DbContextProjectOffice.TaskObserveEmployees'  is null.");
          }
            _context.TaskObserveEmployees.Add(taskObserveEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskObserveEmployee", new { id = taskObserveEmployee.Id }, taskObserveEmployee);
        }

        // DELETE: api/TaskObserveEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskObserveEmployee(int id)
        {
            if (_context.TaskObserveEmployees == null)
            {
                return NotFound();
            }
            var taskObserveEmployee = await _context.TaskObserveEmployees.FindAsync(id);
            if (taskObserveEmployee == null)
            {
                return NotFound();
            }

            _context.TaskObserveEmployees.Remove(taskObserveEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskObserveEmployeeExists(int id)
        {
            return (_context.TaskObserveEmployees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
