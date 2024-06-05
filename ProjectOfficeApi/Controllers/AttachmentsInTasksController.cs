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
    public class AttachmentsInTasksController : ControllerBase
    {
        private readonly Context _context;

        public AttachmentsInTasksController(Context context)
        {
            _context = context;
        }

        // GET: api/AttachmentsInTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttachmentsInTask>>> GetAttachmentsInTasks()
        {
          if (_context.AttachmentsInTasks == null)
          {
              return NotFound();
          }
            return await _context.AttachmentsInTasks.ToListAsync();
        }

        // GET: api/AttachmentsInTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttachmentsInTask>> GetAttachmentsInTask(int id)
        {
          if (_context.AttachmentsInTasks == null)
          {
              return NotFound();
          }
            var attachmentsInTask = await _context.AttachmentsInTasks.FindAsync(id);

            if (attachmentsInTask == null)
            {
                return NotFound();
            }

            return attachmentsInTask;
        }

        // PUT: api/AttachmentsInTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttachmentsInTask(int id, AttachmentsInTask attachmentsInTask)
        {
            if (id != attachmentsInTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(attachmentsInTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentsInTaskExists(id))
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

        // POST: api/AttachmentsInTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttachmentsInTask>> PostAttachmentsInTask(AttachmentsInTask attachmentsInTask)
        {
          if (_context.AttachmentsInTasks == null)
          {
              return Problem("Entity set 'DbContextProjectOffice.AttachmentsInTasks'  is null.");
          }
            _context.AttachmentsInTasks.Add(attachmentsInTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttachmentsInTask", new { id = attachmentsInTask.Id }, attachmentsInTask);
        }

        // DELETE: api/AttachmentsInTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttachmentsInTask(int id)
        {
            if (_context.AttachmentsInTasks == null)
            {
                return NotFound();
            }
            var attachmentsInTask = await _context.AttachmentsInTasks.FindAsync(id);
            if (attachmentsInTask == null)
            {
                return NotFound();
            }

            _context.AttachmentsInTasks.Remove(attachmentsInTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttachmentsInTaskExists(int id)
        {
            return (_context.AttachmentsInTasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
